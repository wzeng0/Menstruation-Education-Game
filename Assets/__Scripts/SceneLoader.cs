using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad;

    // Call this method to load the specified scene
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}