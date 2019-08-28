using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera refCamera;
    public Sprite[] AnimalSprite;

    public GameObject Ball_Obj;
    public GameObject Foot_Obj;
    public GameObject Canvas;

    public ParticleSystem ParticleLauncher;
    public GameObject PartSys;

    // Present Movement/Opening
    public Transform OpeningLocation; // Location to open the present
    public Transform FootTransform; // Location to open present is based on Foot Location
    private Vector3 OpeningLocOffset = new Vector3(0.0f, 1.0f, 0.0f);
    private Vector3 screenPoint;

    private Vector2 FlySpeed = new Vector2(3.5f, 0.0f);
    private Vector2 StartingPosition;
    private Vector2 PlayArea;

    private float WingSpeed = 0.4f; // wing flap speed, smaller is faster!
    private float BirdEncounterDelay = 10f; // time before it first appears in the level
    private float FlyLoopDelay = 12f; // time from frist appearing, and apearing again (includes flying by time)
    private float PresentSpeed = 5.0f;
    private float DelayTime = 3f; // time to be added to TimeTracker to delay BirdAppearance
    private float TimeTracker; // used to keep track of time until bird should appear

    [HideInInspector] public bool OnScreen;
    public bool BirdWaiting = false;
    private bool PauseBirdFlyLoop = false;
    public bool NoMoreBirds = false;
    public bool BirdApperance = false;
    private bool Alive = true;
    private bool wingsUp = false;
    private bool PresentOpen = false;
    private bool Flying = true;

    // AudioSources
    public AudioSource Audio_BirdKill;
    public AudioSource Audio_Reward;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        // Get the Play Area
        refCamera = Camera.main;
        PlayArea = refCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        // Set Starting Position
        StartingPosition = new Vector3(-PlayArea.x + (-2.0f), PlayArea.y * 0.43f, 0f);
        rb.transform.position = StartingPosition;
    }

    void Update()
    {
        // PHYSICS & LOGIC ---------------------------------------------------------------------
        // -------------------------------------------------------------------------------------

        if (BirdApperance)
        {
            if (Foot_Obj.GetComponent<FootController>().isPaused == false)
            {
                if (Alive)
                {
                    if (!IsInvoking("RestartFlyLoop") && PauseBirdFlyLoop == false)
                    {
                        Invoke("RestartFlyLoop", FlyLoopDelay);
                        TimeTracker = FlyLoopDelay;
                    }
                    else if (!IsInvoking("RestartFlyLoop") && PauseBirdFlyLoop == true)
                    {
                        Invoke("RestartFlyLoop", TimeTracker);
                        PauseBirdFlyLoop = false;
                    }

                    TimeTracker -= Time.deltaTime;
                    rb.velocity = FlySpeed; // Fly Right
                    Flying = true;
                    //Debug.Log("Time" + TimeTracker);
                }
                else // Dead (Present)
                {
                    CancelInvoke("RestartFlyLoop");

                    // stop flying right
                    if (Flying == true)
                    {
                        Audio_BirdKill.Play();

                        Flying = false;
                        rb.velocity = new Vector2(0.0f, 0.0f);

                        float FootStartingY = Foot_Obj.GetComponent<FootController>().StartingY;
                        OpeningLocation.position = new Vector2(FootTransform.position.x + OpeningLocOffset.x, FootStartingY + OpeningLocOffset.y); //FootTransform.position + OpeningLocOffset;
                    }

                    // move to OpeningLocation
                    float step = PresentSpeed * Time.deltaTime; // calculate distance to move
                    rb.transform.position = Vector3.MoveTowards(transform.position, OpeningLocation.position, step);

                    // when location is reached
                    if (Vector3.Distance(transform.position, OpeningLocation.position) < 0.001f && PresentOpen == false)
                    {
                        Audio_Reward.Play();

                        PresentOpen = true;
                        // display reward
                        Canvas.GetComponent<Rewards>().DetermineReward();
                        Ball_Obj.GetComponent<AdvancedBall>().NormalMotion(); // remove slowMotion if active
                    }

                    Ball_Obj.SetActive(false);
                    Foot_Obj.SetActive(false);
                }

                if (PresentOpen)
                {
                    if (Input.touchCount == 1 || Input.GetMouseButtonDown(0)) // only 1 finger touching screen
                    {
                        rb.velocity = new Vector2(0.0f, 0.0f);
                        rb.transform.position = StartingPosition;
                        CancelInvoke("RestartFlyLoop");

                        PresentOpen = false;
                        Flying = false;
                        Alive = true;
                        BirdApperance = false;

                        Ball_Obj.SetActive(true);
                        Foot_Obj.SetActive(true);

                        GameObject ball = GameObject.Find("Ball");
                        refCamera.GetComponent<CameraMotor>().CenterCamera();
                        ball.GetComponent<AdvancedBall>().SafeReset();

                        GameObject Reward_Obj = Canvas.transform.Find("Reward").gameObject;
                        Reward_Obj.SetActive(false);
                    }
                }
            }
            else // Foot_Obj.GetComponent<FootController>().isPaused == true
            {
                CancelInvoke("RestartFlyLoop");
                PauseBirdFlyLoop = true;
                rb.velocity = new Vector2(0.0f, 0.0f); // pause movement while game is pasused
            }
        }
        else // BirdApperance == false
        {
            if (Foot_Obj.GetComponent<FootController>().isPaused == false)
            {
                if (!NoMoreBirds)
                {
                    NoMoreBirds = true;
                    if (!IsInvoking("BirdDoneWaiting"))
                        Invoke("BirdDoneWaiting", BirdEncounterDelay);
                }
            }
        }
        // -------------------------------------------------------------------------------------


        // ANIMATIONS --------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------

        if (Foot_Obj.GetComponent<FootController>().isPaused == false)
        {
            if (wingsUp && Alive) // wings down
            {

                if (!IsInvoking("FlapWings"))
                {
                    Invoke("FlapWings", WingSpeed);
                }

                gameObject.GetComponent<SpriteRenderer>().sprite = AnimalSprite[0];
            }
            else if (!wingsUp && Alive) // wings up
            {
                if (!IsInvoking("FlapWings"))
                {
                    Invoke("FlapWings", WingSpeed);
                }

                gameObject.GetComponent<SpriteRenderer>().sprite = AnimalSprite[1];
            }
            else if (!PresentOpen)// turn into present
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = AnimalSprite[2]; // present
            }
            else // open present
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = AnimalSprite[3]; // open present
            }
        }
        // -------------------------------------------------------------------------------------
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Ball_Obj.GetComponent<AdvancedBall>().WindBlowing = false;
            Alive = false;
            PartSys.transform.position = transform.position;
            ParticleLauncher.Play();
        }
    }

    private void FlapWings()
    {
        // toggle wing
        if (wingsUp)
        {
            wingsUp = false;
        }
        else
        {
            wingsUp = true;
        }
    }

    private void RestartFlyLoop()
    {
        if (Alive)
        {
            rb.transform.position = StartingPosition;
            TimeTracker = FlyLoopDelay;
        }
    }

    private void BirdDoneWaiting()
    {
        if (PlayerPrefs.GetInt("ChallengeMode") == 0) // Story Mode
        {
            BirdWaiting = true;
        }
    }

    private void BirdEncounter()
    {
        BirdApperance = true;
    }

    public void DelayEncounter()
    {
        // delay encounter
        TimeTracker += DelayTime;

        // do not exceed Max (FlyLoopDelay)
        if (TimeTracker > FlyLoopDelay)
        {
            TimeTracker = FlyLoopDelay;
        }
    }

    public void CheckIfOnScreen()
    {
        screenPoint = Camera.main.WorldToViewportPoint(gameObject.transform.position);
        if (screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1)
        {
            OnScreen = true;
        }
        else
        {
            OnScreen = false;
        }
    }

    public void ResetBird()
    {
        RestartFlyLoop();
        rb.velocity = new Vector2(0, 0); // stop flying
        Flying = false;
        BirdWaiting = false;
        NoMoreBirds = false;
        BirdApperance = false;
    }

}