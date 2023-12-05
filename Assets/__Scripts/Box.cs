using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Product
{
    Pad = 0b_0000_0001,  // 0
    Tampon = 0b_0000_0010,  // 2
    Liner = 0b_0000_0100,  // 4
    Cup = 0b_0000_1000,  // 8
    Underwear = 0b_0001_0000,  // 16
    Advil = 0b_0010_0000,  // 32
    Tylenol = 0b_0100_0000,  // 64
    Tea = 0b_1000_0000,  // 128
    Heatpad = 0b_0001_1000_0000,  // 256
    Referral = 0b_0010_1000_0000 // 512
};

public class Box : MonoBehaviour
{

    public static List<Product> contents;

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
                contents.Remove(Product.Pad);
                contents.Add(Product.Pad);
                break;
            case "tampon(Clone)":
                contents.Remove(Product.Tampon);
                contents.Add(Product.Tampon);
                break;
            case "liner(Clone)":
                contents.Remove(Product.Liner);
                contents.Add(Product.Liner);
                break;
            case "cup(Clone)":
                contents.Remove(Product.Cup);
                contents.Add(Product.Cup);
                break;
            case "underwear(Clone)":
                contents.Remove(Product.Underwear);
                contents.Add(Product.Underwear);
                break;
            case "advil(Clone)":
                contents.Remove(Product.Advil);
                contents.Add(Product.Advil);
                break;
            case "tylenol(Clone)":
                contents.Remove(Product.Tylenol);
                contents.Add(Product.Tylenol);
                break;
            case "tea(Clone)":
                contents.Remove(Product.Tea);
                contents.Add(Product.Tea);
                break;
            case "heatpad(Clone)":
                contents.Remove(Product.Heatpad);
                contents.Add(Product.Heatpad);
                break;
            case "nurse(Clone)":
                // Retrieve the current value from PlayerPrefs
                int currentValue = PlayerPrefs.GetInt("NumRef", 0);

                // Decrement the value
                currentValue--;
                // Save the decremented value back to PlayerPrefs
                PlayerPrefs.SetInt("NumRef", currentValue);
                PlayerPrefs.Save();

                contents.Remove(Product.Referral);
                contents.Add(Product.Referral);
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
