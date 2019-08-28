using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;            // required for TMP_Text
using UnityEngine.UI;

public class SetEndGameState : MonoBehaviour {

    //public TMP_Text EndGameMessage;
    public GameObject Notice;
    public GameObject MenuObj;
    //public GameObject MenuScaler;

    private float TransitionSpeed = Screen.height * 1.75f; // slinding up to screen at start

    public GameObject Notice_Victory;
    public GameObject Notice_Defeat;
    public GameObject Button_Next;
    public GameObject Button_Restart;
    
    public GameObject RewardIcon;
    public Sprite[] BallImages;

    public void AnimatedMenu ()
    {
        // Set Menu Position (below screen)
        MenuObj.transform.position = new Vector3(MenuObj.transform.position.x, -Screen.height*0.5f, MenuObj.transform.position.z);

        // Set the reward icon (Ball Skin)
        Image RewardIconImg = RewardIcon.GetComponent<Image>();
        int ballnum = PlayerPrefs.GetInt("AnimalsUnlocked");
        if (ballnum <= 41)
        {
            RewardIconImg.sprite = BallImages[ballnum];
        }

        // VICTORY
        if (PlayerPrefs.GetInt("Victory") == 1)
        {
            // Set Notice (Well Done / Try Again)
            Notice_Victory.SetActive(true);
            Notice_Defeat.SetActive(false);

            // Set Button (Restart/Next)
            Button_Next.SetActive(true);
            Button_Restart.SetActive(false);
        }
        else // DEFEAT
        {
            // Set Notice (Well Done / Try Again)
            Notice_Defeat.SetActive(true);
            Notice_Victory.SetActive(false);

            // Set Button (Restart/Next)
            Button_Restart.SetActive(true);
            Button_Next.SetActive(false);
        }

        // update level number in EndGameMenu
        GameObject LevelIndicator = GameObject.Find("LevelIndicator");
        if (LevelIndicator != null)
            LevelIndicator.GetComponent<LevelIndicator>().UpdateLevelIndicator();
    }

    void Update()
    {
        //Move "Menu Obj"
        if (MenuObj.transform.position.y < Screen.height * 0.5f - 1f) // MenuObj.transform.position.y < 400f
        {
            MenuObj.transform.Translate(Vector3.up * TransitionSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            MenuObj.transform.position = new Vector3(MenuObj.transform.position.x, Screen.height * 0.5f, MenuObj.transform.position.z);
        }
    }

}
