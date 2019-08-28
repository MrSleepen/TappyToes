
using UnityEngine;
using UnityEngine.Advertisements;

public class LastChance : MonoBehaviour
{
    public GameObject Popup;
    public bool Lights = true;
    public bool PopupActive;

    // Watch video and get extra life
    public void SecondChance()
    {
        Time.timeScale = 1;

        GameManager.Instance.lives = 0;
        PlayerPrefs.SetInt("LastChance", 0);
        Popup.SetActive(false);
        GameObject Ball = GameObject.Find("Ball");
        Ball.GetComponent<AdvancedBall>().SafeReset(); // Reset game and continue playing
        PopupActive = false;

        // Disable Special Physics
        Lights = false;
    }

    // Proceed to Loss Screen
    public void Return()
    {
        Time.timeScale = 1;

        // set top score
        GameObject LevelManager = GameObject.Find("LevelManager");
        LevelManager.GetComponent<LevelManager>().SetHighScore();

        GameObject Ball = GameObject.Find("Ball");
        Ball.GetComponent<AdvancedBall>().lossConditionAnalytics();

        PlayerPrefs.SetInt("LastChance", 0);
        Popup.SetActive(false);

        Ball.GetComponent<AdvancedBall>().EndGame(); // bring up EndGame Menu
        PopupActive = false;
    }


    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResult });
            PopupActive = true;
        }
    }

    private void HandleAdResult(ShowResult result)
    {
        //SecondChance(); // get rid of this and uncomment functions in switch, when ad is added in to game.

        switch (result)
        {
            case ShowResult.Finished:
                SecondChance();
                PopupActive = false;
                //Debug.Log("Reward with plus one life");
                break;

            case ShowResult.Skipped:
                PopupActive = false;
                Return();
                //Debug.Log("Skipped Add no reward");
                break;

            case ShowResult.Failed:
                PopupActive = false;
                Return();
                //Debug.Log("Failed to load add");
                break;
        }


    }
}