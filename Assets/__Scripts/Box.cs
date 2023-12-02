using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Product
{
    Pad = 0b_0000_0000,  // 0
    Tampon = 0b_0000_0001,  // 1
    Liner = 0b_0000_0010,  // 2
    Cup = 0b_0000_0100,  // 4
    Underwear = 0b_0000_1000,  // 8
    Advil = 0b_0001_0000,  // 16
    Tylenol = 0b_0010_0000,  // 32
    Tea = 0b_0100_0000,  // 64
    Heatpad = 0b_1000_0000,  // 128
};

public class Box : MonoBehaviour
{

    public List<Product> contents;

    // Start is called before the first frame update
    void Start()
    {
        contents = new List<Product>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "pad(Clone)":
                contents.Add(Product.Pad);
                break;
            case "tampon(Clone)":
                contents.Add(Product.Tampon);
                break;
            case "liner(Clone)":
                contents.Add(Product.Liner);
                break;
            case "cup(Clone)":
                contents.Add(Product.Cup);
                break;
            case "underwear(Clone)":
                contents.Add(Product.Underwear);
                break;
            case "advil(Clone)":
                contents.Add(Product.Advil);
                break;
            case "tylenol(Clone)":
                contents.Add(Product.Tylenol);
                break;
            case "tea(Clone)":
                contents.Add(Product.Tea);
                break;
            case "heatpad(Clone)":
                contents.Add(Product.Heatpad);
                break;
            default:
                Debug.Log("unexpected item in bagging area: " + collision.gameObject.name);
                break;
        }
        if (collision.gameObject.name.Equals("pad"))
        {
            contents.Add(Product.Pad);
        }
    }
}
