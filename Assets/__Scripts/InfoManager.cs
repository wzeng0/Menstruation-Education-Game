using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoManager : MonoBehaviour
{
    public TMP_Text ClientDialogue;
    public GameObject client;
    public GameObject box;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    private string[] prompts = new string[4] { 
        "Hi! On my last day and just ran out. Can I get a liner?", 
        "Can I get some Advil? My cramps just started.", 
        "Could I get a menstrual cup? I lost my old one.", 
        "Hey! Can I get a heat pack? I took painkillers already but I'm still feeling some pain." 
    };
    private Product[] answers = new Product[4]
    {
        Product.Liner,
        Product.Advil,
        Product.Cup,
        Product.Heatpad
    };

    private int promptIndex = 0;

    private void Awake()
    {
        heart1.gameObject.SetActive(false);
        heart2.gameObject.SetActive(false);
        heart3.gameObject.SetActive(false);
    }

    void Start()
    {
        ClientDialogue.text = prompts[promptIndex];
    }

    // Update is called once per frame
    void Update()
    {
        float randomNumber = Random.Range(0, 9);
    }

    void CheckAnswer()
    {

    }
    
    void NextClient()
    {

    }
}
