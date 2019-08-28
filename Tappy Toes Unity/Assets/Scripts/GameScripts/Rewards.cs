using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rewards : MonoBehaviour {

    public GameObject Canvas;
    public GameObject RewardIcon;
    public GameObject Ball_Obj;

    public Sprite[] FootImages;
    public Sprite[] ShoeImages;
    public Sprite[] BallImages;
    public Sprite DefaultImage;

    private int UnlockedType = 0;


    public void DetermineReward()
    {
        switch (GameManager.Instance.ActiveLevel)
        {
            case 1:
                if (GameManager.Instance.BirdGift_01 == 0) // haven't unlocked reward yet
                {
                    GameManager.Instance.BirdGift_01 = 1; // Unlocks reward for this level
                    PlayerPrefs.SetInt("BirdGift_01", 1); // Unlocks reward for this level
                    GetReward(); // Set Reward and display it to screen
                }
                else // already unlocked reward for this level
                {
                    GetLife(); // Give Life and display it on screen
                }
                break;

            case 2:
                if (GameManager.Instance.BirdGift_02 == 0) // haven't unlocked reward yet
                {
                    GameManager.Instance.BirdGift_02 = 1; // Unlocks reward for this level
                    PlayerPrefs.SetInt("BirdGift_02", 1); // Unlocks reward for this level
                    GetReward(); // Set Reward and display it to screen
                }
                else // already unlocked reward for this level
                {
                    GetLife(); // Give Life and display it on screen
                }
                break;

            case 3:
                if (GameManager.Instance.BirdGift_03 == 0) // haven't unlocked reward yet
                {
                    GameManager.Instance.BirdGift_03 = 1; // Unlocks reward for this level
                    PlayerPrefs.SetInt("BirdGift_03", 1); // Unlocks reward for this level
                    GetReward(); // Set Reward and display it to screen
                }
                else // already unlocked reward for this level
                {
                    GetLife(); // Give Life and display it on screen
                }
                break;

            case 4:
                if (GameManager.Instance.BirdGift_04 == 0) // haven't unlocked reward yet
                {
                    GameManager.Instance.BirdGift_04 = 1; // Unlocks reward for this level
                    PlayerPrefs.SetInt("BirdGift_04", 1); // Unlocks reward for this level
                    GetReward(); // Set Reward and display it to screen
                }
                else // already unlocked reward for this level
                {
                    GetLife(); // Give Life and display it on screen
                }
                break;

            case 5:
                if (GameManager.Instance.BirdGift_05 == 0) // haven't unlocked reward yet
                {
                    GameManager.Instance.BirdGift_05 = 1; // Unlocks reward for this level
                    PlayerPrefs.SetInt("BirdGift_05", 1); // Unlocks reward for this level
                    GetReward(); // Set Reward and display it to screen
                }
                else // already unlocked reward for this level
                {
                    GetLife(); // Give Life and display it on screen
                }
                break;

            case 6:
                if (GameManager.Instance.BirdGift_06 == 0) // haven't unlocked reward yet
                {
                    GameManager.Instance.BirdGift_06 = 1; // Unlocks reward for this level
                    PlayerPrefs.SetInt("BirdGift_06", 1); // Unlocks reward for this level
                    GetReward(); // Set Reward and display it to screen
                }
                else // already unlocked reward for this level
                {
                    GetLife(); // Give Life and display it on screen
                }
                break;

            case 7:
                if (GameManager.Instance.BirdGift_07 == 0) // haven't unlocked reward yet
                {
                    GameManager.Instance.BirdGift_07 = 1; // Unlocks reward for this level
                    PlayerPrefs.SetInt("BirdGift_07", 1); // Unlocks reward for this level
                    GetReward(); // Set Reward and display it to screen
                }
                else // already unlocked reward for this level
                {
                    GetLife(); // Give Life and display it on screen
                }
                break;

            case 8:
                if (GameManager.Instance.BirdGift_08 == 0) // haven't unlocked reward yet
                {
                    GameManager.Instance.BirdGift_08 = 1; // Unlocks reward for this level
                    PlayerPrefs.SetInt("BirdGift_08", 1); // Unlocks reward for this level
                    GetReward(); // Set Reward and display it to screen
                }
                else // already unlocked reward for this level
                {
                    GetLife(); // Give Life and display it on screen
                }
                break;

            case 9:
                if (GameManager.Instance.BirdGift_09 == 0) // haven't unlocked reward yet
                {
                    GameManager.Instance.BirdGift_09 = 1; // Unlocks reward for this level
                    PlayerPrefs.SetInt("BirdGift_09", 1); // Unlocks reward for this level
                    GetReward(); // Set Reward and display it to screen
                }
                else // already unlocked reward for this level
                {
                    GetLife(); // Give Life and display it on screen
                }
                break;

            case 10:
                if (GameManager.Instance.BirdGift_10 == 0) // haven't unlocked reward yet
                {
                    GameManager.Instance.BirdGift_10 = 1; // Unlocks reward for this level
                    PlayerPrefs.SetInt("BirdGift_10", 1); // Unlocks reward for this level
                    GetReward(); // Set Reward and display it to screen
                }
                else // already unlocked reward for this level
                {
                    GetLife(); // Give Life and display it on screen
                }
                break;

            case 11:
                if (GameManager.Instance.BirdGift_11 == 0) // haven't unlocked reward yet
                {
                    GameManager.Instance.BirdGift_11 = 1; // Unlocks reward for this level
                    PlayerPrefs.SetInt("BirdGift_11", 1); // Unlocks reward for this level
                    GetReward(); // Set Reward and display it to screen
                }
                else // already unlocked reward for this level
                {
                    GetLife(); // Give Life and display it on screen
                }
                break;

            case 12:
                if (GameManager.Instance.BirdGift_12 == 0) // haven't unlocked reward yet
                {
                    GameManager.Instance.BirdGift_12 = 1; // Unlocks reward for this level
                    PlayerPrefs.SetInt("BirdGift_12", 1); // Unlocks reward for this level
                    GetReward(); // Set Reward and display it to screen
                }
                else // already unlocked reward for this level
                {
                    GetLife(); // Give Life and display it on screen
                }
                break;

            case 13:
                if (GameManager.Instance.BirdGift_13 == 0) // haven't unlocked reward yet
                {
                    GameManager.Instance.BirdGift_13 = 1; // Unlocks reward for this level
                    PlayerPrefs.SetInt("BirdGift_13", 1); // Unlocks reward for this level
                    GetReward(); // Set Reward and display it to screen
                }
                else // already unlocked reward for this level
                {
                    GetLife(); // Give Life and display it on screen
                }
                break;

            case 14:
                if (GameManager.Instance.BirdGift_14 == 0) // haven't unlocked reward yet
                {
                    GameManager.Instance.BirdGift_14 = 1; // Unlocks reward for this level
                    PlayerPrefs.SetInt("BirdGift_14", 1); // Unlocks reward for this level
                    GetReward(); // Set Reward and display it to screen
                }
                else // already unlocked reward for this level
                {
                    GetLife(); // Give Life and display it on screen
                }
                break;

            case 15:
                if (GameManager.Instance.BirdGift_15 == 0) // haven't unlocked reward yet
                {
                    GameManager.Instance.BirdGift_15 = 1; // Unlocks reward for this level
                    PlayerPrefs.SetInt("BirdGift_15", 1); // Unlocks reward for this level
                    GetReward(); // Set Reward and display it to screen
                }
                else // already unlocked reward for this level
                {
                    GetLife(); // Give Life and display it on screen
                }
                break;

            case 16:
                if (GameManager.Instance.BirdGift_16 == 0) // haven't unlocked reward yet
                {
                    GameManager.Instance.BirdGift_16 = 1; // Unlocks reward for this level
                    PlayerPrefs.SetInt("BirdGift_16", 1); // Unlocks reward for this level
                    GetReward(); // Set Reward and display it to screen
                }
                else // already unlocked reward for this level
                {
                    GetLife(); // Give Life and display it on screen
                }
                break;

            case 17:
                if (GameManager.Instance.BirdGift_17 == 0) // haven't unlocked reward yet
                {
                    GameManager.Instance.BirdGift_17 = 1; // Unlocks reward for this level
                    PlayerPrefs.SetInt("BirdGift_17", 1); // Unlocks reward for this level
                    GetReward(); // Set Reward and display it to screen
                }
                else // already unlocked reward for this level
                {
                    GetLife(); // Give Life and display it on screen
                }
                break;

            case 18:
                if (GameManager.Instance.BirdGift_18 == 0) // haven't unlocked reward yet
                {
                    GameManager.Instance.BirdGift_18 = 1; // Unlocks reward for this level
                    PlayerPrefs.SetInt("BirdGift_18", 1); // Unlocks reward for this level
                    GetReward(); // Set Reward and display it to screen
                }
                else // already unlocked reward for this level
                {
                    GetLife(); // Give Life and display it on screen
                }
                break;

            case 19: // ALTERNATIVE REWARD (No more foot/shoe skins left)
                if (GameManager.Instance.BirdGift_19 == 0) // haven't unlocked reward yet
                {
                    // Set this reward to being unlocked (so it can't be unlocked again)
                    GameManager.Instance.BirdGift_19 = 1; 
                    PlayerPrefs.SetInt("BirdGift_19", 1);

                    // unlock a new ball (instead of foot/shoe)
                    PlayerPrefs.SetInt("BonusBalls", PlayerPrefs.GetInt("BonusBalls") + 1);
                    Debug.Log("BonusBalls " + PlayerPrefs.GetInt("BonusBalls"));

                    // display reward on screen
                    DisplayChallengeReward(); 
                }
                else // already unlocked reward for this level
                {
                    GetLife(); // Give Life and display it on screen
                }
                break;

            case 20: // ALTERNATIVE REWARD (No more foot/shoe skins left)
                if (GameManager.Instance.BirdGift_20 == 0) // haven't unlocked reward yet
                {
                    // Set this reward to being unlocked (so it can't be unlocked again)
                    GameManager.Instance.BirdGift_19 = 1;
                    PlayerPrefs.SetInt("BirdGift_19", 1);

                    // unlock a new ball (instead of foot/shoe)
                    PlayerPrefs.SetInt("BonusBalls", PlayerPrefs.GetInt("BonusBalls") + 1);
                    Debug.Log("BonusBalls " + PlayerPrefs.GetInt("BonusBalls"));

                    // display reward on screen
                    DisplayChallengeReward();
                }
                else // already unlocked reward for this level
                {
                    GetLife(); // Give Life and display it on screen
                }
                break;

            default:
                Debug.Log("ERROR: Invalid Active Level, it may have been incorrectly set");
                break;
        }
    }

    // GIVE LIFE, if Cosmetic was already Unlocked
    private void GetLife()
    {
        // Gain a life
        GameManager.Instance.lives += 1;

        // Set the reward
        Image RewardIconImg = RewardIcon.GetComponent<Image>();
        RewardIconImg.sprite = DefaultImage; // "Heart+1" Image

        // Display the reward
        GameObject Reward_Obj = Canvas.transform.Find("Reward").gameObject;
        Reward_Obj.SetActive(true);
    }

    // GIVE COSMETIC
    private void GetReward()
    {
        // UNLOCK REWARD -----------------------------------------------------------------------
        // -------------------------------------------------------------------------------------
        int rand = Random.Range(0, 2); // 0 and 1 (doesn't include 2) 

        if (rand == 0) // Prioritize unlocking FOOT
        {
            if (PlayerPrefs.GetInt("FootUnlocked") <= PlayerPrefs.GetInt("ShoeUnlocked"))
            {
                UnlockedType = 1;
                PlayerPrefs.SetInt("FootUnlocked", PlayerPrefs.GetInt("FootUnlocked") + 1); // unlock Foot, increment FootUnlocked Int
            }
            else // FootUnlocked > ShoeUnlocked
            {
                UnlockedType = 2;
                PlayerPrefs.SetInt("ShoeUnlocked", PlayerPrefs.GetInt("ShoeUnlocked") + 1); // unlock Shoe, increment ShoeUnlocked Int
            }
        }
        else // (rand == 1) // Prioritize unlocking SHOE
        {
            if (PlayerPrefs.GetInt("ShoeUnlocked") <= PlayerPrefs.GetInt("FootUnlocked"))
            {
                UnlockedType = 2;
                PlayerPrefs.SetInt("ShoeUnlocked", PlayerPrefs.GetInt("ShoeUnlocked") + 1); // unlock Shoe, increment ShoeUnlocked Int
            }
            else // ShoeUnlocked > FootUnlocked
            {
                UnlockedType = 1;
                PlayerPrefs.SetInt("FootUnlocked", PlayerPrefs.GetInt("FootUnlocked") + 1); // unlock Foot, increment FootUnlocked Int
            }
        }
        // -------------------------------------------------------------------------------------

        // DISPLAY REWARD ----------------------------------------------------------------------
        // -------------------------------------------------------------------------------------
        Image RewardIconImg = RewardIcon.GetComponent<Image>();

        // Set the reward image
        if (UnlockedType == 1) // Foot
        {
            RewardIconImg.sprite = FootImages[PlayerPrefs.GetInt("FootUnlocked")];
        }
        else if (UnlockedType == 2) // Shoe
        {
            RewardIconImg.sprite = ShoeImages[PlayerPrefs.GetInt("ShoeUnlocked")];
        }
        else // UnlockedType == 0 (Life)
        {
            RewardIconImg.sprite = DefaultImage; // Heart+1 Image
            Debug.Log("ERROR: UnlockedType == 0 (reward = life), while should be recieving a reward (Foot/Shoe)");
        }

        // Display the image on screen
        GameObject Reward_Obj = Canvas.transform.Find("Reward").gameObject;
        Reward_Obj.SetActive(true);
        // -------------------------------------------------------------------------------------

        // UPDATE SKINS ------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------
        
        // Set FOOT SKIN
        if (PlayerPrefs.GetInt("HasChosenFoot") == 0)
        {
            // set Foot sprite
            GameManager.Instance.FootNum = PlayerPrefs.GetInt("FootUnlocked");
            PlayerPrefs.SetInt("FootNum", GameManager.Instance.FootNum);
            PlayerPrefs.SetInt("FootNumSave", GameManager.Instance.FootNum);
        }

        // Set SHOE SKIN
        if (PlayerPrefs.GetInt("HasChosenShoe") == 0)
        {
            // set Shoe sprite
            GameManager.Instance.ShoeNum = PlayerPrefs.GetInt("ShoeUnlocked");
            PlayerPrefs.SetInt("ShoeNum", GameManager.Instance.ShoeNum);
            PlayerPrefs.SetInt("ShoeNumSave", GameManager.Instance.ShoeNum);
        }
        // -------------------------------------------------------------------------------------
    }

    public void DisplayChallengeReward()
    {
        Image RewardIconImg = RewardIcon.GetComponent<Image>();

        RewardIconImg.sprite = BallImages[PlayerPrefs.GetInt("AnimalsUnlocked") +1];

        // Display the image on screen
        GameObject Reward_Obj = Canvas.transform.Find("Reward").gameObject;
        Reward_Obj.SetActive(true);
    }

    public void RemoveChallengeDisplay()
    {
        // Display the image on screen
        GameObject Reward_Obj = Canvas.transform.Find("Reward").gameObject;
        Reward_Obj.SetActive(false);
    }

}
