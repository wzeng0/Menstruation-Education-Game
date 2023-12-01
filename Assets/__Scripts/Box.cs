using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public enum Product
    {
        Pad = 0b_0000_0000,  // 0
        Tampon = 0b_0000_0001,  // 1
        Liner = 0b_0000_0010,  // 2
        Cup = 0b_0000_0100,  // 4
        Underwear = 0b_0000_1000,  // 8
        Advil = 0b_0001_0000,  // 16
        Midol = 0b_0010_0000,  // 32
        Tea = 0b_0100_0000,  // 64
        Heatpad = 0b_1000_0000,  // 128
    };

    public List<Product> contents;

    // Start is called before the first frame update
    void Start()
    {
        contents = new List<Product>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("enter!!");
        switch (collision.gameObject.name)
        {
            case "pad":
                contents.Add(Product.Pad);
                break;
            case "tampon":
                contents.Add(Product.Tampon);
                break;
            case "liner":
                contents.Add(Product.Liner);
                break;
            case "cup":
                contents.Add(Product.Cup);
                break;
            case "underwear":
                contents.Add(Product.Underwear);
                break;
            case "advil":
                contents.Add(Product.Advil);
                break;
            case "midol":
                contents.Add(Product.Midol);
                break;
            case "tea":
                contents.Add(Product.Tea);
                break;
            case "heatpad":
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
