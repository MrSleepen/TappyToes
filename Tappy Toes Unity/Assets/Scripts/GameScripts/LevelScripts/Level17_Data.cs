using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level17_Data : MonoBehaviour {

    public GameObject Foot;
    public GameObject CameraRef;
    //public GameObject Wind;
    private bool isChallengeMode = false;
    private float TimeTracker;
    private int PreviousEvent;
    private float EventLength = 30f; // time each even lasts for


    void Start()
    {
        Invoke("LoadLevelData", 0.1f); // delayed briefly so isn't overrident
    }

    public void LoadLevelData()
    {
        GameManager.Instance.ActiveLevel = 17;

        GameObject ball = GameObject.Find("Ball");
        ball.GetComponent<AdvancedBall>().BallGravityScale = 1.45f;       // Gravity strength
        ball.GetComponent<AdvancedBall>().BallIntensifedGravity = 1.45f;  // Gravity strength near end of level
        ball.GetComponent<AdvancedBall>().VelocityDampening_X = 0f;       // gradual X-Dampening

        // only do EVENTS if on ChallengeMode
        if (PlayerPrefs.GetInt("ChallengeMode") == 1)
        {
            isChallengeMode = true;
        }
        else
        {
            isChallengeMode = false;
        }

        // Set BALL SKIN
        if (PlayerPrefs.GetInt("HasChosenSprite") == 0)
        {
            // set ball sprite
            GameManager.Instance.AnimalNum = PlayerPrefs.GetInt("ActiveLevel") - 1;
            PlayerPrefs.SetInt("AnimalNum", GameManager.Instance.AnimalNum);
            PlayerPrefs.SetInt("AnimalNumSave", GameManager.Instance.AnimalNum);

            GameObject Ball = GameObject.Find("Ball");
            Ball.GetComponent<AdvancedBall>().UpdateBallSound();
        }

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
    }

    public void SetEvent()
    {
        // disable previous event ----------------
        switch (PreviousEvent)
        {
            case 1:
                //CameraRef.GetComponent<RainToggle>().Rain_Deactivate();
                break;

            case 2:
                //Invoke("DeactiveWIndObj", 2.5f);
                //Wind.GetComponent<WindWinder>().Wind_Disable();
                break;

            case 3:
                break;

            default:
                // Do Nothing, no event was active previously
                break;
        } // -------------------------------------

        //Determine New Event------------------ -
        int rand = Random.Range(1, 3); // 1-5 (exclues 6)

        // Do not use same event twice in a row
        //if (rand == PreviousEvent)
        //{
        //    rand += Random.Range(1, 5); // 1-4 (exclues 5)
        //    if (rand > 5)
        //        rand -= 5;
        //}

        //int rand = 1; // << TESTING ONLY
        PreviousEvent = rand; // Set PreviousEvent to new event
        TimeTracker = EventLength; // reset event timer
        // ---------------------------------------

        // enable new event ----------------------
        switch (rand)
        {
            case 1:
                //CameraRef.GetComponent<RainToggle>().Rain_Activate();
                break;

            case 2:
                //Wind.SetActive(true);
                //Wind.GetComponent<WindWinder>().Wind_Enable();
                break;

            case 3:
                break;

        } // -------------------------------------

    }

    void FixedUpdate()
    {
        if (isChallengeMode)
        {
            if (!IsInvoking("SetEvent"))
                Invoke("SetEvent", TimeTracker);

            // pause timer when gameplay is paused
            GameObject ButtonScript = GameObject.Find("ButtonScript");
            if (Foot.GetComponent<FootController>().isPaused || ButtonScript.GetComponent<LastChance>().PopupActive == true)
            {
                CancelInvoke("SetEvent");
            }
            else
            {
                TimeTracker -= Time.deltaTime;
            }
        }
    }

    //public void DeactiveWIndObj()
    //{
    //    Wind.SetActive(false);
    //}

}