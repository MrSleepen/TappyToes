using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuActive;
    public GameObject MainMenuActiveButtons1;
    public GameObject MainMenuActiveButtons2;
    private Animator Anim2;
    public GameObject MainMenuActiveButtons3;
    private Animator Anim3;
    public GameObject MainMenuActiveButtons4;
    private Animator Anim4;
    public GameObject MainMenuActiveButtons5;
    private Animator Anim5;
    public GameObject MainMenuActiveButtons6;
    private Animator Anim6;
    public GameObject Tittle;
    public GameObject Prefabs;
    public GameObject Notice;   // Victory/Defeat Message
    public GameObject Buttons1; // MainMenu Buttons
    public GameObject Buttons2; //  EndMenu Buttons
    public GameObject Buttons6; // for level panel, for referencing GiftIcons in level select

    public GameObject AnimalSelectorObj;
    public GameObject FootSelectorObj;
    public GameObject ShoeSelectorObj;
    public GameObject LevelBall;
    public GameObject MostRecentFoot;
    public GameObject MostRecentShoe;
    public Sprite Selected;

    [HideInInspector] public int SelectType; // for scrolling menus

    // AudioSources
    public AudioSource Audio_ClickButton;
    public AudioSource Audio_OpenMainMenu;
    public AudioSource Audio_OpenEndMenu;

    private void Start()
    {
        UpdateFrameRate(); // change framerate based on BatterySaver Value

        Anim2 = MainMenuActiveButtons2.GetComponent<Animator>();
        Anim2.enabled = false;
        Anim3 = MainMenuActiveButtons3.GetComponent<Animator>();
        Anim3.enabled = false;
        Anim4 = MainMenuActiveButtons4.GetComponent<Animator>();
        Anim4.enabled = false;
        Anim5 = MainMenuActiveButtons5.GetComponent<Animator>();
        Anim5.enabled = false;
        Anim6 = MainMenuActiveButtons6.GetComponent<Animator>();
        Anim6.enabled = false;

        if (PlayerPrefs.GetInt("EndMenuActive") == 1)
        {
            StartEndMenu();
            GameObject Canvas = GameObject.Find("Canvas");
            Canvas.GetComponent<SetEndGameState>().AnimatedMenu();
        }
        else
        {
            PlayerPrefs.SetInt("EndMenuActive", 0); // deactive EndMenu
            StartMainMenu();
        }

        // update animal reference
        GameManager.Instance.AnimalNum = PlayerPrefs.GetInt("AnimalNumSave");

        // set ball sound and sprite
        //GameObject MenuBall = GameObject.Find("Ball");
        //MenuBall.GetComponent<Ball>().SetMenuBallSound();
        //MenuBall.GetComponent<Ball>().UpdateBallSprite();

        // set menu-foot spirte
        GameObject Foot = GameObject.Find("Foot");
        if (Foot != null)
            Foot.GetComponent<AutoKick>().SetFootSprite();

        // set menu-shoe sprite
        GameObject ShoeSelector = GameObject.Find("ShoeSelector");
        if (ShoeSelector != null)
            ShoeSelector.GetComponent<ShoeSelect>().UpdateShoeSprite();
    }

    public void StartMainMenu()
    {
        Audio_OpenMainMenu.Play();

        // disbale EndMenu
        MainMenuActive.SetActive(true); // "Tappy Toes" Title && "Tap To Play"
        Tittle.SetActive(false);        // "Tappy Toes" Title (for level select screen)
        Prefabs.SetActive(true);        // Foot and Ball
        Notice.SetActive(false);        // EndGame Notice (Victory/Defeat)
        Buttons1.SetActive(true);       // MainMenu Buttons
        Buttons2.SetActive(false);      //  EndMenu Buttons
    }

    public void StartEndMenu()
    {
        Audio_OpenEndMenu.Play();

        MainMenuActive.SetActive(false); // "Tappy Toes" Title && "Tap To Play"
        Tittle.SetActive(false);         // "Tappy Toes" Title (for level select screen)
        Prefabs.SetActive(false);        // Foot and Ball
        Notice.SetActive(true);          // EndGame Notice (Victory/Defeat)
        Buttons1.SetActive(false);       // MainMenu Buttons
        Buttons2.SetActive(true);        //  EndMenu Buttons
    }

    /////////////////////////////////////////////////////////// Menu Buttons ///////////////////////////////////////////////////////////////////

    // Level select Button, "tap anywhere"
    public void Play()
    {
        Audio_ClickButton.Play();
        MainMenuActive.SetActive(false); // "Tappy Toes" Title && "Tap To Play"
        MainMenuActiveButtons1.SetActive(false);
        MainMenuActiveButtons2.SetActive(false);
        MainMenuActiveButtons3.SetActive(false);
        MainMenuActiveButtons4.SetActive(false);
        MainMenuActiveButtons5.SetActive(false);
        MainMenuActiveButtons6.SetActive(true);
        Tittle.SetActive(true);     // "Tappy Toes" Title (for level select screen)
        Prefabs.SetActive(false);   // Foot and Ball
        Anim6.enabled = true;
        Anim6.Play("LevelSlide");
        SelectType = 4;

        GameObject CenterSnap = GameObject.Find("CenterSnap");
        CenterSnap.GetComponent<ScrollSnapping>().Enable_AutoScrolling();

        // show/hide the gift icons based on if rewards are unlocked or not (challengemode / storymode)
        Buttons6.GetComponent<LevelGiftIcon>().UpdateIcons();
    }

    // "Share" Button
    public void Share()
    {
        Audio_ClickButton.Play();
        Debug.Log("Load Share");
    }

    // "Restart" Button (restart last level)
    public void Restart()
    {
        Audio_ClickButton.Play();
        PlayerPrefs.SetInt("EndMenuActive", 0); // deactive EndMenu
        Debug.Log("Load Restart");
        SceneManager.LoadScene("Level" + PlayerPrefs.GetInt("ActiveLevel")); // Load current level (restart)
    }

    // "Next" Button (load next level)
    public void Next()
    {
        Audio_ClickButton.Play();
        PlayerPrefs.SetInt("EndMenuActive", 0); // deactive EndMenu
        Debug.Log("Load Next");
        if (PlayerPrefs.GetInt("ActiveLevel") < 20) // do not exceed max level
            PlayerPrefs.SetInt("ActiveLevel", PlayerPrefs.GetInt("ActiveLevel") + 1); // Increment Active Level

        SceneManager.LoadScene("Level" + PlayerPrefs.GetInt("ActiveLevel")); // Load level
    }

    // Leader boards button
    public void LeaderBoards()
    {
        Audio_ClickButton.Play();
        Debug.Log("LoadLeaderBoards");
    }

    // Rate the app button
    public void Rate()
    {
        Audio_ClickButton.Play();
        Debug.Log("LoadRateApp");
    }

    // settings button
    public void Settings()
    {
        Audio_ClickButton.Play();
        MainMenuActive.SetActive(false); // "Tappy Toes" Title && "Tap To Play"
        MainMenuActiveButtons1.SetActive(false);
        MainMenuActiveButtons2.SetActive(true);
        MainMenuActiveButtons3.SetActive(false);
        MainMenuActiveButtons4.SetActive(false);
        MainMenuActiveButtons5.SetActive(false);
        MainMenuActiveButtons6.SetActive(false);
        Tittle.SetActive(false);         // "Tappy Toes" Title (for level select screen)
        Prefabs.SetActive(false);        // Foot and Ball
        Notice.SetActive(false);         // EndGame Notice (Victory/Defeat)
        Buttons1.SetActive(false);       // MainMenu Buttons
        Buttons2.SetActive(false);       //  EndMenu Buttons

        Anim2.enabled = true;
        Anim2.Play("SlideLeft");

        GameObject BallIcon = GameObject.Find("BallIcon");
        BallIcon.GetComponent<BallMenu>().UpdateBallIcon();
    }

    // No Adds Button
    public void NoAdds()
    {
        Audio_ClickButton.Play();
        Debug.Log("LoadNoAdds");
        PlayerPrefs.DeleteAll();
    }

    // Home button on all screens
    public void Home()
    {
        PlayerPrefs.SetInt("EndMenuActive", 0); // deactive EndMenu

        Audio_ClickButton.Play();
        Audio_OpenMainMenu.Play();
        MainMenuActive.SetActive(true);
        MainMenuActiveButtons1.SetActive(true);
        MainMenuActiveButtons2.SetActive(false);
        MainMenuActiveButtons3.SetActive(false);
        MainMenuActiveButtons4.SetActive(false);
        MainMenuActiveButtons5.SetActive(false);
        MainMenuActiveButtons6.SetActive(false);
        Tittle.SetActive(false);
        Prefabs.SetActive(true);
        Tittle.SetActive(false);        // "Tappy Toes" Title (for level select screen)
        Prefabs.SetActive(true);        // Foot and Ball
        Notice.SetActive(false);        // EndGame Notice (Victory/Defeat)
        Buttons1.SetActive(true);       // MainMenu Buttons
        Buttons2.SetActive(false);      //  EndMenu Buttons

        GameManager.Instance.Reset = true;

        // update animal reference
        GameManager.Instance.AnimalNum = PlayerPrefs.GetInt("AnimalNumSave");

        // set ball sound and sprite
        GameObject MenuBall = GameObject.Find("Ball");
        MenuBall.GetComponent<Ball>().SetMenuBallSound();
        MenuBall.GetComponent<Ball>().UpdateBallSprite();

        // set menu-foot spirte
        GameObject Foot = GameObject.Find("Foot");
        if (Foot != null)
            Foot.GetComponent<AutoKick>().SetFootSprite();

        // set menu-shoe sprite
        GameObject ShoeSelector = GameObject.Find("ShoeSelector");
        if (ShoeSelector != null)
            ShoeSelector.GetComponent<ShoeSelect>().UpdateShoeSprite();
    }

    // Back Button
    public void Back()
    {
        Audio_ClickButton.Play();
        Audio_OpenMainMenu.Play();
        MainMenuActive.SetActive(false);
        MainMenuActiveButtons1.SetActive(false);
        MainMenuActiveButtons2.SetActive(true);
        MainMenuActiveButtons3.SetActive(false);
        MainMenuActiveButtons4.SetActive(false);
        MainMenuActiveButtons5.SetActive(false);
        MainMenuActiveButtons6.SetActive(false);
        Tittle.SetActive(false);
        Prefabs.SetActive(false);
        GameManager.Instance.Reset = true;

        GameObject BallIcon = GameObject.Find("BallIcon");
        BallIcon.GetComponent<BallMenu>().UpdateBallIcon();
    }

    // other back button from different screen
    public void Back2()
    {
        Audio_ClickButton.Play();
        Audio_OpenMainMenu.Play();
        MainMenuActive.SetActive(true);
        MainMenuActiveButtons1.SetActive(true);
        MainMenuActiveButtons2.SetActive(false);
        MainMenuActiveButtons3.SetActive(false);
        MainMenuActiveButtons4.SetActive(false);
        MainMenuActiveButtons5.SetActive(false);
        MainMenuActiveButtons6.SetActive(false);
        Tittle.SetActive(false);
        Prefabs.SetActive(true);
        GameManager.Instance.Reset = true;

        // set ball sound and sprite
        GameObject MenuBall = GameObject.Find("Ball");
        MenuBall.GetComponent<Ball>().SetMenuBallSound();
        MenuBall.GetComponent<Ball>().UpdateBallSprite();

        // set menu-foot spirte
        GameObject Foot = GameObject.Find("Foot");
        Foot.GetComponent<AutoKick>().SetFootSprite();
    }

    // in settings animal selection menu
    public void AnimalSelect()
    {
        Audio_ClickButton.Play();
        MainMenuActive.SetActive(false);
        MainMenuActiveButtons1.SetActive(false);
        MainMenuActiveButtons2.SetActive(false);
        MainMenuActiveButtons3.SetActive(true);
        MainMenuActiveButtons4.SetActive(false);
        MainMenuActiveButtons5.SetActive(false);
        MainMenuActiveButtons6.SetActive(false);
        Tittle.SetActive(false);
        Prefabs.SetActive(false);
        Anim3.enabled = true;
        Anim3.Play("AnimalsUp");
        SelectType = 1;
    }

    // in settings foot select menu
    public void FootSelect()
    {
        Audio_ClickButton.Play();
        MainMenuActive.SetActive(false);
        MainMenuActiveButtons1.SetActive(false);
        MainMenuActiveButtons2.SetActive(false);
        MainMenuActiveButtons3.SetActive(false);
        MainMenuActiveButtons4.SetActive(true);
        MainMenuActiveButtons5.SetActive(false);
        MainMenuActiveButtons6.SetActive(false);
        Tittle.SetActive(false);
        Prefabs.SetActive(false);
        Anim4.enabled = true;
        Anim4.Play("FootSlide");
        SelectType = 2;
    }

    // in settings ShoeSelect menu
    public void ShoeSelect()
    {
        Audio_ClickButton.Play();
        MainMenuActive.SetActive(false);
        MainMenuActiveButtons1.SetActive(false);
        MainMenuActiveButtons2.SetActive(false);
        MainMenuActiveButtons3.SetActive(false);
        MainMenuActiveButtons4.SetActive(false);
        MainMenuActiveButtons5.SetActive(true);
        MainMenuActiveButtons6.SetActive(false);
        Tittle.SetActive(false);
        Prefabs.SetActive(false);
        Anim5.enabled = true;
        Anim5.Play("ShoeSlide");
        SelectType = 3;
    }

    public void Story()
    {
        PlayerPrefs.SetInt("ChallengeMode", 0);

        // show/hide the gift icons based on if rewards are unlocked or not (challengemode / storymode)
        Buttons6.GetComponent<LevelGiftIcon>().UpdateIcons();
    }

    public void Challenge()
    {
        PlayerPrefs.SetInt("ChallengeMode", 1);

        // show/hide the gift icons based on if rewards are unlocked or not (challengemode / storymode)
        Buttons6.GetComponent<LevelGiftIcon>().UpdateIcons();
    }

    // In settings Sound Toggle button
    public void SoundSelect()
    {
        Audio_ClickButton.Play();
        if (GameManager.Instance.SoundNum == 0)
        {
            GameManager.Instance.SoundNum = 1;
        }
       else
        {
            GameManager.Instance.SoundNum = 0;
        }
    }

    public void UseDefaultBall()  // changes ball based on active level
    {
        PlayerPrefs.SetInt("HasChosenSprite", 0);

        // change background img on the button
        PlayerPrefs.SetInt("BallSelected", 0);
        AnimalSelectorObj.GetComponent<AnimalSelectorMenu>().ResetSelected();
        LevelBall.GetComponent<Image>().sprite = Selected;
    }

    public void UseLatestFoot() // changes foot to most recent unlocked (updated in-game upon getting a bird)
    {
        PlayerPrefs.SetInt("HasChosenFoot", 0);
        PlayerPrefs.SetInt("FootNumSave", PlayerPrefs.GetInt("FootUnlocked"));

        // change background img on the button
        PlayerPrefs.SetInt("FootSelected", 0);
        FootSelectorObj.GetComponent<FootSelect>().ResetSelected();
        MostRecentFoot.GetComponent<Image>().sprite = Selected;
    }

    public void UseLatestShoe() // changes shoe to most recent unlocked (updated in-game upon getting a bird)
    {
        PlayerPrefs.SetInt("HasChosenShoe", 0);
        PlayerPrefs.SetInt("ShoeNumSave", PlayerPrefs.GetInt("ShoeUnlocked"));

        // change background img on the button
        PlayerPrefs.SetInt("ShoeSelected", 0);
        ShoeSelectorObj.GetComponent<ShoeSelect>().ResetSelected();
        MostRecentShoe.GetComponent<Image>().sprite = Selected;
    }

    public void ToggleBatterySaver()
    {
        if (PlayerPrefs.GetInt("BatterySaver") == 1)
        {
            PlayerPrefs.SetInt("BatterySaver", 0);
        }
        else // PlayerPrefs.GetInt("BatterySaver") == 0
        {
            PlayerPrefs.SetInt("BatterySaver", 1);
        }

        UpdateFrameRate(); // change framerate based on BatterySaver Value

        GameObject BatterySaver = GameObject.Find("BatterySaver");
        BatterySaver.GetComponent<PerformanceSetting>().UpdateDisplay();
    }

    public void UpdateFrameRate()
    {
        if (PlayerPrefs.GetInt("BatterySaver") == 1)
        {
            //Application.targetFrameRate = -1; // use default frame rate for your device (probably 30fps or lower)
            Application.targetFrameRate = 30; // use 30fps
        }
        else
        {
            Application.targetFrameRate = 60; // use 60fps
        }
    }
    
}
