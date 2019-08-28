using UnityEngine;
using System.Collections;

public class AutoKick : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 FootSize;
    public Sprite[] FootSprite;

    //public Vector3 StartLocation;

    // Physics Variables
    public bool ToggleUpDown = true;
    public float FootSpeed;
    private bool Kicking;


    private Vector2 StartingtLocation;
    private Vector2 CurrentLocation;

    private float KickSpeed = 3.0f; // Vertical Speed
    private float MaxHeight = -3.75f; // Max Kick Height
    private float StartingY = -5.5f; // default leg height (since public must also be changed in inspector)

    private void Start()
    {
        // References
        rb = this.GetComponent<Rigidbody2D>(); // Reference Rigidbody

        CurrentLocation = new Vector2(0, StartingY);
        transform.position = new Vector2(0, StartingY);
        StartingtLocation = CurrentLocation;
    }

    private void Update()
    {
        if (GameManager.Instance.Reset == true)
        {
            transform.position = StartingtLocation;
            ToggleUpDown = true;
            GameManager.Instance.Reset = false;
            // set menu-foot spirte
            SetFootSprite();
        }  
    }

    void FixedUpdate()
    {
       
        CurrentLocation.y = rb.position.y;


        if (ToggleUpDown && CurrentLocation.y < MaxHeight) // UP
        {
            transform.Translate(Vector3.up * Time.deltaTime * KickSpeed, Space.World);
            FootSize = transform.localScale;
            if (FootSize.x <= 1 && FootSize.y <= 1)
            {
                FootSize.x += .005f;
                FootSize.y += .005f;

                transform.localScale = FootSize;
            }
        }
        else if (ToggleUpDown && CurrentLocation.y >= MaxHeight) // Reverse Direction (to DOWN)
        {
            ToggleUpDown = false;
        }
        else if (!ToggleUpDown && CurrentLocation.y > StartingY) // DOWN
        {
            transform.Translate(Vector3.down * Time.deltaTime * KickSpeed, Space.World);
            FootSize = transform.localScale;
            if (FootSize.x >= .8 && FootSize.y >= .8)
            {
                FootSize.x -= .005f;
                FootSize.y -= .005f;

                transform.localScale = FootSize;
            }
        }
        else
        {
            // Stop Kicking
            ToggleUpDown = true;

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ball":
                ToggleUpDown = !ToggleUpDown;
                break;
        }
    }

    public void SetFootSprite()
    {
        //change the sprite of the foot to be what ever is selected
        gameObject.GetComponent<SpriteRenderer>().sprite = FootSprite[GameManager.Instance.FootNum];
    }

}