using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   
using TMPro;            // required for TMP_Text

public class LevelIndicator : MonoBehaviour {

    public TMP_Text Level;

    public void UpdateLevelIndicator()
    {
        Level.text = PlayerPrefs.GetInt("ActiveLevel").ToString();
    }

}
