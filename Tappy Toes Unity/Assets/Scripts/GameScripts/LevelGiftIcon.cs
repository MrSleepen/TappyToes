using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGiftIcon : MonoBehaviour {

    public GameObject Gift_01;
    public GameObject Gift_02;
    public GameObject Gift_03;
    public GameObject Gift_04;
    public GameObject Gift_05;
    public GameObject Gift_06;
    public GameObject Gift_07;
    public GameObject Gift_08;
    public GameObject Gift_09;
    public GameObject Gift_10;
    public GameObject Gift_11;
    public GameObject Gift_12;
    public GameObject Gift_13;
    public GameObject Gift_14;
    public GameObject Gift_15;
    public GameObject Gift_16;
    public GameObject Gift_17;
    public GameObject Gift_18;
    public GameObject Gift_19;
    public GameObject Gift_20;
    
    public void UpdateIcons()
    {
        // Story Mode
        if (PlayerPrefs.GetInt("ChallengeMode") == 0)
        {
            if (PlayerPrefs.GetInt("BirdGift_01") == 0)
            {
                Gift_01.SetActive(true);
            }
            else
            {
                Gift_01.SetActive(false);
            }

            if (PlayerPrefs.GetInt("BirdGift_02") == 0)
            {
                Gift_02.SetActive(true);
            }
            else
            {
                Gift_02.SetActive(false);
            }

            if (PlayerPrefs.GetInt("BirdGift_03") == 0)
            {
                Gift_03.SetActive(true);
            }
            else
            {
                Gift_03.SetActive(false);
            }

            if (PlayerPrefs.GetInt("BirdGift_04") == 0)
            {
                Gift_04.SetActive(true);
            }
            else
            {
                Gift_04.SetActive(false);
            }

            if (PlayerPrefs.GetInt("BirdGift_05") == 0)
            {
                Gift_05.SetActive(true);
            }
            else
            {
                Gift_05.SetActive(false);
            }

            if (PlayerPrefs.GetInt("BirdGift_06") == 0)
            {
                Gift_06.SetActive(true);
            }
            else
            {
                Gift_06.SetActive(false);
            }

            if (PlayerPrefs.GetInt("BirdGift_07") == 0)
            {
                Gift_07.SetActive(true);
            }
            else
            {
                Gift_07.SetActive(false);
            }

            if (PlayerPrefs.GetInt("BirdGift_08") == 0)
            {
                Gift_08.SetActive(true);
            }
            else
            {
                Gift_08.SetActive(false);
            }

            if (PlayerPrefs.GetInt("BirdGift_09") == 0)
            {
                Gift_09.SetActive(true);
            }
            else
            {
                Gift_09.SetActive(false);
            }

            if (PlayerPrefs.GetInt("BirdGift_10") == 0)
            {
                Gift_10.SetActive(true);
            }
            else
            {
                Gift_10.SetActive(false);
            }

            if (PlayerPrefs.GetInt("BirdGift_11") == 0)
            {
                Gift_11.SetActive(true);
            }
            else
            {
                Gift_11.SetActive(false);
            }

            if (PlayerPrefs.GetInt("BirdGift_12") == 0)
            {
                Gift_12.SetActive(true);
            }
            else
            {
                Gift_12.SetActive(false);
            }

            if (PlayerPrefs.GetInt("BirdGift_13") == 0)
            {
                Gift_13.SetActive(true);
            }
            else
            {
                Gift_13.SetActive(false);
            }

            if (PlayerPrefs.GetInt("BirdGift_14") == 0)
            {
                Gift_14.SetActive(true);
            }
            else
            {
                Gift_14.SetActive(false);
            }

            if (PlayerPrefs.GetInt("BirdGift_15") == 0)
            {
                Gift_15.SetActive(true);
            }
            else
            {
                Gift_15.SetActive(false);
            }

            if (PlayerPrefs.GetInt("BirdGift_16") == 0)
            {
                Gift_16.SetActive(true);
            }
            else
            {
                Gift_16.SetActive(false);
            }

            if (PlayerPrefs.GetInt("BirdGift_17") == 0)
            {
                Gift_17.SetActive(true);
            }
            else
            {
                Gift_17.SetActive(false);
            }

            if (PlayerPrefs.GetInt("BirdGift_18") == 0)
            {
                Gift_18.SetActive(true);
            }
            else
            {
                Gift_18.SetActive(false);
            }

            if (PlayerPrefs.GetInt("BirdGift_19") == 0)
            {
                Gift_19.SetActive(true);
            }
            else
            {
                Gift_19.SetActive(false);
            }

            if (PlayerPrefs.GetInt("BirdGift_20") == 0)
            {
                Gift_20.SetActive(true);
            }
            else
            {
                Gift_20.SetActive(false);
            }
        }
        else // Challenge Mode
        {
            if (PlayerPrefs.GetInt("Challenge_01") == 0)
            {
                Gift_01.SetActive(true);
            }
            else
            {
                Gift_01.SetActive(false);
            }

            if (PlayerPrefs.GetInt("Challenge_02") == 0)
            {
                Gift_02.SetActive(true);
            }
            else
            {
                Gift_02.SetActive(false);
            }

            if (PlayerPrefs.GetInt("Challenge_03") == 0)
            {
                Gift_03.SetActive(true);
            }
            else
            {
                Gift_03.SetActive(false);
            }

            if (PlayerPrefs.GetInt("Challenge_04") == 0)
            {
                Gift_04.SetActive(true);
            }
            else
            {
                Gift_04.SetActive(false);
            }

            if (PlayerPrefs.GetInt("Challenge_05") == 0)
            {
                Gift_05.SetActive(true);
            }
            else
            {
                Gift_05.SetActive(false);
            }

            if (PlayerPrefs.GetInt("Challenge_06") == 0)
            {
                Gift_06.SetActive(true);
            }
            else
            {
                Gift_06.SetActive(false);
            }

            if (PlayerPrefs.GetInt("Challenge_07") == 0)
            {
                Gift_07.SetActive(true);
            }
            else
            {
                Gift_07.SetActive(false);
            }

            if (PlayerPrefs.GetInt("Challenge_08") == 0)
            {
                Gift_08.SetActive(true);
            }
            else
            {
                Gift_08.SetActive(false);
            }

            if (PlayerPrefs.GetInt("Challenge_09") == 0)
            {
                Gift_09.SetActive(true);
            }
            else
            {
                Gift_09.SetActive(false);
            }

            if (PlayerPrefs.GetInt("Challenge_10") == 0)
            {
                Gift_10.SetActive(true);
            }
            else
            {
                Gift_10.SetActive(false);
            }

            if (PlayerPrefs.GetInt("Challenge_11") == 0)
            {
                Gift_11.SetActive(true);
            }
            else
            {
                Gift_11.SetActive(false);
            }

            if (PlayerPrefs.GetInt("Challenge_12") == 0)
            {
                Gift_12.SetActive(true);
            }
            else
            {
                Gift_12.SetActive(false);
            }

            if (PlayerPrefs.GetInt("Challenge_13") == 0)
            {
                Gift_13.SetActive(true);
            }
            else
            {
                Gift_13.SetActive(false);
            }

            if (PlayerPrefs.GetInt("Challenge_14") == 0)
            {
                Gift_14.SetActive(true);
            }
            else
            {
                Gift_14.SetActive(false);
            }

            if (PlayerPrefs.GetInt("Challenge_15") == 0)
            {
                Gift_15.SetActive(true);
            }
            else
            {
                Gift_15.SetActive(false);
            }

            if (PlayerPrefs.GetInt("Challenge_16") == 0)
            {
                Gift_16.SetActive(true);
            }
            else
            {
                Gift_16.SetActive(false);
            }

            if (PlayerPrefs.GetInt("Challenge_17") == 0)
            {
                Gift_17.SetActive(true);
            }
            else
            {
                Gift_17.SetActive(false);
            }

            if (PlayerPrefs.GetInt("Challenge_18") == 0)
            {
                Gift_18.SetActive(true);
            }
            else
            {
                Gift_18.SetActive(false);
            }

            if (PlayerPrefs.GetInt("Challenge_19") == 0)
            {
                Gift_19.SetActive(true);
            }
            else
            {
                Gift_19.SetActive(false);
            }

            if (PlayerPrefs.GetInt("Challenge_20") == 0)
            {
                Gift_20.SetActive(true);
            }
            else
            {
                Gift_20.SetActive(false);
            }
        }
    }

}
