using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InfoManager : MonoBehaviour
{
    public TMP_Text ClientDialogue;
    public GameObject client;
    public GameObject box;
    public List<Sprite> clients;
    public GameObject wonLevel;
    public GameObject failedLevel;
    ProgressBar progressBar;

    private string[] prompts = new string[15] {

        // level 1
        "Hi! Can I get a liner, please?", 
        "Can I get some Advil? I have some mild cramps.",
        "May I have a tampon please?",
        "I just got my first period! Can I have a pad or tampon?",
        "My friend ran out of pads. Can I have a few?",

        // level 4
        "Do you have an environmentally friendly alternative to pads? I'm doing a zero waste challenge.",
        "I took painkillers already but I'm still feeling some pain. Would a heatpad help?",
        "I just took some Tylenol but it's not working, do you have any other pills for pain?",
        "Do you have anything for period bleeding? I've run out of products.",
        "My stomach feels unsettled, is there anything warm to drink?",

        // Level 5
        "Do you have any natural pain relief?",
        "I hate how messy pads and liners feel, are there any alternatives?",
        "My stomach hurts so much, I can barely stand. Painkillers make it worse! Can you help?",
        "I keep bleeding through my underwear and ruining clothing. Help please!",
        "I have swimming lessons this afternoon but am on my period. Can any products be used in water?",
        
    };
    private Product[] answers = new Product[15]
    {
        // Level 1
        Product.Liner,
        Product.Advil,
        Product.Tampon,
        Product.Pad | Product.Tampon,
        Product.Pad,

        // level 4
        Product.Cup,
        Product.Heatpad,
        Product.Advil,
        Product.Pad | Product.Tampon | Product.Liner | Product.Cup | Product.Underwear,
        Product.Tea,

        // Level 5
        Product.Tea | Product.Heatpad,
        Product.Tampon | Product.Cup,
        Product.Referral,
        Product.Underwear,
        Product.Tampon | Product.Cup,
    };
    private string[] correct = new string[12]
    {
        "Thanks! That's just what I needed.",
        "Awesome, see ya!",
        "Cool, have a nice day!",
        "Thank you!!",
        "Great, thank you!",
        "Nice! Bye!",
        "You're a lifesaver, thanks!",
        "That's perfect!",
        "Amazing, thank you!",
        "Thanks! I'll try it out.",
        "This is great. Thanks!",
        "Thank you!"
    };
    private string[] incorrect = new string[15]
    {
        
        // Level 1
        "I was hoping for just a liner, but thank you.",
        "Oh, I just wanted some Advil, but thanks.",
        "I needed a tampon, but thanks anyways.",
        "Either a pad or tampon would've worked.",
        "Are there no more pads? That's okay, thank you.",

        // level 4
        "I think menstrual cups are more environmentally friendly.",
        "Oh, I thought y'all might have some hot tea or water.",
        "Oh, guess there's no more Advil. I'll try to go home early.",
        "I don't think this helps. A pad, tampon, cup, pad, or even underwear would've sufficed.",
        "Ah, I was hoping there'd be tea or hot water. Thanks though, bye.",

        // Level 5
        "I'd prefer not to use that. Some tea or a heat pad would've been helpful.",
        "Hmm I'm not sure. I heard tampons and cups could work better.",
        "Thanks, but can I see the nurse? I don't think I can go back to class.",
        "A friend recently tried period underwear, I was hoping you had some!",
        "I heard tampons can be used when swimming.",
    };

    private int promptIndex = 0;
    private float progress = 0;
    private int questionsAsked = 0;
    private HashSet<int> visitedSet;
    private int lastIndex = 0;

    private void Awake()
    {
        // Initially disable the button and set the canvas group to be interactable
        wonLevel.SetActive(false);
        failedLevel.SetActive(false);
        progressBar = GameObject.FindGameObjectWithTag("Progress Bar").GetComponent<ProgressBar>();
    }

    void Start()
    {
        // Create a temporary reference to the current scene.
		Scene currentScene = SceneManager.GetActiveScene();

		// Retrieve the name of this scene.
		string sceneName = currentScene.name;

		if (sceneName == "Level 1") 
		{
			promptIndex = 0;
            lastIndex = 5;
            progress = 0.20f;
		}
		else if (sceneName == "Level 4")
		{
			promptIndex = 5;
            lastIndex = 10;
            progress = 0.20f;
		}
        else if (sceneName == "Level 5")
		{
			promptIndex = 10;
            lastIndex = 15;
            progress = 0.20f;
		}
        questionsAsked = 0;
        visitedSet = new HashSet<int>();
        nextPrompt();
        ClientDialogue.text = prompts[promptIndex];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator CheckAnswer(List<Product> box)
    {
        bool contains = false;
        Product ans = answers[promptIndex];
        foreach (Product prod in box)
        {
            if ((prod & ans) != 0)
            {
                contains = true;
            } else
            {
                contains = false;
            }
        }
        if (contains) {
            box.Clear();
            ClientDialogue.text = correct[promptIndex];
            progressBar.UpdateProgress(progress);
            yield return new WaitForSeconds(3.0f);
            StartCoroutine(NextClient());
        } else
        {
            box.Clear();
            ClientDialogue.text = incorrect[promptIndex];
            yield return new WaitForSeconds(3.0f);
            StartCoroutine(NextClient());
        }
    }
    
    IEnumerator NextClient()
    {
        questionsAsked +=1;
        // Tentative
        // 5 items each level and progress bar is 75% filled (see function)
        if (questionsAsked == 5 && progressBar.LevelComplete()) {
            wonLevel.SetActive(true);
            yield return new WaitForSeconds(1.5f);
        } else if (questionsAsked == 5) {
            failedLevel.SetActive(true);
            yield return new WaitForSeconds(1.5f);
        }
        nextPrompt();
        client.GetComponent<SpriteRenderer>().sprite = clients[Random.Range(0, 30)];
        ClientDialogue.text = prompts[promptIndex];
    }

    public int numQuestionsAsked() {
        return questionsAsked;
    }

    private void nextPrompt() {
        int randomNumber = Random.Range(0, lastIndex);
        while (visitedSet.Contains(randomNumber) && questionsAsked < 5) {
            randomNumber = Random.Range(0, lastIndex);
        }
        if (questionsAsked < 5) 
        {
            visitedSet.Add(randomNumber);
            promptIndex = randomNumber;
        }
    }
}
