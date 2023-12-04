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

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public List<Sprite> clients;
    public GameObject nextLevelButton;

    private string[] prompts = new string[12] {
        "Hi! On my last day and just ran out. Can I get a liner?", 
        "Can I get some Advil? My cramps just started.", 
        "Could I get a menstrual cup? I lost my old one.", 
        "Hey! Can I get a heatpad? I took painkillers already but I'm still feeling some pain.",
        "Do you have an environmentally friendly alternative to pads? I'm doing a zero waste challenge.",
        "Do you have any natural pain relief?",
        "Do you have anything for blood? I've run out of products.",
        "My stomach feels unsettled, is there anything warm to drink?",
        "I just took some Tylenol but it's not working, do you have any other pills for pain?",
        "I hate how messy pads and liners feel, is there anything else I can use for the blood?",
        "I don't feel comfortable with tampons and cups, but I also don't like the texture of pads, is there any alternative?",
        "I feel so nauseous and in pain I can barely stand. Please help!"
    };
    private Product[] answers = new Product[12]
    {
        Product.Liner,
        Product.Advil,
        Product.Cup,
        Product.Heatpad,
        Product.Cup | Product.Underwear,
        Product.Tea | Product.Heatpad,
        Product.Pad | Product.Tampon | Product.Liner | Product.Cup | Product.Underwear,
        Product.Tea,
        Product.Advil,
        Product.Tampon | Product.Cup,
        Product.Underwear,
        Product.Referral
    };
    private string[] correct = new string[12]
    {
        "Thanks! That's just what I needed.",
        "Awesome, see ya!",
        "Cool, have a nice day!",
        "Thank you :)",
        "Great, thank you!",
        "Nice! Bye!",
        "You're a lifesaver, thanks!",
        "That's perfect!",
        "Amazing, thank you!",
        "Thanks! I'll try it out.",
        "Wow, I never heard of these. Thanks!",
        "Thank you..."
    };
    private string[] incorrect = new string[12]
    {
        "I was hoping for just a liner, but thank you.",
        "Oh I just wanted some Advil, but thanks.",
        "I wanted a cup, but thanks anyway.",
        "D: I guess there were no more heatpads.",
        "Was hoping you would have some cups or period underwear, but thanks anyways!",
        "Oh, I thought y'all might have some tea or heatpads or something.",
        "Guess y'all didn't have anymore either.",
        "Ah, I was hoping there'd be tea or hot water. Thanks though, bye.",
        "Oh, guess there's no more Advil. I'll try to go home early.",
        "That's not what I needed. (Tampons or cup)",
        "Thought y'all might have some period underwear. Thanks tho!",
        "Thanks, but can I see the nurse? I don't think I can go back to class."
    };

    private int promptIndex = 0;

    private void Awake()
    {
        heart1.gameObject.SetActive(false);
        heart2.gameObject.SetActive(false);
        heart3.gameObject.SetActive(false);
        // Initially disable the button and set the canvas group to be interactable
        nextLevelButton.SetActive(false);
    }

    void Start()
    {
        // Create a temporary reference to the current scene.
		Scene currentScene = SceneManager.GetActiveScene();

		// Retrieve the name of this scene.
		string sceneName = currentScene.name;

		if (sceneName == "Easy") 
		{
			promptIndex = 0;
		}
		else if (sceneName == "Hard")
		{
			promptIndex = 4;
		}
        else if (sceneName == "Intermediate")
		{
			promptIndex = 8;
		}
        ClientDialogue.text = prompts[promptIndex];
    }

    // Update is called once per frame
    void Update()
    {
        float randomNumber = Random.Range(0, 9);
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
            HeartAwake();
            yield return new WaitForSeconds(3.0f);
            StartCoroutine(NextClient());
        } else
        {
            box.Clear();
            ClientDialogue.text = incorrect[promptIndex];
            heart1.gameObject.SetActive(true);
            yield return new WaitForSeconds(3.0f);
            StartCoroutine(NextClient());
        }
    }
    
    IEnumerator NextClient()
    {
        promptIndex += 1;
        if (promptIndex == 4) {
            // Enable the button and disable the canvas group when the level is completed
            nextLevelButton.SetActive(true);
            yield return new WaitForSeconds(2.0f);
            SceneManager.LoadScene("Menu");
        }
        if (promptIndex == 12)
        {
            // minigame finished, go to score screen
        }
        client.GetComponent<SpriteRenderer>().sprite = clients[Random.Range(0, 30)];
        ClientDialogue.text = prompts[promptIndex];
        HeartAsleep();
    }

    void HeartAwake()
    {
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
    }

    void HeartAsleep()
    {
        heart1.gameObject.SetActive(false);
        heart2.gameObject.SetActive(false);
        heart3.gameObject.SetActive(false);
    }
}
