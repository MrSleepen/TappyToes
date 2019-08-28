using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Environment : MonoBehaviour {

    // AudioSources
    public AudioSource Audio_BackgroundMusic;


    void Start () {
        Audio_BackgroundMusic.volume = 0.20f; // percent of normal background volume
        Audio_BackgroundMusic.Play();
    }
	
}
