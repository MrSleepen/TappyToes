using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // required for Slider
using TMPro;            // required for TMP_Text

public class GameUI : MonoBehaviour {

    public Camera refCamera;
    public GameObject FootObj;

    public GameObject PerfectHit;
    public GameObject NearMiss;
    public GameObject PerfectStreak;
    public GameObject GoodStreak;
    public GameObject perfectStreak;
    public GameObject goodStreak;

    public TMP_Text Lives;
    public TMP_Text Score;
    public TMP_Text PlusScore;
    public Slider GoalProgress; // Progressbar for Score
    public Slider StaminaBar;

    // variables for KickText Margin
    private Vector3 cameraPos;
    private Vector3 RightBoundry;
    private Vector3 LeftBoundry;
    private Vector2 screenSize;
    private float MarginOffset = 1.5f; // Offset from screen edge

    // Progressbar appears is Story Mode only
    public bool isChallengeMode;
    private bool isActive;

    // SCOREplus Text
    private float ScoreTimer = 0.0f;
    private float ScoreFadeDelay = 1.0f; // time before text disaperars

    // KICK Text
    private float TextTimer = 0.0f;
    private float TextFadeDelay = 1.0f; // time before text disaperars

    // STREAK Text
    private float StreakTimer = 0.0f;
    private float StreakFadeDelay = 2.0f; // time before text disaperars

    // Image Fading (fancy text)
    public float FadeRate = 0.5f;
    private float goodAlpha;
    private float perfectAlpha;
    private float hitAlpha;
    private float missAlpha;

    //private Vector2 DefaultScoreLocation;
    private float DistanceRaised;
    private float RaiseSpeed = 1.0f;

    void Start ()
    {
        if (PlayerPrefs.GetInt("ChallengeMode") == 1) // Story Mode
        {
            isChallengeMode = true;
        }
        else
        {
            isChallengeMode = false;
        }

        SetText(); // set starting values for Lives, Score

        if (isChallengeMode == false) // Story Mode
        {
            GoalProgress.value = CalculateProgress(); // set progressbar based on score
            GameObject ProgressBar = GameObject.Find("Slider_Score");
            ProgressBar.SetActive(true);
        }
        else if (isChallengeMode == true) // Challenge Mode
        {
            GameObject ProgressBar = GameObject.Find("Slider_Score");
            ProgressBar.SetActive(false);
        }

        StaminaBar.value = CalculateStamina(); // set staminaBar based on stamina value from FootController

        // Set HitText height based on screen size
        PerfectHit.transform.GetChild(0).transform.position = refCamera.ScreenToWorldPoint(new Vector2(Screen.width / 5f, Screen.height / 3.5f));
        NearMiss.transform.GetChild(0).transform.position = refCamera.ScreenToWorldPoint(new Vector2(Screen.width / 5f, Screen.height / 4f));
    }
	
	void Update ()
    {
        SetText(); // set values for Lives, Score
        if (isChallengeMode == false) // Story Mode
        {
            GoalProgress.value = CalculateProgress(); // set progressbar based on score
        }
        StaminaBar.value = CalculateStamina(); // set staminaBar based on stamina value from FootController

        // fade away PlusScore
        ScoreTimer -= Time.deltaTime;
        if (ScoreTimer <= 0)
        {
            PlusScore.alpha = 0f;
        }
        else if (ScoreTimer < 0.5f) // fade away
        {
            PlusScore.alpha -= 0.025f; // 40 frames to completely disapeard
            // move up
            PlusScore.rectTransform.transform.position = new Vector2(PlusScore.rectTransform.transform.position.x, PlusScore.rectTransform.transform.position.y + RaiseSpeed);
            DistanceRaised += RaiseSpeed;
        }
        else
        {
            PlusScore.rectTransform.transform.position = new Vector2(PlusScore.rectTransform.transform.position.x, PlusScore.rectTransform.transform.position.y + RaiseSpeed);
            DistanceRaised += RaiseSpeed;
        }

        // fade away Kick 
        TextTimer -= Time.deltaTime;
        if (TextTimer <= 0)
        {
            ClearKickText();
        }
        else if (TextTimer < 1.0f) // fade away
        {
            Color hColor = PerfectHit.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
            float alphaDiff1 = Mathf.Abs(hColor.a - hitAlpha);
            if (alphaDiff1 > 0.0001f)
            {
                hColor.a = Mathf.Lerp(hColor.a, hitAlpha, FadeRate * Time.deltaTime);
                PerfectHit.transform.GetChild(0).GetComponent<SpriteRenderer>().color = hColor;
            }

            Color mColor = NearMiss.GetComponentInChildren<SpriteRenderer>().color;
            float alphaDiff2 = Mathf.Abs(mColor.a - missAlpha);
            if (alphaDiff2 > 0.0001f)
            {
                mColor.a = Mathf.Lerp(mColor.a, missAlpha, FadeRate * Time.deltaTime);
                NearMiss.GetComponentInChildren<SpriteRenderer>().color = mColor;
            }
        }

        // fade away Streak(s)
        StreakTimer -= Time.deltaTime;
        if (StreakTimer <= 0)
        {
            ClearStreakText();
            isActive = false;
        }
        else if (StreakTimer < 5.0f) // fade away
        {
            Color gColor = GoodStreak.GetComponentInChildren<SpriteRenderer>().color;
            float alphaDiff3 = Mathf.Abs(gColor.a - goodAlpha);
            if (alphaDiff3 > 0.0001f)
            {
                gColor.a = Mathf.Lerp(gColor.a, goodAlpha, FadeRate * Time.deltaTime);
                GoodStreak.GetComponentInChildren<SpriteRenderer>().color = gColor;
            }

            Color pColor = PerfectStreak.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
            float alphaDiff4 = Mathf.Abs(pColor.a - perfectAlpha);
            if (alphaDiff4 > 0.0001f)
            {
                pColor.a = Mathf.Lerp(pColor.a, perfectAlpha, FadeRate * Time.deltaTime);
                PerfectStreak.transform.GetChild(0).GetComponent<SpriteRenderer>().color = pColor;
            }
        }

        if (isActive)
        {
            perfectStreak.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(refCamera.transform.position.x + (Screen.width / 2), refCamera.transform.position.y + (Screen.height / 2), 17));
            goodStreak.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(refCamera.transform.position.x + (Screen.width / 2), refCamera.transform.position.y + (Screen.height / 2), 17));
        }
    }

    void SetText()
    {
        Lives.text = GameManager.Instance.lives.ToString();
        Score.text = GameManager.Instance.Score.ToString();
    }

    public void SetPlusScore()
    {
        ScoreTimer = ScoreFadeDelay; // reset timer
        PlusScore.alpha = 1.0f; // unfade

        // move PlusScore to Foot Location
        PlusScore.rectTransform.transform.position = new Vector2(PlusScore.rectTransform.transform.position.x, PlusScore.rectTransform.transform.position.y - DistanceRaised);
        DistanceRaised = 0f;
        GameObject Foot = GameObject.Find("Foot");
        Vector2 pos = new Vector2(Foot.transform.position.x, Foot.transform.position.y + 0.25f); 
        Vector2 viewportPoint = refCamera.WorldToViewportPoint(pos);
        PlusScore.rectTransform.anchorMin = viewportPoint;
        PlusScore.rectTransform.anchorMax = viewportPoint;

        GameObject Ball = GameObject.Find("Ball");
        PlusScore.text = "+ " + Ball.GetComponent<AdvancedBall>().ScoreGain;
    }

    public void ClearPlusScore()
    {
        PlusScore.text = "";
    }

    float CalculateProgress()
    {
        // get LevelManager from the active level
        GameObject LevelManager = GameObject.Find("LevelManager");
        LevelManager LevelManagerScript = LevelManager.GetComponent<LevelManager>();

        // get the INTs and convert them to FLOATs
        float CurrentScore = GameManager.Instance.Score;
        float RequiredScore = LevelManagerScript.GetRequiredScore();

        // return progress percentage towards reaching ScoreNeeded
        return CurrentScore / RequiredScore;
    }

    float CalculateStamina()
    {
        float StaminaRatio = FootObj.GetComponent<FootController>().Stamina / FootObj.GetComponent<FootController>().MaxStamina;
        return StaminaRatio;
    }

    public void SetKickText()
    {
        HitFadeOut();

        GameObject Foot = GameObject.Find("Foot");
        switch (Foot.GetComponent<FootController>().KickType)
        {
            case 0:
                NearMiss.SetActive(true);
                ResetHitAlpha();
               
                // move NearMiss to X-Position of the Foot
                NearMiss.transform.GetChild(0).transform.position = new Vector2(Foot.transform.position.x, NearMiss.transform.GetChild(0).transform.position.y);

                // Check if and Correct Position if too close to the edge of the screen
                cameraPos = Camera.main.transform.position;
                screenSize.x = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
                RightBoundry = new Vector3(cameraPos.x + screenSize.x, cameraPos.y, 0);
                LeftBoundry = new Vector3(cameraPos.x - screenSize.x, cameraPos.y, 0);

                if (NearMiss.transform.GetChild(0).transform.position.x >= (RightBoundry.x - MarginOffset))
                {
                    NearMiss.transform.GetChild(0).transform.position = new Vector2(RightBoundry.x - MarginOffset, NearMiss.transform.GetChild(0).transform.position.y);
                }
                else if (NearMiss.transform.GetChild(0).transform.position.x <= (LeftBoundry.x + MarginOffset))
                {
                    NearMiss.transform.GetChild(0).transform.position = new Vector2(LeftBoundry.x + MarginOffset, NearMiss.transform.GetChild(0).transform.position.y);
                }
                break;

            case 1:
                break;

            case 2:
                break;

            case 3:
                PerfectHit.SetActive(true);
                ResetHitAlpha();

                // move NearMiss to X-Position of the Foot
                PerfectHit.transform.GetChild(0).transform.position = new Vector2(Foot.transform.position.x, PerfectHit.transform.GetChild(0).transform.position.y);

                // Check if and Correct Position if too close to the edge of the screen
                cameraPos = Camera.main.transform.position;
                screenSize.x = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
                RightBoundry = new Vector3(cameraPos.x + screenSize.x, cameraPos.y, 0);
                LeftBoundry = new Vector3(cameraPos.x - screenSize.x, cameraPos.y, 0);

                if (PerfectHit.transform.GetChild(0).transform.position.x >= (RightBoundry.x - MarginOffset))
                {
                    PerfectHit.transform.GetChild(0).transform.position = new Vector2(RightBoundry.x - MarginOffset, PerfectHit.transform.GetChild(0).transform.position.y);
                }
                else if (PerfectHit.transform.GetChild(0).transform.position.x <= (LeftBoundry.x + MarginOffset))
                {
                    PerfectHit.transform.GetChild(0).transform.position = new Vector2(LeftBoundry.x + MarginOffset, PerfectHit.transform.GetChild(0).transform.position.y);
                }
                break;
        }
    }

    public void ClearKickText()
    {
        PerfectHit.SetActive(false);
        NearMiss.SetActive(false);
    }

    private void ResetHitAlpha()
    {
        TextTimer = TextFadeDelay; // reset timer

        Color PerfectHitColor;
        PerfectHitColor = PerfectHit.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
        PerfectHit.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(PerfectHitColor.r, PerfectHitColor.g, PerfectHitColor.b, 1);

        Color NearMissColor;
        NearMissColor = NearMiss.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
        NearMiss.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(NearMissColor.r, NearMissColor.g, NearMissColor.b, 1);
    }

    public void SetStreakText()
    {
        isActive = true;
        StreakFadeOut();

        GameObject Foot = GameObject.Find("Foot");
        if (Foot.GetComponent<FootController>().PerfectBonus == true)
        {
            PerfectStreak.SetActive(true);
            ResetStreakAlpha();
        }
        else if (Foot.GetComponent<FootController>().GoodBonus == true)
        {
            GoodStreak.SetActive(true);
            ResetStreakAlpha();
        }
    }

    public void ClearStreakText()
    {
        GoodStreak.SetActive(false);
        PerfectStreak.SetActive(false);
    }

    private void ResetStreakAlpha()
    {
        StreakTimer = StreakFadeDelay; // reset timer

        Color PerfectColor;
        PerfectColor = PerfectStreak.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
        PerfectStreak.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(PerfectColor.r, PerfectColor.g, PerfectColor.b, 1);

        Color GoodColor;
        GoodColor = GoodStreak.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
        GoodStreak.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(GoodColor.r, GoodColor.g, GoodColor.b, 1);
    }

    private void StreakFadeOut()
    {
        goodAlpha = 0f;
        perfectAlpha = 0f;
    }

    private void HitFadeOut()
    {
        hitAlpha = 0f;
        missAlpha = 0f;
    }
}

