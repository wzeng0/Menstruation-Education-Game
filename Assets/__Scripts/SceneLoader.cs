using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad;
    public string currentDay;

    // Call this method to load the specified scene
    public void LoadScene()
    {
        PlayerPrefs.SetString("Day", currentDay);
        SceneManager.LoadScene(sceneToLoad);
    }
}