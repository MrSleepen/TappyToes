using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundMuter : MonoBehaviour
{
    // Sets volume to 0% or 100% based on SoundNumSave, see SoundToggle.cs for more info
	
	void Update ()
    {
 
        if (PlayerPrefs.GetInt("SoundNumSave") == 0)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
	}

}
