using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera refCamera;
    public GameObject Canvas;
    public GameObject Shoe;
    public GameObject Leg;

    private Vector2 MousePosition;
    private Vector2 CurrentLocation;
    private Vector2 DesiredLocation;
    private Vector2 FootSize; // current footsize
    private Vector2 DefaultFootSize = new Vector2(0.5f, 0.5f); // small by default
    private Vector2 AnimatedRiseSpeed = new Vector2(0f, 5.0f);
    private Vector2 AnimatedFallSpeed = new Vector2(0f, -7.5f);
    private Vector2 AnimatedResetLocation = new Vector3(0f, -7f);

    private float FootSize_MIN = 0.5f;
    private float FootSize_MAX = 0.75f;
    private float KickSpeed = 8f; // Vertical Speed
    private float SlideSpeed = 50f; // Horizontal Speed
    private float MaxHeight = -3.75f; // Max Kick Height
    [HideInInspector] public float StartingY = -4.8f; // default leg height (since public must also be changed in inspector)
    private float StartingX = 0f; // centred posX 

    [HideInInspector] public int KickType = 1; // 0 = Low, 1 = Normal, 2 = High, 3 = Perfect
    [HideInInspector] public int PerfectStreak = 0; 
    [HideInInspector] public int GoodStreak = 0; 

    [HideInInspector] public bool GoodBonus = false;
    [HideInInspector] public bool PerfectBonus = false;

    //staminabar
    public float Stamina = 100f;
    public float MaxStamina = 100f;
    private float StaminaRegen = 0.25f;
    private float StaminaCost = 10f;


    public int SlowMotionTimer;
    public bool ChallengePause = false;
    public bool isPaused = true;
    public bool RestingGame = false;
    private bool AnimateFoot = false;
    private bool AnimateDown = false;
    private bool InputAllowed = true; // if tap/click will perfrom a kick
    private bool FirstKick = true; // if it's the first kick, since a restart
    private bool AlreadyTapped = false; // prevents multi-touch taping
    private bool ToggleUpDown; // true = foot moving up, false = foot moving down or not at all
    private bool Kicking = false; // currenting kicking
    private bool MoveRight; // true = right, false = left, direction to move to last desiredlocation
    private bool Moving; // foot is moving left/right towards tap/click
    private bool AlreadySetMove = false; // if true, won't set/overide direction to move to 
    private bool HoldingDown = false;

    // AudioSources
    public AudioSource Audio_Kick;

    void Start()
    {
        // References
        rb = this.GetComponent<Rigidbody2D>(); // Reference Rigidbody
        refCamera = Camera.main;  // reference camera for getting mouse position

        // set starting location
        CurrentLocation = new Vector2(StartingX, StartingY);
        transform.position = new Vector2(StartingX, StartingY);

        transform.localScale = DefaultFootSize; // set Footsize to Default Size
    }

    void Update ()
    {
        if (Stamina > MaxStamina)
        {
            Stamina = MaxStamina;
        }
        else if (Stamina < MaxStamina)
        {
            Stamina += StaminaRegen;
        }

        if (InputAllowed && Stamina >= 10f)
        {
            // TOUCHING SCREEN
            if (Input.touchCount == 1 || Input.GetMouseButton(0)) 
            {
                AlreadyTapped = true;
                HoldingDown = true;
                AlreadySetMove = false;

                float posX;

                if (Input.touchCount == 1)
                {
                    // get reference to first touch
                    Touch touch = Input.GetTouch(0);
                    // set Desired location based on tap position
                    touch.position = refCamera.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));
                    posX = touch.position.x;
                }
                else
                {
                    // get reference to mouse position
                    Vector2 mouse = Input.mousePosition;
                    // set Desired location based on mouse position
                    MousePosition = refCamera.ScreenToWorldPoint(new Vector2(mouse.x, mouse.y));
                    posX = MousePosition.x;
                }
                DesiredLocation = new Vector2(posX, StartingY);
            } // end TOUCHING SCREEN
            // LIFT FINGER
            else if ((Input.touchCount == 0 && AlreadyTapped) || Input.GetMouseButtonUp(0)) 
            {
                Audio_Kick.Play(); // sound for kicking

                // used to trigger this once per touch
                AlreadyTapped = false;
                HoldingDown = false;

                // unpause
                isPaused = false;

                // Enable collisons
                this.GetComponent<BoxCollider2D>().enabled = true;
                this.GetComponent<CircleCollider2D>().enabled = true;

                float posX;

                if (Input.GetMouseButtonUp(0)) // CLICK
                {
                    AlreadySetMove = false;
                    Stamina -= StaminaCost;

                    // get reference to mouse position
                    Vector2 mouse = Input.mousePosition;
                    // set Desired location based on mouse position
                    MousePosition = refCamera.ScreenToWorldPoint(new Vector2(mouse.x, mouse.y));
                    posX = MousePosition.x;

                    if (FirstKick)
                    {
                        DesiredLocation = new Vector2(StartingX, StartingY);
                        FirstKick = false;
                        InputAllowed = false;
                        if (!IsInvoking("SetInputEnabled"))
                            Invoke("SetInputEnabled", 0.4f);
                    }
                    else
                    {
                        DesiredLocation = new Vector2(posX, StartingY);
                    }

                    // set Y position
                    transform.position = new Vector2(CurrentLocation.x, StartingY);

                    if (CurrentLocation.x + 0.1f >= DesiredLocation.x && CurrentLocation.x - 0.1f <= DesiredLocation.x)
                    {
                        // set appropiate variables for starting a kick
                        Kicking = true;
                        ToggleUpDown = true;
                        AlreadySetMove = false; // allow "Determine Direction" to occur again
                    }
                }
                else if (Input.touchCount == 0) // Relased TAP
                {
                    AlreadySetMove = false;
                    Stamina -= StaminaCost;

                    if (FirstKick)
                    {
                        DesiredLocation = new Vector2(StartingX, StartingY);
                        FirstKick = false;
                        InputAllowed = false;
                        if(!IsInvoking("SetInputEnabled"))
                            Invoke("SetInputEnabled", 0.4f);
                    }
                    // otherwise keep DesiredLocation at what it previously was (location last touched).

                    // set Y position
                    transform.position = new Vector2(CurrentLocation.x, StartingY);

                    // tapped on self, just kick.
                    if (CurrentLocation.x + 0.1f >= DesiredLocation.x && CurrentLocation.x - 0.1f <= DesiredLocation.x)
                    {
                        // set appropiate variables for starting a kick
                        Kicking = true;
                        ToggleUpDown = true;
                        AlreadySetMove = false; // allow "Determine Direction" to occur again
                    }
                }

                // Unpause Game, return to reguarly state
                if (ChallengePause)
                {
                    ChallengePause = false;
                    Time.timeScale = 1.0f;

                    Canvas.GetComponent<Rewards>().RemoveChallengeDisplay();

                    GameObject Ball = GameObject.Find("Ball");
                    Ball.GetComponent<AdvancedBall>().SafeReset();
                    ShowFoot();
                }

            } // end LIFT FINGER
        }
    }

    void FixedUpdate()
    {
        //Debug.Log(Stamina);
        // Update CurrentLocation
        CurrentLocation.x = rb.position.x;
        CurrentLocation.y = rb.position.y;

        if (!AnimateFoot)
        {
            // HORIZONTAL --------------------------------------------------------------------------
            // -------------------------------------------------------------------------------------
            if (!HoldingDown)
            {
                // Determine Direction && Start Moving
                if (!AlreadySetMove)
                {
                    // +0.1/-0.1 avoids an occasional bug when it spazes out
                    if (CurrentLocation.x + 0.1f < DesiredLocation.x) // Move Right // CurrentLocation.x +0.1f
                    {
                        transform.position = new Vector2(CurrentLocation.x, StartingY);
                        rb.velocity = new Vector2(SlideSpeed, 0.0f);
                        AlreadySetMove = true;
                        MoveRight = true;
                        Moving = true;
                    }
                    else if (CurrentLocation.x - 0.1f > DesiredLocation.x) // Move Left // CurrentLocation.x -0.1f
                    {
                        transform.position = new Vector2(CurrentLocation.x, StartingY);
                        rb.velocity = new Vector2(-SlideSpeed, 0.0f);
                        AlreadySetMove = true;
                        MoveRight = false;
                        Moving = true;
                    }
                    else // DO NOT MOVE
                    {
                        CurrentLocation.x = DesiredLocation.x;
                        Moving = false;
                    }
                }

                // if Reached/Passed desired Location, stop moving and set location to Desired Location
                if ((CurrentLocation.x > DesiredLocation.x && MoveRight) || (CurrentLocation.x < DesiredLocation.x && !MoveRight))
                {
                    // Reached Tap Location, Stop
                    rb.velocity = new Vector2(0.0f, 0.0f);
                    transform.position = DesiredLocation;
                    CurrentLocation = DesiredLocation;
                    AlreadySetMove = false; // allow "Determine Direction" to occur again

                    // set appropiate variables for starting a kick
                    Kicking = true;
                    ToggleUpDown = true;
                }

                if (!Moving)
                {
                    DesiredLocation = CurrentLocation;
                }
            }
            // -------------------------------------------------------------------------------------


            // VERTICAL ----------------------------------------------------------------------------
            // -------------------------------------------------------------------------------------
            if (!FirstKick)
            {
                if (Kicking && ToggleUpDown && CurrentLocation.y < MaxHeight) // UP
                {   
                    transform.Translate(Vector3.up * Time.deltaTime * KickSpeed, Space.World);
                    FootSize = transform.localScale;
                    if (FootSize.x < FootSize_MAX && FootSize.y < FootSize_MAX)
                    {
                        FootSize.x += .05f;
                        FootSize.y += .05f;

                        transform.localScale = FootSize;
                        //Subtract Stamina Per Kick
                    }
                }
                else if (Kicking && ToggleUpDown && CurrentLocation.y >= MaxHeight) // Reverse Direction
                {
                    ToggleUpDown = false;
                }
                else if (Kicking && !ToggleUpDown && CurrentLocation.y > StartingY) // Down
                {
                    transform.Translate(Vector3.down * Time.deltaTime * KickSpeed, Space.World);
                    FootSize = transform.localScale;
                    if (FootSize.x > FootSize_MIN && FootSize.y > FootSize_MIN)
                    {
                        FootSize.x -= .05f;
                        FootSize.y -= .05f;

                        transform.localScale = FootSize;
                    }
                }
                else if (!RestingGame) // Not Kicking
                {
                    // Stop kicking
                    ToggleUpDown = false;
                    Kicking = false;
                    // make sure footsize is correct
                    transform.localScale = DefaultFootSize;

                    // move to Desired Location if HoldingDown, and prevents get pushed down by ball
                    transform.position = new Vector2(DesiredLocation.x, StartingY);
                }
                else // about to reset game
                {
                    transform.localScale = DefaultFootSize; // set Footsize to Default Size
                }
            }

            // -------------------------------------------------------------------------------------
        }
        else // AnimatedFoot
        {
            if (!AnimateDown)
            {
                if (CurrentLocation.y >= StartingY)
                {
                    rb.velocity = new Vector2(0, 0);
                    rb.transform.position = new Vector2(StartingX, StartingY);
                    DesiredLocation = CurrentLocation;
                    AnimateFoot = false;
                }
            }
        } // end AnimateFoot
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ball":
                if(this.rb != null)
                {
                    this.rb.velocity = new Vector2(0, 0); // briefly stop moving, to counteract forces applyed to foot from ball
                    GameObject Ball = GameObject.Find("Ball"); // Ball Reference for Below

                    // POSSIBLE HIT RANGE -4.8 to -3.75
                    if (CurrentLocation.y >= -3.84f) // -3.84 to -3.75
                    {
                        KickType = 3;
                        GoodStreak += 1;
                        PerfectStreak += 1;

                        if (PerfectStreak >= 3 && GoodStreak >= 8)
                        {
                            // Reward
                            PerfectBonus = true;
                            GoodBonus = true;
                            
                            // Reset Streak
                            GoodStreak = 0;
                            PerfectStreak = 0;
                        }
                        else if (PerfectStreak >= 3)
                        {
                            // reward
                            PerfectBonus = true;

                            // Reset Streaks
                            PerfectStreak = 0;
                        }
                        else if (GoodStreak >= 8)
                        {
                            // reward
                            GoodBonus = true;

                            // Reset Streak
                            GoodStreak = 0;
                        }
                    }
                    else if (CurrentLocation.y >= -4.25f) // -4.25 to -3.84
                    {
                        KickType = 2;
                        GoodStreak += 1;
                        PerfectStreak = 0;

                        if (GoodStreak >= 8)
                        {
                            // reward
                            GoodBonus = true;

                            // Reset Streak
                            GoodStreak = 0;
                        }
                    }
                    else if (CurrentLocation.y >= -4.71f) // -4.71 to -4.25
                    {
                        KickType = 1;
                        GoodStreak = 0;
                        PerfectStreak = 0;
                    }
                    else // -4.71 to -4.8
                    {
                        KickType = 0;
                        GoodStreak = 0;
                        PerfectStreak = 0;
                    }
                    
                    GameObject CanvasRef = GameObject.Find("Canvas");
                    CanvasRef.GetComponent<GameUI>().SetKickText(); // Displays "PERFECT" or "Close One" on screen based on KickType
                    CanvasRef.GetComponent<GameUI>().SetStreakText(); // Display "Perfect Streak" or "Good Streak" if on a streak

                    // Gain Score based on kick
                    Ball.GetComponent<AdvancedBall>().GainScore();

                    // Disable collisons
                    this.GetComponent<BoxCollider2D>().enabled = false;
                    this.GetComponent<CircleCollider2D>().enabled = false;

                    // Trigger the bird to starting flying, right after a kick
                    GameObject Bird = GameObject.Find("Bird");
                    if (Bird.GetComponent<Bird>().BirdWaiting == true)
                    {
                        Bird.GetComponent<Bird>().BirdWaiting = false;
                        Bird.GetComponent<Bird>().Invoke("BirdEncounter", 0.05f);
                    }

                    // Cancel SlowMotion if Active
                    
                    if (SlowMotionTimer <= 0)
                    {
                        Time.timeScale = 1.0f;
                    }
                    else
                    {
                        SlowMotionTimer -= 1;
                    }
                    
                }
                break;
        }
    }

    public void AnimatedFootReturn()
    {
        // variables for starting the logic to Stop moving
        InputAllowed = false;
        AnimateFoot = true;

        // Start below and move up
        rb.transform.position = AnimatedResetLocation;
        rb.velocity = AnimatedRiseSpeed;
    }

    public void AnimatedFootRetrevial()
    {
        // variables for starting the logic to Stop moving
        InputAllowed = false;
        AnimateFoot = true;
        AnimateDown = true;

        // move down offscreen
        rb.velocity = AnimatedFallSpeed;
    }

    public void Restart()
    {
        transform.localScale = DefaultFootSize; // set Footsize to Default Size
        
        // "paused" until first kick (game physics stay stationary but time continues so that background effects can occur)
        isPaused = true;
        InputAllowed = true;
        AnimateFoot = false;
        FirstKick = true;
        RestingGame = false;
        refCamera.GetComponent<CameraMotor>().UnCenterCamera();
    }

    public void ResetFoot()
    {
        // make sure footsize is correct
        transform.localScale = DefaultFootSize;
        // move to starting location and stop moving
        rb.velocity = new Vector2(0, 0);

        // Disable collisons
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<CircleCollider2D>().enabled = false;
    }

    public void SetInputEnabled()
    {
        InputAllowed = true;
    }

    public void SetInputDisabled()
    {
        InputAllowed = false;
    }

    public void SetStartingFootSize()
    {
        RestingGame = true;
        transform.localScale = DefaultFootSize; // set Footsize to Default Size
    }

    public void HideFoot()
    {
        Shoe.SetActive(false);
        Leg.SetActive(false);

    }

    public void ShowFoot()
    {
        Shoe.SetActive(true);
        Leg.SetActive(true);
    }

}
