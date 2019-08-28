using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
    private bool Played = false;
    public AudioSource Source;
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount >= 1 && Played == false)
        {
            Source.Play();
            Played = true;
        }

    }
}
