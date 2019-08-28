using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;

public class LevelManager : MonoBehaviour {

    public GameObject Background;
    public SpriteRenderer Rend;

    private bool HasChoosenSprite;
    public int LevelUnlockNum;
    public int ScoreNeeded;
    public int Level;
    private bool Played = false;
    private float SceneChangeDelay = 1f; // time before changing scenes (for animations to play)
    private float FootVerticalSpeed = -7.5f; // speed foot slides off screen, before switching scenes
    private bool Playing = false;
    private int score;
    public int ChallengeThreshold = 250; // score needed in Challenge Mode to recieve reward
    private int LocalChallengeRewardCount;
    
    //public int BallSpriteNumbers;
   // private int SpriteFlipCounter;

    void Start()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "game");
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName != "MainMenu")
        {
            if (PlayerPrefs.GetInt("HasChosenSprite") == 0)
            {
                HasChoosenSprite = false;
            }
            if (PlayerPrefs.GetInt("HasChosenSprite") == 1)
            {
                HasChoosenSprite = true;
            }
        }
    }

    // Update is called once per frame
    void Update ()
    {
        score = GameManager.Instance.Score;

        if (PlayerPrefs.GetInt("ChallengeMode") == 0) // Story Mode
        {
            //check the score agaist the score needed to win, if it reaches it run victory.
            if (GameManager.Instance.Score >= ScoreNeeded && Played == false)
            {
                // remove slowMotion if active
                GameObject ball = GameObject.Find("Ball");
                ball.GetComponent<AdvancedBall>().NormalMotion();

                GameManager.Instance.ActiveLevel += 1; // allows active level to be updated even if you hit home button
                GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete,"Game",score);
                PlayerPrefs.SetInt("EndMenuActive", 1); // active EndMenu
                PlayerPrefs.SetInt("Victory", 1);
                StartCoroutine(Fadeout());
                StartCoroutine(SceneTransition());
                Invoke("GoEndGame", SceneChangeDelay);
                FootSlideDown();
            }
            else if (GameManager.Instance.lives < 0 && Played == false)
            {
                PlayerPrefs.SetInt("Victory", 0);
                FootSlideDown();
            }
        } // end Story Mode
        else if (PlayerPrefs.GetInt("ChallengeMode") == 1) // Challenge Mode
        {

            //check the score agaist the score needed to win, if it reaches it run victory.
            /* if (GameManager.Instance.Score >= ScoreNeeded && Played == false)
             {
                 PlayerPrefs.SetInt("EndMenuActive", 1); // active EndMenu
                 PlayerPrefs.SetInt("Victory", 1);
                 StartCoroutine(Fadeout());
                 StartCoroutine(SceneTransition());
                 Invoke("GoEndGame", SceneChangeDelay);
                 FootSlideDown();
             }
             else if (GameManager.Instance.lives < 0 && Played == false)
             {
                 PlayerPrefs.SetInt("EndMenuActive", 1); // active EndMenu
                 PlayerPrefs.SetInt("Victory", 0);
                 StartCoroutine(SceneTransition());
                 Invoke("GoEndGame", SceneChangeDelay);
                 FootSlideDown();
             }

             // set the sprite for the animal when set number of kicks is reached.
             if (GameManager.Instance.ScoreResetCounter == 5 && SpriteFlipCounter < 2)
             {

                 if (Playing == false)
                 {
                     StartCoroutine(ChangeSprite());
                     Playing = true;

                 }
             }
             //detect it level has reached end of its sprite list, if so, flip it back to the original
             else if (GameManager.Instance.ScoreResetCounter == 5 && SpriteFlipCounter == 2)
             {
                 if (Playing == false)
                 {
                     StartCoroutine(ChangeSpriteBack());
                     Playing = true;
                 }
             }
             */
            // else if(GameManager.Instance.ScoreResetCounter == 5 && SpriteFlipCounter < 2 && PlayerPrefs.GetInt("HasChosenSprite") == 1)
            //{
            //Debug.Log("ADDEDBUT NO CHANGE");
            // }
            //Set new high SCore per level when new High score is passed
        }
    }

    /*public void SetBallSprite()
    {
        // set the ball sprite to the BallSprite Number
        if (HasChoosenSprite == false)
        {
            PlayerPrefs.SetInt("AnimalNumSave", BallSpriteNumbers);
        }
        if (HasChoosenSprite == true)
        {
            if (BallSpriteNumbers > PlayerPrefs.GetInt("AnimalsUnlocked"))
            {
                PlayerPrefs.SetInt("AnimalsUnlocked", BallSpriteNumbers);
            }
        }

        if (isChallengeMode == false)
        {
            //if the animal sprite set is one that is not unlocked unlock it, checking the number and compairing them
            if (PlayerPrefs.GetInt("AnimalNumSave") > PlayerPrefs.GetInt("AnimalsUnlocked"))
            {
                PlayerPrefs.SetInt("AnimalsUnlocked", PlayerPrefs.GetInt("AnimalNumSave"));
            }
        }
    }
    */

    public void SetHighScore()
    {
        // remove slowMotion if active
        GameObject ball = GameObject.Find("Ball");
        ball.GetComponent<AdvancedBall>().NormalMotion();

        if (PlayerPrefs.GetInt("ChallengeMode") == 0) 
        {
            // Story Mode High Score
            if (Level == 1)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level1Highscore"))
                {
                    PlayerPrefs.SetInt("Level1Highscore", GameManager.Instance.Score);
                }
            }
            else if (Level == 2)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level2Highscore"))
                {
                    PlayerPrefs.SetInt("Level2Highscore", GameManager.Instance.Score);
                }
            }
            else if (Level == 3)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level3Highscore"))
                {
                    PlayerPrefs.SetInt("Level3Highscore", GameManager.Instance.Score);
                }
            }
            else if (Level == 4)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level4Highscore"))
                {
                    PlayerPrefs.SetInt("Level4Highscore", GameManager.Instance.Score);
                }
            }
            else if (Level == 5)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level5Highscore"))
                {
                    PlayerPrefs.SetInt("Level5Highscore", GameManager.Instance.Score);
                }
            }
            else if (Level == 6)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level6Highscore"))
                {
                    PlayerPrefs.SetInt("Level6Highscore", GameManager.Instance.Score);
                }
            }
            else if (Level == 7)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level7Highscore"))
                {
                    PlayerPrefs.SetInt("Level7Highscore", GameManager.Instance.Score);
                }
            }
            else if (Level == 8)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level8Highscore"))
                {
                    PlayerPrefs.SetInt("Level8Highscore", GameManager.Instance.Score);
                }
            }
            else if (Level == 9)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level9Highscore"))
                {
                    PlayerPrefs.SetInt("Level9Highscore", GameManager.Instance.Score);
                }
            }
            else if (Level == 10)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level10Highscore"))
                {
                    PlayerPrefs.SetInt("Level10Highscore", GameManager.Instance.Score);
                }
            }
            else if (Level == 11)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level11Highscore"))
                {
                    PlayerPrefs.SetInt("Level11Highscore", GameManager.Instance.Score);
                }
            }
            else if (Level == 12)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level12Highscore"))
                {
                    PlayerPrefs.SetInt("Level12Highscore", GameManager.Instance.Score);
                }
            }
            else if (Level == 13)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level13Highscore"))
                {
                    PlayerPrefs.SetInt("Level13Highscore", GameManager.Instance.Score);
                }
            }
            else if (Level == 14)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level14Highscore"))
                {
                    PlayerPrefs.SetInt("Level14Highscore", GameManager.Instance.Score);
                }
            }
            else if (Level == 15)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level15Highscore"))
                {
                    PlayerPrefs.SetInt("Level15Highscore", GameManager.Instance.Score);
                }
            }
            else if (Level == 16)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level16Highscore"))
                {
                    PlayerPrefs.SetInt("Level16Highscore", GameManager.Instance.Score);
                }
            }
            else if (Level == 17)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level17Highscore"))
                {
                    PlayerPrefs.SetInt("Level17Highscore", GameManager.Instance.Score);
                }
            }
            else if (Level == 18)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level18Highscore"))
                {
                    PlayerPrefs.SetInt("Level18Highscore", GameManager.Instance.Score);
                }
            }
            else if (Level == 19)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level19Highscore"))
                {
                    PlayerPrefs.SetInt("Level19Highscore", GameManager.Instance.Score);
                }
            }
            else if (Level == 20)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level20Highscore"))
                {
                    PlayerPrefs.SetInt("Level20Highscore", GameManager.Instance.Score);
                }
            }
        }
        else
        {
            // Challenge Mode High Score
            if (Level == 1)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level1HighscoreC"))
                {
                    PlayerPrefs.SetInt("Level1HighscoreC", GameManager.Instance.Score);
                    if (GameManager.Instance.Score >= ChallengeThreshold)
                    {
                        PlayerPrefs.SetInt("Challenge_01", 1);
                    }
                }
            }
            else if (Level == 2)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level2HighscoreC"))
                {
                    PlayerPrefs.SetInt("Level2HighscoreC", GameManager.Instance.Score);
                    if (GameManager.Instance.Score >= ChallengeThreshold)
                    {
                        PlayerPrefs.SetInt("Challenge_02", 1);
                    }
                }
            }
            else if (Level == 3)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level3HighscoreC"))
                {
                    PlayerPrefs.SetInt("Level3HighscoreC", GameManager.Instance.Score);
                    if (GameManager.Instance.Score >= ChallengeThreshold)
                    {
                        PlayerPrefs.SetInt("Challenge_03", 1);
                    }
                }
            }
            else if (Level == 4)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level4HighscoreC"))
                {
                    PlayerPrefs.SetInt("Level4HighscoreC", GameManager.Instance.Score);
                    if (GameManager.Instance.Score >= ChallengeThreshold)
                    {
                        PlayerPrefs.SetInt("Challenge_04", 1);
                    }
                }
            }
            else if (Level == 5)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level5HighscoreC"))
                {
                    PlayerPrefs.SetInt("Level5HighscoreC", GameManager.Instance.Score);
                    if (GameManager.Instance.Score >= ChallengeThreshold)
                    {
                        PlayerPrefs.SetInt("Challenge_05", 1);
                    }
                }
            }
            else if (Level == 6)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level6HighscoreC"))
                {
                    PlayerPrefs.SetInt("Level6HighscoreC", GameManager.Instance.Score);
                    if (GameManager.Instance.Score >= ChallengeThreshold)
                    {
                        PlayerPrefs.SetInt("Challenge_06", 1);
                    }
                }
            }
            else if (Level == 7)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level7HighscoreC"))
                {
                    PlayerPrefs.SetInt("Level7HighscoreC", GameManager.Instance.Score);
                    if (GameManager.Instance.Score >= ChallengeThreshold)
                    {
                        PlayerPrefs.SetInt("Challenge_07", 1);
                    }
                }
            }
            else if (Level == 8)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level8HighscoreC"))
                {
                    PlayerPrefs.SetInt("Level8HighscoreC", GameManager.Instance.Score);
                    if (GameManager.Instance.Score >= ChallengeThreshold)
                    {
                        PlayerPrefs.SetInt("Challenge_08", 1);
                    }
                }
            }
            else if (Level == 9)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level9HighscoreC"))
                {
                    PlayerPrefs.SetInt("Level9HighscoreC", GameManager.Instance.Score);
                    if (GameManager.Instance.Score >= ChallengeThreshold)
                    {
                        PlayerPrefs.SetInt("Challenge_09", 1);
                    }
                }
            }
            else if (Level == 10)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level10HighscoreC"))
                {
                    PlayerPrefs.SetInt("Level10HighscoreC", GameManager.Instance.Score);
                    if (GameManager.Instance.Score >= ChallengeThreshold)
                    {
                        PlayerPrefs.SetInt("Challenge_10", 1);
                    }
                }
            }
            else if (Level == 11)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level11HighscoreC"))
                {
                    PlayerPrefs.SetInt("Level11HighscoreC", GameManager.Instance.Score);
                    if (GameManager.Instance.Score >= ChallengeThreshold)
                    {
                        PlayerPrefs.SetInt("Challenge_11", 1);
                    }
                }
            }
            else if (Level == 12)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level12HighscoreC"))
                {
                    PlayerPrefs.SetInt("Level12HighscoreC", GameManager.Instance.Score);
                    if (GameManager.Instance.Score >= ChallengeThreshold)
                    {
                        PlayerPrefs.SetInt("Challenge_12", 1);
                    }
                }
            }
            else if (Level == 13)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level13HighscoreC"))
                {
                    PlayerPrefs.SetInt("Level13HighscoreC", GameManager.Instance.Score);
                    if (GameManager.Instance.Score >= ChallengeThreshold)
                    {
                        PlayerPrefs.SetInt("Challenge_13", 1);
                    }
                }
            }
            else if (Level == 14)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level14HighscoreC"))
                {
                    PlayerPrefs.SetInt("Level14HighscoreC", GameManager.Instance.Score);
                    if (GameManager.Instance.Score >= ChallengeThreshold)
                    {
                        PlayerPrefs.SetInt("Challenge_14", 1);
                    }
                }
            }
            else if (Level == 15)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level15HighscoreC"))
                {
                    PlayerPrefs.SetInt("Level15HighscoreC", GameManager.Instance.Score);
                    if (GameManager.Instance.Score >= ChallengeThreshold)
                    {
                        PlayerPrefs.SetInt("Challenge_15", 1);
                    }
                }
            }
            else if (Level == 16)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level16HighscoreC"))
                {
                    PlayerPrefs.SetInt("Level16HighscoreC", GameManager.Instance.Score);
                    if (GameManager.Instance.Score >= ChallengeThreshold)
                    {
                        PlayerPrefs.SetInt("Challenge_16", 1);
                    }
                }
            }
            else if (Level == 17)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level17HighscoreC"))
                {
                    PlayerPrefs.SetInt("Level17HighscoreC", GameManager.Instance.Score);
                    if (GameManager.Instance.Score >= ChallengeThreshold)
                    {
                        PlayerPrefs.SetInt("Challenge_17", 1);
                    }
                }
            }
            else if (Level == 18)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level18HighscoreC"))
                {
                    PlayerPrefs.SetInt("Level18HighscoreC", GameManager.Instance.Score);
                    if (GameManager.Instance.Score >= ChallengeThreshold)
                    {
                        PlayerPrefs.SetInt("Challenge_18", 1);
                    }
                }
            }
            else if (Level == 19)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level19HighscoreC"))
                {
                    PlayerPrefs.SetInt("Level19HighscoreC", GameManager.Instance.Score);
                    if (GameManager.Instance.Score >= ChallengeThreshold)
                    {
                        PlayerPrefs.SetInt("Challenge_19", 1);
                    }
                }
            }
            else if (Level == 20)
            {
                if (GameManager.Instance.Score >= PlayerPrefs.GetInt("Level20HighscoreC"))
                {
                    PlayerPrefs.SetInt("Level20HighscoreC", GameManager.Instance.Score);
                    if (GameManager.Instance.Score >= ChallengeThreshold)
                    {
                        PlayerPrefs.SetInt("Challenge_20", 1);
                    }
                }
            }

            UpdateChallengesCompleted();
        }

        // updated unlocked balls
        PlayerPrefs.SetInt("AnimalsUnlocked", PlayerPrefs.GetInt("LevelUnlocked") - 1 + PlayerPrefs.GetInt("ChallengesCompleted") + PlayerPrefs.GetInt("BonusBalls")); // unlock the next ball (plus all the balls from challenge levels, plus all the bonus balls from lv 19/20 or other sources)

    } // end SetHighScore

    private void UpdateChallengesCompleted()
    {
        LocalChallengeRewardCount = 0;

        if (PlayerPrefs.GetInt("Challenge_01") == 1)
        {
            LocalChallengeRewardCount += 1;
        }
        if (PlayerPrefs.GetInt("Challenge_02") == 1)
        {
            LocalChallengeRewardCount += 1;
        }
        if (PlayerPrefs.GetInt("Challenge_03") == 1)
        {
            LocalChallengeRewardCount += 1;
        }
        if (PlayerPrefs.GetInt("Challenge_04") == 1)
        {
            LocalChallengeRewardCount += 1;
        }
        if (PlayerPrefs.GetInt("Challenge_05") == 1)
        {
            LocalChallengeRewardCount += 1;
        }
        if (PlayerPrefs.GetInt("Challenge_06") == 1)
        {
            LocalChallengeRewardCount += 1;
        }
        if (PlayerPrefs.GetInt("Challenge_07") == 1)
        {
            LocalChallengeRewardCount += 1;
        }
        if (PlayerPrefs.GetInt("Challenge_08") == 1)
        {
            LocalChallengeRewardCount += 1;
        }
        if (PlayerPrefs.GetInt("Challenge_09") == 1)
        {
            LocalChallengeRewardCount += 1;
        }
        if (PlayerPrefs.GetInt("Challenge_10") == 1)
        {
            LocalChallengeRewardCount += 1;
        }
        if (PlayerPrefs.GetInt("Challenge_11") == 1)
        {
            LocalChallengeRewardCount += 1;
        }
        if (PlayerPrefs.GetInt("Challenge_12") == 1)
        {
            LocalChallengeRewardCount += 1;
        }
        if (PlayerPrefs.GetInt("Challenge_13") == 1)
        {
            LocalChallengeRewardCount += 1;
        }
        if (PlayerPrefs.GetInt("Challenge_14") == 1)
        {
            LocalChallengeRewardCount += 1;
        }
        if (PlayerPrefs.GetInt("Challenge_15") == 1)
        {
            LocalChallengeRewardCount += 1;
        }
        if (PlayerPrefs.GetInt("Challenge_16") == 1)
        {
            LocalChallengeRewardCount += 1;
        }
        if (PlayerPrefs.GetInt("Challenge_17") == 1)
        {
            LocalChallengeRewardCount += 1;
        }
        if (PlayerPrefs.GetInt("Challenge_18") == 1)
        {
            LocalChallengeRewardCount += 1;
        }
        if (PlayerPrefs.GetInt("Challenge_19") == 1)
        {
            LocalChallengeRewardCount += 1;
        }
        if (PlayerPrefs.GetInt("Challenge_20") == 1)
        {
            LocalChallengeRewardCount += 1;
        }

        // set Challenges Completed
        PlayerPrefs.SetInt("ChallengesCompleted", LocalChallengeRewardCount);
        PlayerPrefs.SetInt("AnimalsUnlocked", PlayerPrefs.GetInt("LevelUnlocked") - 1 + PlayerPrefs.GetInt("ChallengesCompleted") + PlayerPrefs.GetInt("BonusBalls")); // unlock the next ball (plus all the balls from challenge levels, plus all the bonus balls from lv 19/20 or other sources)
    }

    public int GetRequiredScore()
    {
        return ScoreNeeded;
    }

    // VICTORY
    IEnumerator Fadeout()
    {
       Played = true;
        for (float f =1f; f >= -.05f; f -= .1f)
        {
            // slowly reduces the material/ball's alpha value (fade out)
            Color c = Rend.material.color;
            c.a = f;
            Rend.material.color = c;
            yield return new WaitForSeconds (.05f);
        }
        if (PlayerPrefs.GetInt("LevelUnlocked") < LevelUnlockNum) // don't unlock levels if already beat this level (prevents problems if repeating old levels)
        {
            PlayerPrefs.SetInt("LevelUnlocked", LevelUnlockNum); // unlock the next level
            PlayerPrefs.SetInt("AnimalsUnlocked", PlayerPrefs.GetInt("LevelUnlocked") - 1 + PlayerPrefs.GetInt("ChallengesCompleted") + PlayerPrefs.GetInt("BonusBalls")); // unlock the next ball (plus all the balls from challenge levels, plus all the bonus balls from lv 19/20 or other sources)
        }
    }
    
    // moves the background down -8 units, over 1.6 secs
    IEnumerator SceneTransition()
    {
        Played = true;
        for (float f = 1f; f < 30; f += 1f)
        {
            //Debug.Log("Moved");
            Background.transform.Translate(Background.transform.position.x, Background.transform.position.y - 0.05f, Background.transform.position.z);

            yield return new WaitForSeconds(.025f);
        }
    }

    //When this is called from update add to flip count add to sprite number
   /* IEnumerator ChangeSprite()
    {
        SpriteFlipCounter++;
        BallSpriteNumbers++;
        yield return new WaitForSeconds(1f);
        Playing = false;

        GameObject Ball = GameObject.Find("Ball");
        Ball.GetComponent<AdvancedBall>().SetBallProperties();
    }
  
    //if sprite has already changed the set amount this will reset it back to the original sprite and start the rotation over.
    IEnumerator ChangeSpriteBack()
    {
        SpriteFlipCounter = 0;
        BallSpriteNumbers = BallSpriteNumbers -2;
        yield return new WaitForSeconds(1f);
        Playing = false;

        GameObject Ball = GameObject.Find("Ball");
        Ball.GetComponent<AdvancedBall>().SetBallProperties();
    }
    */
   
    // go to end of game screen
    private void GoEndGame() //GoEndGame
    {
        Debug.Log("GoEndGame");
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
   
    //if won or lost move the foot off screen
    private void FootSlideDown()
    {
        GameObject Foot = GameObject.Find("Foot");
        Rigidbody2D FootRB = Foot.GetComponent<Rigidbody2D>();
        FootRB.velocity = new Vector2(0, FootVerticalSpeed);
    }

}
