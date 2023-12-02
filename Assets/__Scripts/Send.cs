using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Send : MonoBehaviour
{
    public GameObject green;
    public Sprite pressed;
    public Sprite regular;

    // Start is called before the first frame update
    void Start()
    {
        
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

    }
}
