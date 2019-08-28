using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;

public class AdvancedBall : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject Canvas;
    public GameObject Target;
    public GameObject Foot;
    public GameObject Bird;
    public GameObject BallObject; // parent used for scaling on Arbitary Axis for squishing effect
    public GameObject Popup;
    public bool WindBlowing;
    
    public Camera refCamera;
    public Sprite[] AnimalSprite1;
    public Sprite[] AnimalSprite2;
    public GameObject PartSys;
    public ParticleSystem ParticleLauncher;
    public GameObject PartSysDeath;
    public ParticleSystem ParticleLauncherDeath;
    public GameObject PartSysPerfect;
    public ParticleSystem ParticleLauncherPerfect;
    public GameObject PartSysGood;
    public ParticleSystem ParticleLauncherGood;
    //public GameObject DeadPartSys;
    //public ParticleSystem DeadParticleLauncher;

    // AudioSources
    public AudioSource Audio_HitGround;
    public AudioSource Audio_SlowMotion;
    public AudioSource Source;
    public AudioClip[] audiocliparray;
    public int SoundNumber;

    private Vector2 AnimatedFallSpeed = new Vector2(0f, -12f);
    private Vector3 AnimatedResetLocation = new Vector3(0f, 6f, 0f);
    private Vector3 StartingLocation = new Vector3(0f, -2.5f, 0f);
    private Quaternion StartingRotation = Quaternion.Euler(0, 0, 0);

    public bool isChallengeMode;
    public bool ChallengeRewardRecieved;
    public bool StoryLevelBallReward;

    private bool NotBlinking = true;
    private bool AlreadyAnimatingFoot = false;
    private bool FirstKick;
    private bool ResetAnimation = false;
    private bool NearEndOfLevel = false;
    private bool isHorizontalAmplificaion_Center = false;
    private bool isHorizontalAmplificaion_OffCenter = false;
    private bool isHorizontalAmplificaion_NearEdge = false;
    private bool isHorizontalAmplificaion_Edge = false;

    [HideInInspector] public int ScoreGain = 1; // to display on screen how much was gained

    private float BlinkTimer = 5;
    private float JustKicked;
    private float KickedTimer = 0.25f; // time before can kick again
    private float ResetDelay = 1.0f; // needed to allow for animations to play out
    private float BallExplodeTimer = 1.25f;
    private float KickCounter; // number of kicks towards switching skins (set to zero everytime skin changes)
    private float KicksToBallSwap = 5; // skin switches every this number of kicks
    private float BallGravityRatio;
    private float SlowMotionSpeed = 0.75f;

    // Ball Rotation
    private float HardTorque    = 65.0f;   // 65
    private float MediumTorque  = 50.0f;   // 50
    private float SoftTorque    = 35.0f;   // 35
    private float SlightTorque  = 10.0f;   // 10
    private float WallHitTorque = 40.0f;   // 40

    // the following [HideInInspector] variables are set differently in each level (see LevelScripts)
    [HideInInspector] public float BallGravityScale = 1.45f;      // Gravity strength,
    [HideInInspector] public float BallIntensifedGravity = 1.45f; // Gravity strength near end of Level
    [HideInInspector] public float VelocityDampening_X = 0f;      // gradual X-Dampening,   

    // ball hit areas, for determining spin
    private float HorizontalAmplificaion_Center = 0.25f;
    private float HorizontalAmplificaion_OffCenter = 1.0f;
    private float HorizontalAmplificaion_NearEdge = 1.0f;
    private float HorizontalAmplificaion_Edge = 1.25f;

    // determines force applied from kick
    private float KickForce = 8f; 


    private void Awake()
    {
        Source = GetComponent<AudioSource>();
    }

    void Start()
    {
        // set ball sprite
        GameManager.Instance.AnimalNum = PlayerPrefs.GetInt("AnimalNumSave");
        //gameObject.GetComponent<SpriteRenderer>().sprite = AnimalSprite1[GameManager.Instance.AnimalNum];

        // Set BALL SOUND
        SoundNumber = PlayerPrefs.GetInt("AnimalNumSave");
        Source.clip = audiocliparray[SoundNumber];

        // last chance enabled
        PlayerPrefs.SetInt("LastChance", 1);

        // determine which Game Mode
        if (PlayerPrefs.GetInt("ChallengeMode") == 1)
        {
            isChallengeMode = true;
        }
        else
        {
            isChallengeMode = false;
        }

        // set ball to starting location and properties
        rb = this.GetComponent<Rigidbody2D>();
        SetBallProperties();
        rb.gravityScale = BallGravityScale * BallGravityRatio;
        rb.transform.position = StartingLocation;
        rb.transform.rotation = StartingRotation;
        FirstKick = true;
        
        WindBlowing = false; // Disable wind
    }

    void FixedUpdate()
    {
        // BALL PHYSICS ------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------

        JustKicked -= Time.deltaTime;
        BlinkTimer -= Time.deltaTime;

        // gravity off until ball is hit
        if (FirstKick)
        {
            rb.gravityScale = 0f;
        }
        else if (NearEndOfLevel)
        {
            rb.gravityScale = BallIntensifedGravity * BallGravityRatio;
        }
        else if (!ResetAnimation)
        {
            rb.gravityScale = BallGravityScale * BallGravityRatio;
        }

        // X-Velocity Dampening
        if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x - VelocityDampening_X, rb.velocity.y); // Right
            if (rb.velocity.x < 0f)
                rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else if (rb.velocity.x < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x + VelocityDampening_X, rb.velocity.y); // Left
            if (rb.velocity.x > 0f)
                rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // Torque Dampening
        if (rb.angularVelocity > 5.0f)
        {
            rb.angularVelocity -= 1.0f;
        }
        else if (rb.angularVelocity > 2.0f)
        {
            rb.angularVelocity -= 0.5f;
        }
        else if (rb.angularVelocity > 0.25f)
        {
            rb.angularVelocity -= 0.25f;
        }
        else if (rb.angularVelocity < -5.0f)
        {
            rb.angularVelocity += 1.0f;
        }
        else if (rb.angularVelocity < -2.0f)
        {
            rb.angularVelocity += 0.5f;
        }
        else if (rb.angularVelocity > -0.25f)
        {
            rb.angularVelocity += 0.25f;
        }
        else
        {
            rb.angularVelocity = 0;
        }

        // -------------------------------------------------------------------------------------

        // RESET BALL --------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------
        if (ResetAnimation)
        {
            // stop falling, once at starting location
            if (rb.transform.position.y <= StartingLocation.y)
            {
                rb.gravityScale = 0f; // turn off ball gravity
                rb.velocity = new Vector2(0, 0);
                rb.transform.position = StartingLocation;
                rb.transform.rotation = StartingRotation;
                FirstKick = true;
                ResetAnimation = false; // End this Logic
            }
        }

        // -------------------------------------------------------------------------------------
    }

    private void Update()
    {
        // BLINK Animation ----------------------------
        //GameManager.Instance.AnimalNum = PlayerPrefs.GetInt("AnimalNumSave");

        //SoundNumber = PlayerPrefs.GetInt("AnimalNumSave");
        //Source.clip = audiocliparray[SoundNumber];


        gameObject.GetComponent<SpriteRenderer>().sprite = AnimalSprite1[GameManager.Instance.AnimalNum];

        //if (BlinkTimer >= 0)
        //{
        //    NotBlinking = true;
        //}
        //else
        //{
        //    NotBlinking = false;
        //}

        //if (NotBlinking == true)
        //{
        //    gameObject.GetComponent<SpriteRenderer>().sprite = AnimalSprite1[GameManager.Instance.AnimalNum];
        //}
        //else if (NotBlinking == false)
        //{
        //    gameObject.GetComponent<SpriteRenderer>().sprite = AnimalSprite2[GameManager.Instance.AnimalNum];
        //    StartCoroutine(Blink());
        //}

        // ---------------------------------------------
    }

    public void UpdateBallSound()
    {
        // Set BALL SOUND
        SoundNumber = PlayerPrefs.GetInt("AnimalNumSave");
        Source.clip = audiocliparray[SoundNumber];
    }

    IEnumerator Blink()
    {
        yield return new WaitForSeconds(.5f);
        BlinkTimer = 5;
        //NotBlinking = true;
    }

    public void GameOver()
    {
        // Disable collisons
        this.GetComponent<CircleCollider2D>().enabled = false;

        GameManager.Instance.lives -= 1;

        if (GameManager.Instance.lives >= 0)
        {
            BallAnimatedReset();
            Foot.GetComponent<FootController>().AnimatedFootReturn();
            Foot.GetComponent<FootController>().SetInputDisabled();
            Foot.GetComponent<FootController>().SetStartingFootSize();

            // delays ball reset so the bird has time to cross the screen (prevents a bug where ball hits birds during reset)
            SpecialReset();      
        }
        else if (!AlreadyAnimatingFoot) // lives <= 0
        {
            if (PlayerPrefs.GetInt("LastChance") == 1)
            {
                // open LastChancePopup
                Popup.SetActive(true);
                Popup.GetComponent<PopupTransition>().AnimatedPopup();
            }
            else // LastChance == 0
            {
                // set top score
                GameObject LevelManager = GameObject.Find("LevelManager");
                LevelManager.GetComponent<LevelManager>().SetHighScore();
                lossConditionAnalytics();

                PlayerPrefs.SetInt("LastChance", 1);
                PlayerPrefs.SetInt("EndMenuActive", 1); // active EndMenu
                AlreadyAnimatingFoot = true;
                Foot.GetComponent<FootController>().AnimatedFootRetrevial();
                Foot.GetComponent<FootController>().SetInputDisabled();
                if (IsInvoking("FootRestart"))
                    CancelInvoke("FootRestart");
            }
        }
    }

    private void SpecialReset ()
    {
        Bird.GetComponent<Bird>().CheckIfOnScreen();

        // bird on left side of where screen will reset to, safe to do ballreset
        if (Bird.transform.position.x < (-Screen.width/2))
        {
            // Reset
            Debug.Log("BirdReset: bird was offscreen on LEFT");
            CancelInvoke("SpecialReset");
            Bird.GetComponent<Bird>().ResetBird();
            Bird.GetComponent<Bird>().DelayEncounter();
            Invoke("FootRestart", ResetDelay);
        }
        else if (Bird.GetComponent<Bird>().OnScreen == true) // bird on screen
        {
            // wait longer
            if (!IsInvoking("SpecialReset"))
                Invoke("SpecialReset", 0.05f);
        }
        else // bird on right side of screen, safe to do ballreset
        {
            // Reset
            Debug.Log("BirdReset: bird was offscreen on RIGHT");
            CancelInvoke("SpecialReset");
            Bird.GetComponent<Bird>().ResetBird();
            Bird.GetComponent<Bird>().DelayEncounter();
            Invoke("FootRestart", ResetDelay);
        }
    }

    public void SafeReset()
    {
        // Disable collisons
        this.GetComponent<CircleCollider2D>().enabled = false;

        BallAnimatedReset();
        Foot.GetComponent<FootController>().AnimatedFootReturn();
        Foot.GetComponent<FootController>().SetInputDisabled();
        Foot.GetComponent<FootController>().SetStartingFootSize();
        if (!IsInvoking("FootRestart"))
            Invoke("FootRestart", ResetDelay);
    }

    public void EndGame()
    {
        //Debug.Log("Go to EndMenu");
        PlayerPrefs.SetInt("LastChance", 1);
        PlayerPrefs.SetInt("EndMenuActive", 1); // active EndMenu
        AlreadyAnimatingFoot = true;
        Foot.GetComponent<FootController>().AnimatedFootRetrevial();
        Foot.GetComponent<FootController>().SetInputDisabled();
        if (IsInvoking("FootRestart"))
            CancelInvoke("FootRestart");

        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    private void BallAnimatedReset()
    {
        // start at top of screen
        rb.transform.position = AnimatedResetLocation;
        rb.transform.rotation = StartingRotation;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        // fall at constant speed
        rb.gravityScale = 0f;
        rb.velocity = AnimatedFallSpeed;

        // Handle Movement in FixedUpdate()
        ResetAnimation = true;
    }

    public void FootRestart()
    {
        rb.constraints = RigidbodyConstraints2D.None;
        Foot.GetComponent<FootController>().Restart();
        // Enable collisons
        this.GetComponent<CircleCollider2D>().enabled = true;
    }

    private void SlowMotion()
    {
        Audio_SlowMotion.Play();

        Time.timeScale = SlowMotionSpeed;
        Foot.GetComponent<FootController>().SlowMotionTimer = 1; // ends slowmotion after this number of kicks
    }

    // remove SlowMotion early on certain conditions
    public void NormalMotion()
    {
        Time.timeScale = 1.0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                Source.PlayOneShot(Source.clip);

                // triggers the ball to squish
                BallObject.GetComponent<SquishBall>().JustGotKicked();

                // move particle effect to ball location
                PartSys.transform.position = transform.position;

                if (JustKicked <= 0)
                {
                    ParticleLauncher.Play();

                    GameManager.Instance.ScoreResetCounter++;
                    if(GameManager.Instance.ScoreResetCounter >= 5)
                    {
                        StartCoroutine(Timer());
                    }

                    // check if near end of level
                    GameObject LevelManager = GameObject.Find("LevelManager");
                    if (GameManager.Instance.Score >= LevelManager.GetComponent<LevelManager>().ScoreNeeded * 0.90f)
                    {
                        NearEndOfLevel = true;
                    }

                    WindBlowing = true; // Enable wind
                    FirstKick = false;
                    JustKicked = KickedTimer;
                    KickCounter += 1;
                    if (KickCounter >= KicksToBallSwap)
                    {
                        KickCounter = 0;
                    }
                    rb = this.GetComponent<Rigidbody2D>();

                    // stop falling
                    rb.velocity = new Vector2(rb.velocity.x, 0);

                    // determine Kick Direction
                    var heading = transform.position - Target.transform.position;

                    // modify Direction.x if hit on the far sides
                    if (heading.x > 0.9f) 
                    {
                        isHorizontalAmplificaion_Center = false;
                        isHorizontalAmplificaion_OffCenter = false;
                        isHorizontalAmplificaion_NearEdge = false;
                        isHorizontalAmplificaion_Edge = true;
                        heading.x = 0.9f;
                    }
                    else if (heading.x < -0.9f)
                    {
                        isHorizontalAmplificaion_Center = false;
                        isHorizontalAmplificaion_OffCenter = false;
                        isHorizontalAmplificaion_NearEdge = false;
                        isHorizontalAmplificaion_Edge = true;
                        heading.x = -0.9f;
                    }
                    // modif Direction.x if hit in middle but closer to Edge
                    else if (heading.x < 0.9f && heading.x > 0.5f) 
                    {
                        isHorizontalAmplificaion_Center = false;
                        isHorizontalAmplificaion_OffCenter = false;
                        isHorizontalAmplificaion_NearEdge = true;
                        isHorizontalAmplificaion_Edge = false;
                    }
                    else if (heading.x > -0.9f && heading.x < -0.5f)
                    {
                        isHorizontalAmplificaion_Center = false;
                        isHorizontalAmplificaion_OffCenter = false;
                        isHorizontalAmplificaion_NearEdge = true;
                        isHorizontalAmplificaion_Edge = false;
                    }
                    // modif Direction.x if hit in middle but closer to Center
                    else if (heading.x < 0.5f && heading.x > 0.2f)
                    {
                        isHorizontalAmplificaion_Center = false;
                        isHorizontalAmplificaion_OffCenter = true;
                        isHorizontalAmplificaion_NearEdge = false;
                        isHorizontalAmplificaion_Edge = false;
                    }
                    else if (heading.x > -0.5f && heading.x < -0.2f)
                    {
                        isHorizontalAmplificaion_Center = false;
                        isHorizontalAmplificaion_OffCenter = true;
                        isHorizontalAmplificaion_NearEdge = false;
                        isHorizontalAmplificaion_Edge = false;
                    }
                    // modif Direction.x if hit very close to centre
                    else
                    {
                        isHorizontalAmplificaion_Center = true;
                        isHorizontalAmplificaion_OffCenter = false;
                        isHorizontalAmplificaion_NearEdge = false;
                        isHorizontalAmplificaion_Edge = false;
                    }

                    // set Direction for below calculations
                    Vector2 Direction = new Vector2(heading.x, heading.y);

                    // add kick force
                    rb.AddForce(Direction * KickForce, ForceMode2D.Impulse);

                    // adjust horizontal velocity
                    if (isHorizontalAmplificaion_Center == true) 
                    {
                        isHorizontalAmplificaion_Center = false;
                        rb.velocity = new Vector2(rb.velocity.x * HorizontalAmplificaion_Center, rb.velocity.y);
                    }
                    else if (isHorizontalAmplificaion_OffCenter == true)
                    {
                        isHorizontalAmplificaion_OffCenter = false;
                        rb.velocity = new Vector2(rb.velocity.x * HorizontalAmplificaion_OffCenter, rb.velocity.y);
                    }
                    else if (isHorizontalAmplificaion_NearEdge == true)
                    {
                        isHorizontalAmplificaion_NearEdge = false;
                        rb.velocity = new Vector2(rb.velocity.x * HorizontalAmplificaion_NearEdge, rb.velocity.y);
                    }
                    else if (isHorizontalAmplificaion_Edge == true)
                    {
                        isHorizontalAmplificaion_Edge = false;
                        rb.velocity = new Vector2(rb.velocity.x * HorizontalAmplificaion_Edge, rb.velocity.y);
                    }

                    // ROTATE based on Kick Direction
                    // + CounterClockwise, - Clockwise
                    if (Direction.x <= 0.2f && Direction.x >= -0.2f) // -0.2 to 0.2
                    {
                        int rand = Random.Range(0, 1);

                        if (rand == 0)
                        {
                            //rb.angularVelocity = 0f;
                            rb.AddTorque(-SlightTorque, ForceMode2D.Force); // right
                        }
                        else
                        {
                            //rb.angularVelocity = 0f;
                            rb.AddTorque(SlightTorque, ForceMode2D.Force); // left
                        }
                    }
                    else if (Direction.x > 0.2f && Direction.x <= 0.4f) // 0.2 to 0.4
                    {
                        //rb.angularVelocity = 0f;
                        rb.AddTorque(-SoftTorque, ForceMode2D.Force);
                    }
                    else if (Direction.x > 0.4f && Direction.x <= 0.75f) // 0.4 to 0.75
                    {
                        //rb.angularVelocity = 0f;
                        rb.AddTorque(-MediumTorque, ForceMode2D.Force);
                    }
                    else if (Direction.x > 0f) // 0.75 to 1.0
                    {
                        //rb.angularVelocity = 0f;
                        rb.AddTorque(-HardTorque, ForceMode2D.Force);
                    }
                    else if (Direction.x < -0.2f && Direction.x <= -0.4f) // -0.2 to -0.4
                    {
                        //rb.angularVelocity = 0f;
                        rb.AddTorque(SoftTorque, ForceMode2D.Force);
                    }
                    else if (Direction.x < -0.4f && Direction.x <= -0.75f) // -0.4 to -0.75
                    {
                        //rb.angularVelocity = 0f;
                        rb.AddTorque(MediumTorque, ForceMode2D.Force);
                    }
                    else if (Direction.x < 0f) // -0.75 to -1.0
                    {
                        //rb.angularVelocity = 0f;
                        rb.AddTorque(HardTorque, ForceMode2D.Force);
                    }
                    else // Vertical
                    {
                        int rand = Random.Range(0, 1);

                        if (rand == 0)
                        {
                            //rb.angularVelocity = 0f;
                            rb.AddTorque(-SlightTorque, ForceMode2D.Force); // right
                        }
                        else
                        {
                            //rb.angularVelocity = 0f;
                            rb.AddTorque(SlightTorque, ForceMode2D.Force); // left
                        }
                    }
                }
                break;

            case "Wall":
                if (rb.velocity.x > 0) // right wall
                {
                    if (rb.velocity.x > 7.5f)
                    {
                        rb.angularVelocity = 0f;
                        rb.AddTorque(-WallHitTorque, ForceMode2D.Force); // rotate left
                    }
                    else if (rb.velocity.x > 5f)
                    {
                        rb.angularVelocity = 0f;
                        rb.AddTorque(-WallHitTorque*0.8f, ForceMode2D.Force); // rotate left
                    }
                    else if (rb.velocity.x > 2.5f)
                    {
                        rb.angularVelocity = 0f;
                        rb.AddTorque(-WallHitTorque*0.6f, ForceMode2D.Force); // rotate left
                    }
                    else
                    {
                        rb.angularVelocity = 0f;
                        rb.AddTorque(-WallHitTorque*0.4f, ForceMode2D.Force); // rotate left
                    }

                }
                else // left wall
                {
                    if (rb.velocity.x < -7.5f)
                    {
                        rb.angularVelocity = 0f;
                        rb.AddTorque(WallHitTorque, ForceMode2D.Force); // rotate left
                    }
                    else if (rb.velocity.x < -5f)
                    {
                        rb.angularVelocity = 0f;
                        rb.AddTorque(WallHitTorque * 0.8f, ForceMode2D.Force); // rotate left
                    }
                    else if (rb.velocity.x < -2.5f)
                    {
                        rb.angularVelocity = 0f;
                        rb.AddTorque(WallHitTorque * 0.6f, ForceMode2D.Force); // rotate left
                    }
                    else
                    {
                        rb.angularVelocity = 0f;
                        rb.AddTorque(WallHitTorque * 0.4f, ForceMode2D.Force); // rotate left
                    }
                }
                break;
        }

        if (collision.gameObject.name == "BottomCollider")
        {
            Audio_HitGround.Play();

            // Disable wind
            WindBlowing = false;

            NormalMotion(); // remove slowMotion if active

            // start particle effect at location
            PartSysDeath.transform.position = transform.position;
            ParticleLauncherDeath.Play();
            // move ball off screen
            transform.position = new Vector2(0f, 100f);

            // handle loss event
            Bird.GetComponent<Bird>().DelayEncounter();
            Foot.GetComponent<FootController>().SetInputDisabled();
            Foot.GetComponent<FootController>().ResetFoot();
            refCamera.GetComponent<CameraMotor>().CenterCamera();

            if (PlayerPrefs.GetInt("LastChance") == 1)
            {
                Invoke("GameOver", BallExplodeTimer);
            }
            else 
            {
                Invoke("EndGame", BallExplodeTimer);
            }
        }
    }

    public void GainScore()
    {
        GameObject LM = GameObject.Find("LevelManager"); // Reference used for GAIN SCORE "if statments"

        // GAIN SCORE
        if (Foot.GetComponent<FootController>().PerfectBonus)
        {
            Foot.GetComponent<FootController>().PerfectBonus = false; // do this once per PerfectBonus
            PartSysPerfect.transform.position = transform.position;
            ParticleLauncherPerfect.Play();

            GameManager.Instance.Score += 20; // Score +20
            ScoreGain = 20; // set variable to reference how much was gained

            GameObject Canvas = GameObject.Find("Canvas");
            Canvas.GetComponent<GameUI>().SetPlusScore(); // display on screen score gained

            // Don't Exceed Max Score for that level (only on Story mode)
            if (isChallengeMode == false)
            {
                if (GameManager.Instance.Score > LM.GetComponent<LevelManager>().ScoreNeeded)
                    GameManager.Instance.Score = LM.GetComponent<LevelManager>().ScoreNeeded;
            }

            // 2 seconds of SlowMotion
            SlowMotion();
            //Invoke("NormalMotion", 2f);
        }
        else if (Foot.GetComponent<FootController>().GoodBonus)
        {
            Foot.GetComponent<FootController>().GoodBonus = false; // do this once per GoodBonus
            PartSysGood.transform.position = transform.position;
            ParticleLauncherGood.Play();
            if (Foot.GetComponent<FootController>().KickType == 3)
            {
                GameManager.Instance.Score += 6; // Score +6
                ScoreGain = 6; // set variable to reference how much was gained
            }
            else
            {
                GameManager.Instance.Score += 5; // Score +5
                ScoreGain = 5; // set variable to reference how much was gained
            }
            
            // display on screen score gained
            GameObject Canvas = GameObject.Find("Canvas");
            Canvas.GetComponent<GameUI>().SetPlusScore(); 

            // Don't Exceed Max Score for that level (only on Story mode)
            if (isChallengeMode == false)
            {
                if (GameManager.Instance.Score > LM.GetComponent<LevelManager>().ScoreNeeded)
                    GameManager.Instance.Score = LM.GetComponent<LevelManager>().ScoreNeeded;
            }

            // 2 seconds of SlowMotion
            SlowMotion();
            //Invoke("NormalMotion", 2f);
        }
        else if (Foot.GetComponent<FootController>().KickType == 3)
        {
            GameManager.Instance.Score += 2; // Score +2
            ScoreGain = 2; // set variable to reference how much was gained

            GameObject Canvas = GameObject.Find("Canvas");
            Canvas.GetComponent<GameUI>().SetPlusScore(); // display on screen score gained

            // Don't Exceed Max Score for that level (only on Story mode)
            if (isChallengeMode == false)
            {
                if (GameManager.Instance.Score > LM.GetComponent<LevelManager>().ScoreNeeded)
                    GameManager.Instance.Score = LM.GetComponent<LevelManager>().ScoreNeeded;
            }
        }
        else // Nothing special
        {
            GameManager.Instance.Score += 1;
            ScoreGain = 1;

           // GameManager.Instance.Score++; // Score +1
           // ScoreGain = 1;

            GameObject Canvas = GameObject.Find("Canvas");
            Canvas.GetComponent<GameUI>().SetPlusScore();

            // Don't Exceed Max Score for that level (only on Story mode)
            if (isChallengeMode == false)
            {
                if (GameManager.Instance.Score > LM.GetComponent<LevelManager>().ScoreNeeded)
                    GameManager.Instance.Score = LM.GetComponent<LevelManager>().ScoreNeeded;
            }
        }

        // Set TopScore
        if (GameManager.Instance.Score > GameManager.Instance.TopScore)
        {
            GameManager.Instance.TopScore = GameManager.Instance.Score;
            PlayerPrefs.SetInt("ScoreSave", GameManager.Instance.TopScore);
        }

        // ON SCREEN REWARDS (Challenge Mode)
        if (isChallengeMode && !ChallengeRewardRecieved)
        {
            if (GameManager.Instance.Score >= LM.GetComponent<LevelManager>().ChallengeThreshold)
            {
                ChallengeRewardRecieved = true;

                // check if you've got the reward for this level yet
                switch (LM.GetComponent<LevelManager>().Level)
                {
                    case 1:
                        if (PlayerPrefs.GetInt("Challenge_01") == 0)
                        {
                            // Display Reward
                            Canvas.GetComponent<Rewards>().DisplayChallengeReward(); // canvas.Rewards

                            // hide foot/ball
                            transform.position = new Vector2(0, 100);
                            Foot.GetComponent<FootController>().HideFoot();
                            WindBlowing = false;
                            FirstKick = true;

                            // pause
                            Foot.GetComponent<FootController>().isPaused = true;
                            Foot.GetComponent<FootController>().ChallengePause = true;
                            Time.timeScale = 0f;

                            Foot.GetComponent<FootController>().SetInputEnabled(); // make sure you can unpause

                            //hide plusScore Text
                            Canvas.GetComponent<GameUI>().ClearPlusScore();
                        }
                        break;

                    case 2:
                        if (PlayerPrefs.GetInt("Challenge_02") == 0)
                        {
                            // Display Reward
                            Canvas.GetComponent<Rewards>().DisplayChallengeReward(); // canvas.Rewards

                            // hide foot/ball
                            transform.position = new Vector2(0, 100);
                            Foot.GetComponent<FootController>().HideFoot();
                            WindBlowing = false;
                            FirstKick = true;

                            // pause
                            Foot.GetComponent<FootController>().isPaused = true;
                            Foot.GetComponent<FootController>().ChallengePause = true;
                            Time.timeScale = 0f;

                            Foot.GetComponent<FootController>().SetInputEnabled(); // make sure you can unpause

                            //hide plusScore Text
                            Canvas.GetComponent<GameUI>().ClearPlusScore();
                        }
                        break;

                    case 3:
                        if (PlayerPrefs.GetInt("Challenge_03") == 0)
                        {
                            // Display Reward
                            Canvas.GetComponent<Rewards>().DisplayChallengeReward(); // canvas.Rewards

                            // hide foot/ball
                            transform.position = new Vector2(0, 100);
                            Foot.GetComponent<FootController>().HideFoot();
                            WindBlowing = false;
                            FirstKick = true;

                            // pause
                            Foot.GetComponent<FootController>().isPaused = true;
                            Foot.GetComponent<FootController>().ChallengePause = true;
                            Time.timeScale = 0f;

                            Foot.GetComponent<FootController>().SetInputEnabled(); // make sure you can unpause

                            //hide plusScore Text
                            Canvas.GetComponent<GameUI>().ClearPlusScore();
                        }
                        break;

                    case 4:
                        if (PlayerPrefs.GetInt("Challenge_04") == 0)
                        {
                            // Display Reward
                            Canvas.GetComponent<Rewards>().DisplayChallengeReward(); // canvas.Rewards

                            // hide foot/ball
                            transform.position = new Vector2(0, 100);
                            Foot.GetComponent<FootController>().HideFoot();
                            WindBlowing = false;
                            FirstKick = true;

                            // pause
                            Foot.GetComponent<FootController>().isPaused = true;
                            Foot.GetComponent<FootController>().ChallengePause = true;
                            Time.timeScale = 0f;

                            Foot.GetComponent<FootController>().SetInputEnabled(); // make sure you can unpause

                            //hide plusScore Text
                            Canvas.GetComponent<GameUI>().ClearPlusScore();
                        }
                        break;

                    case 5:
                        if (PlayerPrefs.GetInt("Challenge_05") == 0)
                        {
                            // Display Reward
                            Canvas.GetComponent<Rewards>().DisplayChallengeReward(); // canvas.Rewards

                            // hide foot/ball
                            transform.position = new Vector2(0, 100);
                            Foot.GetComponent<FootController>().HideFoot();
                            WindBlowing = false;
                            FirstKick = true;

                            // pause
                            Foot.GetComponent<FootController>().isPaused = true;
                            Foot.GetComponent<FootController>().ChallengePause = true;
                            Time.timeScale = 0f;

                            Foot.GetComponent<FootController>().SetInputEnabled(); // make sure you can unpause

                            //hide plusScore Text
                            Canvas.GetComponent<GameUI>().ClearPlusScore();
                        }
                        break;

                    case 6:
                        if (PlayerPrefs.GetInt("Challenge_06") == 0)
                        {
                            // Display Reward
                            Canvas.GetComponent<Rewards>().DisplayChallengeReward(); // canvas.Rewards

                            // hide foot/ball
                            transform.position = new Vector2(0, 100);
                            Foot.GetComponent<FootController>().HideFoot();
                            WindBlowing = false;
                            FirstKick = true;

                            // pause
                            Foot.GetComponent<FootController>().isPaused = true;
                            Foot.GetComponent<FootController>().ChallengePause = true;
                            Time.timeScale = 0f;

                            Foot.GetComponent<FootController>().SetInputEnabled(); // make sure you can unpause

                            //hide plusScore Text
                            Canvas.GetComponent<GameUI>().ClearPlusScore();
                        }
                        break;

                    case 7:
                        if (PlayerPrefs.GetInt("Challenge_07") == 0)
                        {
                            // Display Reward
                            Canvas.GetComponent<Rewards>().DisplayChallengeReward(); // canvas.Rewards

                            // hide foot/ball
                            transform.position = new Vector2(0, 100);
                            Foot.GetComponent<FootController>().HideFoot();
                            WindBlowing = false;
                            FirstKick = true;

                            // pause
                            Foot.GetComponent<FootController>().isPaused = true;
                            Foot.GetComponent<FootController>().ChallengePause = true;
                            Time.timeScale = 0f;

                            Foot.GetComponent<FootController>().SetInputEnabled(); // make sure you can unpause

                            //hide plusScore Text
                            Canvas.GetComponent<GameUI>().ClearPlusScore();
                        }
                        break;

                    case 8:
                        if (PlayerPrefs.GetInt("Challenge_08") == 0)
                        {
                            // Display Reward
                            Canvas.GetComponent<Rewards>().DisplayChallengeReward(); // canvas.Rewards

                            // hide foot/ball
                            transform.position = new Vector2(0, 100);
                            Foot.GetComponent<FootController>().HideFoot();
                            WindBlowing = false;
                            FirstKick = true;

                            // pause
                            Foot.GetComponent<FootController>().isPaused = true;
                            Foot.GetComponent<FootController>().ChallengePause = true;
                            Time.timeScale = 0f;

                            Foot.GetComponent<FootController>().SetInputEnabled(); // make sure you can unpause

                            //hide plusScore Text
                            Canvas.GetComponent<GameUI>().ClearPlusScore();
                        }
                        break;

                    case 9:
                        if (PlayerPrefs.GetInt("Challenge_09") == 0)
                        {
                            // Display Reward
                            Canvas.GetComponent<Rewards>().DisplayChallengeReward(); // canvas.Rewards

                            // hide foot/ball
                            transform.position = new Vector2(0, 100);
                            Foot.GetComponent<FootController>().HideFoot();
                            WindBlowing = false;
                            FirstKick = true;

                            // pause
                            Foot.GetComponent<FootController>().isPaused = true;
                            Foot.GetComponent<FootController>().ChallengePause = true;
                            Time.timeScale = 0f;

                            Foot.GetComponent<FootController>().SetInputEnabled(); // make sure you can unpause

                            //hide plusScore Text
                            Canvas.GetComponent<GameUI>().ClearPlusScore();
                        }
                        break;

                    case 10:
                        if (PlayerPrefs.GetInt("Challenge_10") == 0)
                        {
                            // Display Reward
                            Canvas.GetComponent<Rewards>().DisplayChallengeReward(); // canvas.Rewards

                            // hide foot/ball
                            transform.position = new Vector2(0, 100);
                            Foot.GetComponent<FootController>().HideFoot();
                            WindBlowing = false;
                            FirstKick = true;

                            // pause
                            Foot.GetComponent<FootController>().isPaused = true;
                            Foot.GetComponent<FootController>().ChallengePause = true;
                            Time.timeScale = 0f;

                            Foot.GetComponent<FootController>().SetInputEnabled(); // make sure you can unpause

                            //hide plusScore Text
                            Canvas.GetComponent<GameUI>().ClearPlusScore();
                        }
                        break;

                    case 11:
                        if (PlayerPrefs.GetInt("Challenge_11") == 0)
                        {
                            // Display Reward
                            Canvas.GetComponent<Rewards>().DisplayChallengeReward(); // canvas.Rewards

                            // hide foot/ball
                            transform.position = new Vector2(0, 100);
                            Foot.GetComponent<FootController>().HideFoot();
                            WindBlowing = false;
                            FirstKick = true;

                            // pause
                            Foot.GetComponent<FootController>().isPaused = true;
                            Foot.GetComponent<FootController>().ChallengePause = true;
                            Time.timeScale = 0f;

                            Foot.GetComponent<FootController>().SetInputEnabled(); // make sure you can unpause

                            //hide plusScore Text
                            Canvas.GetComponent<GameUI>().ClearPlusScore();
                        }
                        break;

                    case 12:
                        if (PlayerPrefs.GetInt("Challenge_12") == 0)
                        {
                            // Display Reward
                            Canvas.GetComponent<Rewards>().DisplayChallengeReward(); // canvas.Rewards

                            // hide foot/ball
                            transform.position = new Vector2(0, 100);
                            Foot.GetComponent<FootController>().HideFoot();
                            WindBlowing = false;
                            FirstKick = true;

                            // pause
                            Foot.GetComponent<FootController>().isPaused = true;
                            Foot.GetComponent<FootController>().ChallengePause = true;
                            Time.timeScale = 0f;

                            Foot.GetComponent<FootController>().SetInputEnabled(); // make sure you can unpause

                            //hide plusScore Text
                            Canvas.GetComponent<GameUI>().ClearPlusScore();
                        }
                        break;

                    case 13:
                        if (PlayerPrefs.GetInt("Challenge_13") == 0)
                        {
                            // Display Reward
                            Canvas.GetComponent<Rewards>().DisplayChallengeReward(); // canvas.Rewards

                            // hide foot/ball
                            transform.position = new Vector2(0, 100);
                            Foot.GetComponent<FootController>().HideFoot();
                            WindBlowing = false;
                            FirstKick = true;

                            // pause
                            Foot.GetComponent<FootController>().isPaused = true;
                            Foot.GetComponent<FootController>().ChallengePause = true;
                            Time.timeScale = 0f;

                            Foot.GetComponent<FootController>().SetInputEnabled(); // make sure you can unpause

                            //hide plusScore Text
                            Canvas.GetComponent<GameUI>().ClearPlusScore();
                        }
                        break;

                    case 14:
                        if (PlayerPrefs.GetInt("Challenge_14") == 0)
                        {
                            // Display Reward
                            Canvas.GetComponent<Rewards>().DisplayChallengeReward(); // canvas.Rewards

                            // hide foot/ball
                            transform.position = new Vector2(0, 100);
                            Foot.GetComponent<FootController>().HideFoot();
                            WindBlowing = false;
                            FirstKick = true;

                            // pause
                            Foot.GetComponent<FootController>().isPaused = true;
                            Foot.GetComponent<FootController>().ChallengePause = true;
                            Time.timeScale = 0f;

                            Foot.GetComponent<FootController>().SetInputEnabled(); // make sure you can unpause

                            //hide plusScore Text
                            Canvas.GetComponent<GameUI>().ClearPlusScore();
                        }
                        break;

                    case 15:
                        if (PlayerPrefs.GetInt("Challenge_15") == 0)
                        {
                            // Display Reward
                            Canvas.GetComponent<Rewards>().DisplayChallengeReward(); // canvas.Rewards

                            // hide foot/ball
                            transform.position = new Vector2(0, 100);
                            Foot.GetComponent<FootController>().HideFoot();
                            WindBlowing = false;
                            FirstKick = true;

                            // pause
                            Foot.GetComponent<FootController>().isPaused = true;
                            Foot.GetComponent<FootController>().ChallengePause = true;
                            Time.timeScale = 0f;

                            Foot.GetComponent<FootController>().SetInputEnabled(); // make sure you can unpause

                            //hide plusScore Text
                            Canvas.GetComponent<GameUI>().ClearPlusScore();
                        }
                        break;

                    case 16:
                        if (PlayerPrefs.GetInt("Challenge_16") == 0)
                        {
                            // Display Reward
                            Canvas.GetComponent<Rewards>().DisplayChallengeReward(); // canvas.Rewards

                            // hide foot/ball
                            transform.position = new Vector2(0, 100);
                            Foot.GetComponent<FootController>().HideFoot();
                            WindBlowing = false;
                            FirstKick = true;

                            // pause
                            Foot.GetComponent<FootController>().isPaused = true;
                            Foot.GetComponent<FootController>().ChallengePause = true;
                            Time.timeScale = 0f;

                            Foot.GetComponent<FootController>().SetInputEnabled(); // make sure you can unpause

                            //hide plusScore Text
                            Canvas.GetComponent<GameUI>().ClearPlusScore();
                        }
                        break;

                    case 17:
                        if (PlayerPrefs.GetInt("Challenge_17") == 0)
                        {
                            // Display Reward
                            Canvas.GetComponent<Rewards>().DisplayChallengeReward(); // canvas.Rewards

                            // hide foot/ball
                            transform.position = new Vector2(0, 100);
                            Foot.GetComponent<FootController>().HideFoot();
                            WindBlowing = false;
                            FirstKick = true;

                            // pause
                            Foot.GetComponent<FootController>().isPaused = true;
                            Foot.GetComponent<FootController>().ChallengePause = true;
                            Time.timeScale = 0f;

                            Foot.GetComponent<FootController>().SetInputEnabled(); // make sure you can unpause

                            //hide plusScore Text
                            Canvas.GetComponent<GameUI>().ClearPlusScore();
                        }
                        break;

                    case 18:
                        if (PlayerPrefs.GetInt("Challenge_18") == 0)
                        {
                            // Display Reward
                            Canvas.GetComponent<Rewards>().DisplayChallengeReward(); // canvas.Rewards

                            // hide foot/ball
                            transform.position = new Vector2(0, 100);
                            Foot.GetComponent<FootController>().HideFoot();
                            WindBlowing = false;
                            FirstKick = true;

                            // pause
                            Foot.GetComponent<FootController>().isPaused = true;
                            Foot.GetComponent<FootController>().ChallengePause = true;
                            Time.timeScale = 0f;

                            Foot.GetComponent<FootController>().SetInputEnabled(); // make sure you can unpause

                            //hide plusScore Text
                            Canvas.GetComponent<GameUI>().ClearPlusScore();
                        }
                        break;

                    case 19:
                        if (PlayerPrefs.GetInt("Challenge_19") == 0)
                        {
                            // Display Reward
                            Canvas.GetComponent<Rewards>().DisplayChallengeReward(); // canvas.Rewards

                            // hide foot/ball
                            transform.position = new Vector2(0, 100);
                            Foot.GetComponent<FootController>().HideFoot();
                            WindBlowing = false;
                            FirstKick = true;

                            // pause
                            Foot.GetComponent<FootController>().isPaused = true;
                            Foot.GetComponent<FootController>().ChallengePause = true;
                            Time.timeScale = 0f;

                            Foot.GetComponent<FootController>().SetInputEnabled(); // make sure you can unpause

                            //hide plusScore Text
                            Canvas.GetComponent<GameUI>().ClearPlusScore();
                        }
                        break;

                    case 20:
                        if (PlayerPrefs.GetInt("Challenge_20") == 0)
                        {
                            // Display Reward
                            Canvas.GetComponent<Rewards>().DisplayChallengeReward(); // canvas.Rewards

                            // hide foot/ball
                            transform.position = new Vector2(0, 100);
                            Foot.GetComponent<FootController>().HideFoot();
                            WindBlowing = false;
                            FirstKick = true;

                            // pause
                            Foot.GetComponent<FootController>().isPaused = true;
                            Foot.GetComponent<FootController>().ChallengePause = true;
                            Time.timeScale = 0f;

                            Foot.GetComponent<FootController>().SetInputEnabled(); // make sure you can unpause

                            //hide plusScore Text
                            Canvas.GetComponent<GameUI>().ClearPlusScore();
                        }
                        break;
                }
            }
        }
    }

    public void lossConditionAnalytics()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "Game", GameManager.Instance.Score);
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(.1f);
        GameManager.Instance.ScoreResetCounter = 0;

    }

    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(.1f);
    }

    public void SetBallProperties()
    {
        // Set GravityRatio (percentage of normal gravity values)
        // lowest 0.75, highest 1.25
        switch (PlayerPrefs.GetInt("AnimalNumSave"))
        {
            case 0:
                BallGravityRatio = 1.0f;
                break;

            case 1:
                BallGravityRatio = 1.0f;
                break;

            case 2:
                BallGravityRatio = 1.0f;
                break;

            case 3:
                BallGravityRatio = 1.0f;
                break;

            case 4:
                BallGravityRatio = 1.0f;
                break;

            case 5:
                BallGravityRatio = 1.0f;
                break;

            case 6:
                BallGravityRatio = 1.0f;
                break;

            case 7:
                BallGravityRatio = 1.0f;
                break;

            case 8:
                BallGravityRatio = 1.0f;
                break;

            case 9:
                BallGravityRatio = 1.0f;
                break;

            case 10:
                BallGravityRatio = 1.0f;
                break;

            case 11:
                BallGravityRatio = 1.0f;
                break;

            case 12:
                BallGravityRatio = 1.0f;
                break;

            case 13:
                BallGravityRatio = 1.0f;
                break;

            case 14:
                BallGravityRatio = 1.0f;
                break;

            case 15:
                BallGravityRatio = 1.0f;
                break;

            case 16:
                BallGravityRatio = 1.0f;
                break;

            case 17:
                BallGravityRatio = 1.0f;
                break;

            case 18:
                BallGravityRatio = 1.0f;
                break;

            case 19:
                BallGravityRatio = 1.0f;
                break;

            case 20:
                BallGravityRatio = 1.0f;
                break;

            case 21:
                BallGravityRatio = 1.0f;
                break;

            case 22:
                BallGravityRatio = 1.0f;
                break;

            case 23:
                BallGravityRatio = 1.0f;
                break;

            case 24:
                BallGravityRatio = 1.0f;
                break;

            case 25:
                BallGravityRatio = 1.0f;
                break;

            case 26:
                BallGravityRatio = 1.0f;
                break;

            case 27:
                BallGravityRatio = 1.0f;
                break;

            case 28:
                BallGravityRatio = 1.0f;
                break;

            case 29:
                BallGravityRatio = 1.0f;
                break;

            case 30:
                BallGravityRatio = 1.0f;
                break;

            case 31:
                BallGravityRatio = 1.0f;
                break;

            case 32:
                BallGravityRatio = 1.0f;
                break;

            case 33:
                BallGravityRatio = 1.0f;
                break;

            case 34:
                BallGravityRatio = 1.0f;
                break;

            case 35:
                BallGravityRatio = 1.0f;
                break;

            case 36:
                BallGravityRatio = 1.0f;
                break;

            case 37:
                BallGravityRatio = 1.0f;
                break;

            case 38:
                BallGravityRatio = 1.0f;
                break;

            case 39:
                BallGravityRatio = 1.0f;
                break;

            case 40:
                BallGravityRatio = 1.0f;
                break;

            case 41:
                BallGravityRatio = 1.0f;
                break;

            case 42:
                BallGravityRatio = 1.0f;
                break;

            case 43:
                BallGravityRatio = 1.0f;
                break;

            case 44:
                BallGravityRatio = 1.0f;
                break;

            case 45:
                BallGravityRatio = 1.0f;
                break;

            case 46:
                BallGravityRatio = 1.0f;
                break;

            case 47:
                BallGravityRatio = 1.0f;
                break;

            case 48:
                BallGravityRatio = 1.0f;
                break;

            case 49:
                BallGravityRatio = 1.0f;
                break;

            case 50:
                BallGravityRatio = 1.0f;
                break;
        }
    }
}