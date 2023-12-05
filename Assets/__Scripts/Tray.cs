using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour
{
    public GameObject product;
    public bool small;
    public bool alive;

    private GameObject spawn;

    // Start is called before the first frame update
    void Start()
    {
        alive = false;   
    }

    private void Update()
    {
        if (alive)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 3;
            spawn.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        }
        
    }

    private void OnMouseDown()
    {
        if (product.name != "nurse" || (product.name == "nurse" && PlayerPrefs.GetInt("NumRef") > 0)) {
            spawn = Instantiate(product, transform.position, Quaternion.identity);
            alive = true;
            if (!small)
            {
                spawn.transform.localScale = new Vector3(0.4f, 0.39f, 1);
            } else
            {
                spawn.transform.localScale = new Vector3(0.1f, 0.1f, 1);
            }
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 3;
            spawn.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        }
    }

    private void OnMouseUp()
    {
        alive = false;
        Destroy(spawn);
    }
}
