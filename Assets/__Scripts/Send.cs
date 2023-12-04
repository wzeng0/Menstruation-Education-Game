using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Send : MonoBehaviour
{
    public GameObject green;
    public Sprite pressed;
    public Sprite regular;
    public GameObject cameraObject;
    InfoManager IM;

    // Start is called before the first frame update
    void Start()
    {
        IM = FindObjectOfType<InfoManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        green.GetComponent<SpriteRenderer>().sprite = pressed;
    }

    private void OnMouseUp()
    {
        green.GetComponent<SpriteRenderer>().sprite = regular;
        if (IM.numQuestionsAsked() != 5) {
            StartCoroutine(cameraObject.GetComponent<InfoManager>().CheckAnswer(Box.contents));
        }
    }
}
