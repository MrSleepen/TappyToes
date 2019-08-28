using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject Foot;

    // Animation Variables
    private float BlinkTimer = 5;
    private bool NotBlinking = true;
    public Sprite[] AnimalSprite1;
    public Sprite[] AnimalSprite2;
    public ParticleSystem ParticleLauncher;
    public Vector3 StartLocation;

    public AudioSource Source;
    public AudioClip[] audiocliparray;
    public int SoundNumber;

    public ParticleSystem Splatter;
    public GameObject PartSys;

    // Physics Variables
    private float HardTorque;
    private float SoftTorque;
    private float JustKicked;
    private Rigidbody2D rb;

    private bool HeightAlerted;


    private void Awake()
    {
        Source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        // References
        rb = this.GetComponent<Rigidbody2D>(); // Reference Rigidbody
        rb.gravityScale = 1.4f;

        SoundNumber = PlayerPrefs.GetInt("AnimalNumSave");
        Source.clip = audiocliparray[SoundNumber];

        StartLocation = transform.position;

        GameManager.Instance.AnimalNum = PlayerPrefs.GetInt("AnimalNumSave");
        UpdateBallSprite();
    }

    void FixedUpdate()
    {
        JustKicked -= Time.deltaTime;
        BlinkTimer -= Time.deltaTime;
    }

    private void Update()
    {   
        if (GameManager.Instance.Reset == true)
        {
            transform.position = StartLocation;
        }

        //gameObject.GetComponent<SpriteRenderer>().sprite = AnimalSprite1[GameManager.Instance.AnimalNum];

        ////Animal Animations "Blink"
        //if (BlinkTimer >= 0)
        //{
        //    NotBlinking = true;
        //}
        //else
        //{
        //    NotBlinking = false;
        //}

        //if(NotBlinking == true)
        //{
        //    gameObject.GetComponent<SpriteRenderer>().sprite = AnimalSprite1[GameManager.Instance.AnimalNum];
        //}
        //else if (NotBlinking == false)
        //{
        //    gameObject.GetComponent<SpriteRenderer>().sprite = AnimalSprite2[GameManager.Instance.AnimalNum];
        //    StartCoroutine(Blink());
        //}
    }

    //When the Ball is Kicked by player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                //HeightAlerted = false;
                PartSys.transform.position = transform.position;

                if (JustKicked <= 0)
                {
                    Source.Play();
                    ParticleLauncher.Play();
                    JustKicked = 1;
                    rb = this.GetComponent<Rigidbody2D>();
                    rb.AddForce(Vector2.up * 13f + 5f * rb.velocity.normalized, ForceMode2D.Impulse);
                    Rotate();
                    //++GameManager.Instance.Score;
                    //if (GameManager.Instance.Score > GameManager.Instance.TopScore)
                    //{
                    //    GameManager.Instance.TopScore = GameManager.Instance.Score;
                    //    PlayerPrefs.SetInt("ScoreSave", GameManager.Instance.TopScore);
                    //}
                }
                break;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                PartSys.transform.position = transform.position;

                if (rb.velocity.y < 0.1)
                {
                    rb = this.GetComponent<Rigidbody2D>();
                    rb.AddForce(Vector2.up * 13f + 5f * rb.velocity.normalized, ForceMode2D.Impulse);
                }
                break;
        }
    }

    //Coroutine for the Blinking animals
    IEnumerator Blink()
    {
        yield return new WaitForSeconds(.5f);
        BlinkTimer = 5;
       
    }
    //random rotation for the ball when kicked
    private void Rotate()
    {
        float Direction = Random.Range(-1f, 1f);
        HardTorque = Random.Range(20f, 40f);
        SoftTorque = Random.Range(5, 20);
        // ROTATE based on Kick Direction
        // + CounterClockwise, - Clockwise
        if (Direction > 0f && Direction < 0.4f)
        {
            //Debug.Log("Slight Right");
            rb.angularVelocity = 0f;
            rb.AddTorque(-SoftTorque, ForceMode2D.Force);
        }
        else if (Direction > 0f)
        {
            //Debug.Log("Right");
            rb.angularVelocity = 0f;
            rb.AddTorque(-HardTorque, ForceMode2D.Force);
        }
        else if (Direction < 0f && Direction < -0.4f)
        {
            //Debug.Log("Slight Left");
            rb.angularVelocity = 0f;
            rb.AddTorque(SoftTorque, ForceMode2D.Force);
        }
        else if (Direction < 0f)
        {
            //Debug.Log("Left");
            rb.angularVelocity = 0f;
            rb.AddTorque(HardTorque, ForceMode2D.Force);
        }
        else // Vertical
        {
            //Debug.Log("Vertical");
            rb.angularVelocity = 0f;
        }
    }

    public void SetMenuBallSound()
    {
        // Set BALL SOUND
        SoundNumber = PlayerPrefs.GetInt("AnimalNumSave");
        Source.clip = audiocliparray[SoundNumber];
    }

    public void UpdateBallSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = AnimalSprite1[GameManager.Instance.AnimalNum];
    }

}

