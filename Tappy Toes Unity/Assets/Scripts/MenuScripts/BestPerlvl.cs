using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestPerlvl : MonoBehaviour {

    public Text TEXT;
    public int Level;
    public GameObject Goal;
    public int ChallengeModeTog;

    // depending on the level set the text to the high score of that level. 
    void Update () {
        ChallengeModeTog = PlayerPrefs.GetInt("ChallengeMode");
        if (Level == 1)
        {
            if (ChallengeModeTog == 0)
            {
                TEXT.text = PlayerPrefs.GetInt("Level1Highscore").ToString();
                Goal.SetActive(true);
            }
            else if (ChallengeModeTog == 1)
            {
                TEXT.text = PlayerPrefs.GetInt("Level1HighscoreC").ToString();
                Goal.SetActive(false);
            }
        }

         if (Level == 2)
        {
            if (ChallengeModeTog == 0)
            {
                TEXT.text = PlayerPrefs.GetInt("Level2Highscore").ToString();
                Goal.SetActive(true);
            }
            else if (ChallengeModeTog == 1)
            {
                TEXT.text = PlayerPrefs.GetInt("Level2HighscoreC").ToString();
                Goal.SetActive(false);
            }
        }
        if (Level == 3)
        {
            if (ChallengeModeTog == 0)
            {
                TEXT.text = PlayerPrefs.GetInt("Level3Highscore").ToString();
                Goal.SetActive(true);
            }
            else if (ChallengeModeTog == 1)
            {
                TEXT.text = PlayerPrefs.GetInt("Level3HighscoreC").ToString();
                Goal.SetActive(false);
            }
        }
        if (Level == 4)
        {
            if (ChallengeModeTog == 0)
            {
                TEXT.text = PlayerPrefs.GetInt("Level4Highscore").ToString();
                Goal.SetActive(true);
            }
            else if (ChallengeModeTog == 1)
            {
                TEXT.text = PlayerPrefs.GetInt("Level4HighscoreC").ToString();
                Goal.SetActive(false);
            }
        }
        if (Level == 5)
        {
            if (ChallengeModeTog == 0)
            {
                TEXT.text = PlayerPrefs.GetInt("Level5Highscore").ToString();
                Goal.SetActive(true);
            }
            else if (ChallengeModeTog == 1)
            {
                TEXT.text = PlayerPrefs.GetInt("Level5HighscoreC").ToString();
                Goal.SetActive(false);
            }
        }
        if (Level == 6)
        {
            if (ChallengeModeTog == 0)
            {
                TEXT.text = PlayerPrefs.GetInt("Level6Highscore").ToString();
                Goal.SetActive(true);
            }
            else if (ChallengeModeTog == 1)
            {
                TEXT.text = PlayerPrefs.GetInt("Level6HighscoreC").ToString();
                Goal.SetActive(false);
            }
        }
        if (Level == 7)
        {
            if (ChallengeModeTog == 0)
            {
                TEXT.text = PlayerPrefs.GetInt("Level7Highscore").ToString();
                Goal.SetActive(true);
            }
            else if (ChallengeModeTog == 1)
            {
                TEXT.text = PlayerPrefs.GetInt("Level7HighscoreC").ToString();
                Goal.SetActive(false);
            }
        }
        if (Level == 8)
        {
            if (ChallengeModeTog == 0)
            {
                TEXT.text = PlayerPrefs.GetInt("Level8Highscore").ToString();
                Goal.SetActive(true);
            }
            else if (ChallengeModeTog == 1)
            {
                TEXT.text = PlayerPrefs.GetInt("Level8HighscoreC").ToString();
                Goal.SetActive(false);
            }
        }
        if (Level == 9)
        {
            if (ChallengeModeTog == 0)
            {
                TEXT.text = PlayerPrefs.GetInt("Level9Highscore").ToString();
                Goal.SetActive(true);
            }
            else if (ChallengeModeTog == 1)
            {
                TEXT.text = PlayerPrefs.GetInt("Level9HighscoreC").ToString();
                Goal.SetActive(false);
            }
        }
        if (Level == 10)
        {
            if (ChallengeModeTog == 0)
            {
                TEXT.text = PlayerPrefs.GetInt("Level10Highscore").ToString();
                Goal.SetActive(true);
            }
            else if (ChallengeModeTog == 1)
            {
                TEXT.text = PlayerPrefs.GetInt("Level10HighscoreC").ToString();
                Goal.SetActive(false);
            }
        }
        if (Level == 11)
        {
            if (ChallengeModeTog == 0)
            {
                TEXT.text = PlayerPrefs.GetInt("Level11Highscore").ToString();
                Goal.SetActive(true);
            }
            else if (ChallengeModeTog == 1)
            {
                TEXT.text = PlayerPrefs.GetInt("Level11HighscoreC").ToString();
                Goal.SetActive(false);
            }
        }
        if (Level == 12)
        {
            if (ChallengeModeTog == 0)
            {
                TEXT.text = PlayerPrefs.GetInt("Level12Highscore").ToString();
                Goal.SetActive(true);
            }
            else if (ChallengeModeTog == 1)
            {
                TEXT.text = PlayerPrefs.GetInt("Level12HighscoreC").ToString();
                Goal.SetActive(false);
            }
        }
        if (Level == 13)
        {
            if (ChallengeModeTog == 0)
            {
                TEXT.text = PlayerPrefs.GetInt("Level13Highscore").ToString();
                Goal.SetActive(true);
            }
            else if (ChallengeModeTog == 1)
            {
                TEXT.text = PlayerPrefs.GetInt("Level13HighscoreC").ToString();
                Goal.SetActive(false);
            }
        }
        if (Level == 14)
        {
            if (ChallengeModeTog == 0)
            {
                TEXT.text = PlayerPrefs.GetInt("Level14Highscore").ToString();
                Goal.SetActive(true);
            }
            else if (ChallengeModeTog == 1)
            {
                TEXT.text = PlayerPrefs.GetInt("Level14HighscoreC").ToString();
                Goal.SetActive(false);
            }
        }
        if (Level == 15)
        {
            if (ChallengeModeTog == 0)
            {
                TEXT.text = PlayerPrefs.GetInt("Level15Highscore").ToString();
                Goal.SetActive(true);
            }
            else if (ChallengeModeTog == 1)
            {
                TEXT.text = PlayerPrefs.GetInt("Level15HighscoreC").ToString();
                Goal.SetActive(false);
            }
        }
        if (Level == 16)
        {
            if (ChallengeModeTog == 0)
            {
                TEXT.text = PlayerPrefs.GetInt("Level16Highscore").ToString();
                Goal.SetActive(true);
            }
            else if (ChallengeModeTog == 1)
            {
                TEXT.text = PlayerPrefs.GetInt("Level16HighscoreC").ToString();
                Goal.SetActive(false);
            }
        }
        if (Level == 17)
        {
            if (ChallengeModeTog == 0)
            {
                TEXT.text = PlayerPrefs.GetInt("Level17Highscore").ToString();
                Goal.SetActive(true);
            }
            else if (ChallengeModeTog == 1)
            {
                TEXT.text = PlayerPrefs.GetInt("Level17HighscoreC").ToString();
                Goal.SetActive(false);
            }
        }
        if (Level == 18)
        {
            if (ChallengeModeTog == 0)
            {
                TEXT.text = PlayerPrefs.GetInt("Level18Highscore").ToString();
                Goal.SetActive(true);
            }
            else if (ChallengeModeTog == 1)
            {
                TEXT.text = PlayerPrefs.GetInt("Level18HighscoreC").ToString();
                Goal.SetActive(false);
            }
        }
        if (Level == 19)
        {
            if (ChallengeModeTog == 0)
            {
                TEXT.text = PlayerPrefs.GetInt("Level19Highscore").ToString();
                Goal.SetActive(true);
            }
            else if (ChallengeModeTog == 1)
            {
                TEXT.text = PlayerPrefs.GetInt("Level19HighscoreC").ToString();
                Goal.SetActive(false);
            }
        }
        if (Level == 20)
        {
            if (ChallengeModeTog == 0)
            {
                TEXT.text = PlayerPrefs.GetInt("Level20Highscore").ToString();
                Goal.SetActive(true);
            }
            else if (ChallengeModeTog == 1)
            {
                TEXT.text = PlayerPrefs.GetInt("Level20HighscoreC").ToString();
                Goal.SetActive(false);
            }
        }


    }
	
}
