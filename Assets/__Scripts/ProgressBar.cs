using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    private float targetProgress = 0;
    private float increment = 0.0025f;

    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    void Update()
    {
        if (slider.value < targetProgress) {
            slider.value += increment;
        }
    }

    public void UpdateProgress(float value)
    {
        targetProgress += value;
    }
    public bool LevelComplete() {
        if (slider.value == 1) {
            return true;
        }
        return false;
    }
}
