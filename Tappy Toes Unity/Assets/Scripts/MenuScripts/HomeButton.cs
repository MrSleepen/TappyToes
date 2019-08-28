using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour {

    // AudioSources
    public AudioSource Audio_ClickButton;

    public void GoHome()
    {
        Time.timeScale = 1;

        GameManager.Instance.Reset = true;

        // set top score
        GameObject LevelManager = GameObject.Find("LevelManager");
        LevelManager.GetComponent<LevelManager>().SetHighScore();

        Audio_ClickButton.Play();
        // Save HighScore (if better than previous)
        if (GameManager.Instance.Score > GameManager.Instance.TopScore)
        {
            GameManager.Instance.TopScore = GameManager.Instance.Score;
            PlayerPrefs.SetInt("ScoreSave", GameManager.Instance.TopScore);
        }

        // Load "MainMenu"
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
