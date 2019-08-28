using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChange : MonoBehaviour {
    public GameObject Story;
    public GameObject StoryPressed;
    public GameObject Challenge;
    public GameObject ChallengePressed;
    // Use this for initialization

    private void Start()
    {
        Story.SetActive(false);
        StoryPressed.SetActive(true);
        Challenge.SetActive(true);
        ChallengePressed.SetActive(false);
        PlayerPrefs.SetInt("ChallengeMode", 0);
    }
    public void StoryMode()
    {
        Story.SetActive(false);
        StoryPressed.SetActive(true);
        Challenge.SetActive(true);
        ChallengePressed.SetActive(false);
    }
    public void ChallengeMode()
    {
        Story.SetActive(true);
        StoryPressed.SetActive(false);
        Challenge.SetActive(false);
        ChallengePressed.SetActive(true);
    }
}
