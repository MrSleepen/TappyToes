using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalNoise : MonoBehaviour {


    public AudioSource Source;
    public AudioClip[] audiocliparray;
    public int SoundNumber;

    private void Awake()
    {
        Source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Start()
    {
        SoundNumber = PlayerPrefs.GetInt("AnimalNumSave");
        Source.clip = audiocliparray[SoundNumber];
        Source.PlayOneShot(Source.clip);
    }
}
