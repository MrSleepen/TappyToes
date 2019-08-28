using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   
using TMPro;            // required for TMP_Text

public class PerformanceSetting : MonoBehaviour {

    public TMP_Text SaveBattery;
    public TMP_Text Performance;
    public TMP_Text Button; // FPS

    void Start()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        if (PlayerPrefs.GetInt("BatterySaver") == 1) // ON
        {
            SaveBattery.alpha = 1f;
            Performance.alpha = 0.5f;
            Button.text = "30";
        }
        else // OFF
        {
            SaveBattery.alpha = 0.5f;
            Performance.alpha = 1f;
            Button.text = "60";
        }
    }

}
