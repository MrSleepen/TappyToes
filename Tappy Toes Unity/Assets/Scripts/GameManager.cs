using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Create the game manager and make it visible from other scripts
    private static GameManager _Instance = null;
    public static GameManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();

            }
            return _Instance;
        }
    }

    //public Variables
    public int AnimalNum = 0;
    public int FootNum = 0;
    public int ShoeNum = 0;
    public int SoundNum = 1;
    public int Score = 0;
    public int ScoreResetCounter = 0;
    public int TopScore;
    public bool Reset = false;
    
    // Game State
    public int ActiveLevel = 1;
    public int Victory = 0;

    // Settings
    public int BatterySaver = 0;
    public int BallSelected = 0;
    public int FootSelected = 0;
    public int ShoeSelected = 0;

    // Other Rewards
    public int BonusBalls = 0;

    // Level Rewards
    public int BirdGift_01 = 0;
    public int BirdGift_02 = 0;
    public int BirdGift_03 = 0;
    public int BirdGift_04 = 0;
    public int BirdGift_05 = 0;
    public int BirdGift_06 = 0;
    public int BirdGift_07 = 0;
    public int BirdGift_08 = 0;
    public int BirdGift_09 = 0;
    public int BirdGift_10 = 0;
    public int BirdGift_11 = 0;
    public int BirdGift_12 = 0;
    public int BirdGift_13 = 0;
    public int BirdGift_14 = 0;
    public int BirdGift_15 = 0;
    public int BirdGift_16 = 0;
    public int BirdGift_17 = 0;
    public int BirdGift_18 = 0;
    public int BirdGift_19 = 0;
    public int BirdGift_20 = 0;

    // Challenge Level Rewards
    public int Challenge_01 = 0;
    public int Challenge_02 = 0;
    public int Challenge_03 = 0;
    public int Challenge_04 = 0;
    public int Challenge_05 = 0;
    public int Challenge_06 = 0;
    public int Challenge_07 = 0;
    public int Challenge_08 = 0;
    public int Challenge_09 = 0;
    public int Challenge_10 = 0;
    public int Challenge_11 = 0;
    public int Challenge_12 = 0;
    public int Challenge_13 = 0;
    public int Challenge_14 = 0;
    public int Challenge_15 = 0;
    public int Challenge_16 = 0;
    public int Challenge_17 = 0;
    public int Challenge_18 = 0;
    public int Challenge_19 = 0;
    public int Challenge_20 = 0;

    //Level Unlock
    public int LevelUnlockedGM;
    public int ChallengesCompletedGM;

    // Game Variables
    public int lives = 2;

    void Awake()
    {
        _Instance = this;
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("AnimalNumSave"))
        {
            AnimalNum = PlayerPrefs.GetInt("AnimalNumSave");
            FootNum = PlayerPrefs.GetInt("FootNumSave");
            ShoeNum = PlayerPrefs.GetInt("ShoeNumSave");
            TopScore = PlayerPrefs.GetInt("ScoreSave");
            LevelUnlockedGM = PlayerPrefs.GetInt("LevelUnlocked");
            ChallengesCompletedGM = PlayerPrefs.GetInt("ChallengesCompleted");

            // Settings
            BatterySaver = PlayerPrefs.GetInt("BatterySaver");
            BallSelected = PlayerPrefs.GetInt("BallSelected");
            FootSelected = PlayerPrefs.GetInt("FootSelected");
            ShoeSelected = PlayerPrefs.GetInt("ShoeSelected");

            // Other Rewards
            BonusBalls = PlayerPrefs.GetInt("BonusBalls");

            // Level Rewards
            BirdGift_01 = PlayerPrefs.GetInt("BirdGift_01");
            BirdGift_02 = PlayerPrefs.GetInt("BirdGift_02");
            BirdGift_03 = PlayerPrefs.GetInt("BirdGift_03");
            BirdGift_04 = PlayerPrefs.GetInt("BirdGift_04");
            BirdGift_05 = PlayerPrefs.GetInt("BirdGift_05");
            BirdGift_06 = PlayerPrefs.GetInt("BirdGift_06");
            BirdGift_07 = PlayerPrefs.GetInt("BirdGift_07");
            BirdGift_08 = PlayerPrefs.GetInt("BirdGift_08");
            BirdGift_09 = PlayerPrefs.GetInt("BirdGift_09");
            BirdGift_10 = PlayerPrefs.GetInt("BirdGift_10");
            BirdGift_11 = PlayerPrefs.GetInt("BirdGift_11");
            BirdGift_12 = PlayerPrefs.GetInt("BirdGift_12");
            BirdGift_13 = PlayerPrefs.GetInt("BirdGift_13");
            BirdGift_14 = PlayerPrefs.GetInt("BirdGift_14");
            BirdGift_15 = PlayerPrefs.GetInt("BirdGift_15");
            BirdGift_16 = PlayerPrefs.GetInt("BirdGift_16");
            BirdGift_17 = PlayerPrefs.GetInt("BirdGift_17");
            BirdGift_18 = PlayerPrefs.GetInt("BirdGift_18");
            BirdGift_19 = PlayerPrefs.GetInt("BirdGift_19");
            BirdGift_20 = PlayerPrefs.GetInt("BirdGift_20");

            // Challenge Level Rewards
            Challenge_01 = PlayerPrefs.GetInt("Challenge_01");
            Challenge_02 = PlayerPrefs.GetInt("Challenge_02");
            Challenge_03 = PlayerPrefs.GetInt("Challenge_03");
            Challenge_04 = PlayerPrefs.GetInt("Challenge_04");
            Challenge_05 = PlayerPrefs.GetInt("Challenge_05");
            Challenge_06 = PlayerPrefs.GetInt("Challenge_06");
            Challenge_07 = PlayerPrefs.GetInt("Challenge_07");
            Challenge_08 = PlayerPrefs.GetInt("Challenge_08");
            Challenge_09 = PlayerPrefs.GetInt("Challenge_09");
            Challenge_10 = PlayerPrefs.GetInt("Challenge_10");
            Challenge_11 = PlayerPrefs.GetInt("Challenge_11");
            Challenge_12 = PlayerPrefs.GetInt("Challenge_12");
            Challenge_13 = PlayerPrefs.GetInt("Challenge_13");
            Challenge_14 = PlayerPrefs.GetInt("Challenge_14");
            Challenge_15 = PlayerPrefs.GetInt("Challenge_15");
            Challenge_16 = PlayerPrefs.GetInt("Challenge_16");
            Challenge_17 = PlayerPrefs.GetInt("Challenge_17");
            Challenge_18 = PlayerPrefs.GetInt("Challenge_18");
            Challenge_19 = PlayerPrefs.GetInt("Challenge_19");
            Challenge_20 = PlayerPrefs.GetInt("Challenge_20");
        }
        else
        {
            PlayerPrefs.SetInt("AnimalNumSave", AnimalNum);
            PlayerPrefs.SetInt("FootNumSave", FootNum);
            PlayerPrefs.SetInt("ShoeNumSave", ShoeNum);
            PlayerPrefs.SetInt("ScoreSave", TopScore);
            PlayerPrefs.SetInt("ChallengesCompleted", ChallengesCompletedGM);
            PlayerPrefs.SetInt("LevelUnlocked", LevelUnlockedGM);
            PlayerPrefs.SetInt("FootUnlocked", 0);
            PlayerPrefs.SetInt("ShoeUnlocked", 0);

            // Settings
            PlayerPrefs.SetInt("BatterySaver", BatterySaver);
            PlayerPrefs.SetInt("BallSelected", BallSelected);
            PlayerPrefs.SetInt("FootSelected", FootSelected);
            PlayerPrefs.SetInt("ShoeSelected", ShoeSelected);

            // Other Rewards
            PlayerPrefs.SetInt("BonusBalls", BonusBalls);

            // Level Rewards
            PlayerPrefs.SetInt("BirdGift_01", BirdGift_01);
            PlayerPrefs.SetInt("BirdGift_02", BirdGift_02);
            PlayerPrefs.SetInt("BirdGift_03", BirdGift_03);
            PlayerPrefs.SetInt("BirdGift_04", BirdGift_04);
            PlayerPrefs.SetInt("BirdGift_05", BirdGift_05);
            PlayerPrefs.SetInt("BirdGift_06", BirdGift_06);
            PlayerPrefs.SetInt("BirdGift_07", BirdGift_07);
            PlayerPrefs.SetInt("BirdGift_08", BirdGift_08);
            PlayerPrefs.SetInt("BirdGift_09", BirdGift_09);
            PlayerPrefs.SetInt("BirdGift_10", BirdGift_10);
            PlayerPrefs.SetInt("BirdGift_11", BirdGift_11);
            PlayerPrefs.SetInt("BirdGift_12", BirdGift_12);
            PlayerPrefs.SetInt("BirdGift_13", BirdGift_13);
            PlayerPrefs.SetInt("BirdGift_14", BirdGift_14);
            PlayerPrefs.SetInt("BirdGift_15", BirdGift_15);
            PlayerPrefs.SetInt("BirdGift_16", BirdGift_16);
            PlayerPrefs.SetInt("BirdGift_17", BirdGift_17);
            PlayerPrefs.SetInt("BirdGift_18", BirdGift_18);
            PlayerPrefs.SetInt("BirdGift_19", BirdGift_19);
            PlayerPrefs.SetInt("BirdGift_20", BirdGift_20);

            // Challenge Level Rewards
            PlayerPrefs.SetInt("Challenge_01", Challenge_01);
            PlayerPrefs.SetInt("Challenge_02", Challenge_02);
            PlayerPrefs.SetInt("Challenge_03", Challenge_03);
            PlayerPrefs.SetInt("Challenge_04", Challenge_04);
            PlayerPrefs.SetInt("Challenge_05", Challenge_05);
            PlayerPrefs.SetInt("Challenge_06", Challenge_06);
            PlayerPrefs.SetInt("Challenge_07", Challenge_07);
            PlayerPrefs.SetInt("Challenge_08", Challenge_08);
            PlayerPrefs.SetInt("Challenge_09", Challenge_09);
            PlayerPrefs.SetInt("Challenge_10", Challenge_10);
            PlayerPrefs.SetInt("Challenge_11", Challenge_11);
            PlayerPrefs.SetInt("Challenge_12", Challenge_12);
            PlayerPrefs.SetInt("Challenge_13", Challenge_13);
            PlayerPrefs.SetInt("Challenge_14", Challenge_14);
            PlayerPrefs.SetInt("Challenge_15", Challenge_15);
            PlayerPrefs.SetInt("Challenge_16", Challenge_16);
            PlayerPrefs.SetInt("Challenge_17", Challenge_17);
            PlayerPrefs.SetInt("Challenge_18", Challenge_18);
            PlayerPrefs.SetInt("Challenge_19", Challenge_19);
            PlayerPrefs.SetInt("Challenge_20", Challenge_20);
        }
    }

}
