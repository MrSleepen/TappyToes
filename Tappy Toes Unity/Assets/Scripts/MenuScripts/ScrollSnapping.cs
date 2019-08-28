using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSnapping : MonoBehaviour {

    private Camera refCamera;

    public GameObject ButtonScript;
    public GameObject Foot_ScrollingButtons;
    public GameObject Shoe_ScrollingButtons;
    public GameObject Level_ScrollingButtons;

    private Vector2 MousePosition;
    private Vector2 StartingLocation = new Vector2(33f, -39.2f);
    private Vector2 DesiredLocation;
    private Vector2 LevelDesiredLocation;

    private bool JustSnapped = false;
    private bool JustTapped = true;
    private bool JustRepleased = false;
    private bool AutoScrolling = false;

    public float ScrollSensitivity; // slide finger this distance, (6 = entire screen width)
    private float StartPosX;
    private float EndPosX;
    private float DeltaPos;
    private float SnappingSpeed;
    private float NormalScrollSpeed = Screen.width * 0.025f;
    private float AutoScrollSpeed = Screen.width * 0.25f;
    private float SnapDistance = Screen.width * 0.5f;
    private float LevelSnapDistance = Screen.width*0.5915f; 
    private int SnapPoint;
    private int SpecialSnapPoint;
    private int LastSnapType;

    //public Vector3 MousePosition { get; private set; } // testing only

    void Start()
    {
        refCamera = Camera.main;  // reference camera for getting mouse position
    }

    void Update ()
    {
        if (Input.touchCount >= 1 || Input.GetMouseButton(0))
        {
            // scrolls using the rect transform
            AutoScrolling = false;
            JustRepleased = true;
            
            // inital value
            if (JustTapped)
            {
                JustSnapped = false;
                JustTapped = false;

                if (Input.touchCount == 1)
                {
                    // get reference to first touch position
                    Touch touch = Input.GetTouch(0);
                    touch.position = refCamera.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));
                    StartPosX = touch.position.x;
                }
                else
                {
                    // get reference to mouse position
                    Vector2 mouse = Input.mousePosition;
                    MousePosition = refCamera.ScreenToWorldPoint(new Vector2(mouse.x, mouse.y));
                    StartPosX = MousePosition.x;
                }
            }
            else
            {
                if (Input.touchCount == 1)
                {
                    // get reference to first touch position
                    Touch touch = Input.GetTouch(0);
                    touch.position = refCamera.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));
                    EndPosX = touch.position.x;
                }
                else
                {
                    // get reference to mouse position
                    Vector2 mouse = Input.mousePosition;
                    MousePosition = refCamera.ScreenToWorldPoint(new Vector2(mouse.x, mouse.y));
                    EndPosX = MousePosition.x;
                }
            }

        }
        else if (Input.touchCount == 0)
        {
            JustTapped = true;

            // end value
            if (JustRepleased)
            {
                JustRepleased = false;

                DeltaPos = StartPosX - EndPosX;

                if (DeltaPos >= ScrollSensitivity)
                {
                    if (!JustSnapped)
                        SnapPoint += 1;

                    // Do no exceed max
                    if (LastSnapType == 1 || LastSnapType == 2)
                    {
                        if (SnapPoint > 9)
                            SnapPoint = 9;
                    }
                    else if (LastSnapType == 3)
                    {
                        if (SnapPoint > 19)
                            SnapPoint = 19;
                    }
                }
                else if (DeltaPos <= -ScrollSensitivity)
                {
                    if (!JustSnapped)
                        SnapPoint -= 1;

                    // Do not go below 0
                    if (SnapPoint < 0)
                        SnapPoint = 0;
                }
            }

            // CHOOSE SNAPPOINT LOCATION
            if (AutoScrolling)
            {
                SnappingSpeed = AutoScrollSpeed;
                DesiredLocation = new Vector2(SnapDistance - (SnapPoint * SnapDistance), StartingLocation.y);
                LevelDesiredLocation = new Vector2(SnapDistance - (SpecialSnapPoint * LevelSnapDistance), StartingLocation.y);
            }
            else
            {
                SnappingSpeed = NormalScrollSpeed;
                DesiredLocation = new Vector2(SnapDistance - (SnapPoint * SnapDistance), StartingLocation.y);
                LevelDesiredLocation = new Vector2(SnapDistance - (SnapPoint * LevelSnapDistance), StartingLocation.y);
            }

            // MOVE TO SNAPPOINT
            switch (ButtonScript.GetComponent<MainMenu>().SelectType) // ball, foot, shoe, level
            {
                case 1: // Animal (Ball)
                    break;

                case 2: // Foot
                    if (Foot_ScrollingButtons.transform.position.x > DesiredLocation.x + SnappingSpeed)
                    {
                        Foot_ScrollingButtons.transform.position = new Vector2(Foot_ScrollingButtons.transform.position.x - SnappingSpeed, Foot_ScrollingButtons.transform.position.y);
                    }
                    else if (Foot_ScrollingButtons.transform.position.x < DesiredLocation.x - SnappingSpeed)
                    {
                        Foot_ScrollingButtons.transform.position = new Vector2(Foot_ScrollingButtons.transform.position.x + SnappingSpeed, Foot_ScrollingButtons.transform.position.y);
                    }
                    else
                    {
                        Foot_ScrollingButtons.transform.position = new Vector2(DesiredLocation.x, Foot_ScrollingButtons.transform.position.y);
                    }
                    break;

                case 3: // Shoe
                    if (Shoe_ScrollingButtons.transform.position.x > DesiredLocation.x + SnappingSpeed)
                    {
                        Shoe_ScrollingButtons.transform.position = new Vector2(Shoe_ScrollingButtons.transform.position.x - SnappingSpeed, Shoe_ScrollingButtons.transform.position.y);
                    }
                    else if (Shoe_ScrollingButtons.transform.position.x < DesiredLocation.x - SnappingSpeed)
                    {
                        Shoe_ScrollingButtons.transform.position = new Vector2(Shoe_ScrollingButtons.transform.position.x + SnappingSpeed, Shoe_ScrollingButtons.transform.position.y);
                    }
                    else
                    {
                        Shoe_ScrollingButtons.transform.position = new Vector2(DesiredLocation.x, Shoe_ScrollingButtons.transform.position.y);
                    }
                    break;

                case 4: // Level
                    if (Level_ScrollingButtons.transform.position.x > LevelDesiredLocation.x + SnappingSpeed)
                    {
                        Level_ScrollingButtons.transform.position = new Vector2(Level_ScrollingButtons.transform.position.x - SnappingSpeed, Level_ScrollingButtons.transform.position.y);
                    }
                    else if (Level_ScrollingButtons.transform.position.x < LevelDesiredLocation.x - SnappingSpeed)
                    {
                        Level_ScrollingButtons.transform.position = new Vector2(Level_ScrollingButtons.transform.position.x + SnappingSpeed, Level_ScrollingButtons.transform.position.y);
                    }
                    else
                    {
                        Level_ScrollingButtons.transform.position = new Vector2(LevelDesiredLocation.x, Level_ScrollingButtons.transform.position.y);
                    }
                    break;
            }
        }
        else
        {
            Debug.Log("Invalid TouchCount");
        }
    }

    public void Enable_AutoScrolling ()
    {
        Debug.Log("Start Auto-Scrolling");
        AutoScrolling = true;
        
        SpecialSnapPoint = PlayerPrefs.GetInt("ActiveLevel") - 1;
        // prevent negative numbers
        if (SpecialSnapPoint <= 0)
            SpecialSnapPoint = 0;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.name)
        {
            // FOOT Buttons
            case "Leg0":
                SnapPoint = 0;
                LastSnapType = 1;
                JustSnapped = true;
                break;

            case "Leg1":
                SnapPoint = 1;
                LastSnapType = 1;
                JustSnapped = true;
                break;

            case "Leg2":
                SnapPoint = 2;
                LastSnapType = 1;
                JustSnapped = true;
                break;

            case "Leg3":
                SnapPoint = 3;
                LastSnapType = 1;
                JustSnapped = true;
                break;

            case "Leg4":
                SnapPoint = 4;
                LastSnapType = 1;
                JustSnapped = true;
                break;

            case "Leg5":
                SnapPoint = 5;
                LastSnapType = 1;
                JustSnapped = true;
                break;

            case "Leg6":
                SnapPoint = 6;
                LastSnapType = 1;
                JustSnapped = true;
                break;

            case "Leg7":
                SnapPoint = 7;
                LastSnapType = 1;
                JustSnapped = true;
                break;

            case "Leg8":
                SnapPoint = 8;
                LastSnapType = 1;
                JustSnapped = true;
                break;

            case "Leg9":
                SnapPoint = 9;
                LastSnapType = 1;
                JustSnapped = true;
                break;


            // SHOE Buttons
            case "shoeButton0":
                SnapPoint = 0;
                LastSnapType = 2;
                JustSnapped = true;
                break;

            case "shoeButton1":
                SnapPoint = 1;
                LastSnapType = 2;
                JustSnapped = true;
                break;

            case "shoeButton2":
                SnapPoint = 2;
                LastSnapType = 2;
                JustSnapped = true;
                break;

            case "shoeButton3":
                SnapPoint = 3;
                LastSnapType = 2;
                JustSnapped = true;
                break;

            case "shoeButton4":
                SnapPoint = 4;
                LastSnapType = 2;
                JustSnapped = true;
                break;

            case "shoeButton5":
                SnapPoint = 5;
                LastSnapType = 2;
                JustSnapped = true;
                break;

            case "shoeButton6":
                SnapPoint = 6;
                LastSnapType = 2;
                JustSnapped = true;
                break;

            case "shoeButton7":
                SnapPoint = 7;
                LastSnapType = 2;
                JustSnapped = true;
                break;

            case "shoeButton8":
                SnapPoint = 8;
                LastSnapType = 2;
                JustSnapped = true;
                break;

            case "shoeButton9":
                SnapPoint = 9;
                LastSnapType = 2;
                JustSnapped = true;
                break;


            // LEVEL Buttons
            case "Level1":
                SnapPoint = 0;
                LastSnapType = 3;
                JustSnapped = true;
                Debug.Log("SnapPoint: " + SnapPoint);
                break;

            case "Level2":
                SnapPoint = 1;
                LastSnapType = 3;
                JustSnapped = true;
                Debug.Log("SnapPoint: " + SnapPoint);
                break;

            case "Level3":
                SnapPoint = 2;
                LastSnapType = 3;
                JustSnapped = true;
                Debug.Log("SnapPoint: " + SnapPoint);
                break;

            case "Level4":
                SnapPoint = 3;
                LastSnapType = 3;
                JustSnapped = true;
                Debug.Log("SnapPoint: " + SnapPoint);
                break;

            case "Level5":
                SnapPoint = 4;
                LastSnapType = 3;
                JustSnapped = true;
                Debug.Log("SnapPoint: " + SnapPoint);
                break;

            case "Level6":
                SnapPoint = 5;
                LastSnapType = 3;
                JustSnapped = true;
                Debug.Log("SnapPoint: " + SnapPoint);
                break;

            case "Level7":
                SnapPoint = 6;
                LastSnapType = 3;
                JustSnapped = true;
                Debug.Log("SnapPoint: " + SnapPoint);
                break;

            case "Level8":
                SnapPoint = 7;
                LastSnapType = 3;
                JustSnapped = true;
                Debug.Log("SnapPoint: " + SnapPoint);
                break;

            case "Level9":
                SnapPoint = 8;
                LastSnapType = 3;
                JustSnapped = true;
                Debug.Log("SnapPoint: " + SnapPoint);
                break;

            case "Level10":
                SnapPoint = 9;
                LastSnapType = 3;
                JustSnapped = true;
                Debug.Log("SnapPoint: " + SnapPoint);
                break;

            case "Level11":
                SnapPoint = 10;
                LastSnapType = 3;
                JustSnapped = true;
                break;

            case "Level12":
                SnapPoint = 11;
                LastSnapType = 3;
                JustSnapped = true;
                break;

            case "Level13":
                SnapPoint = 12;
                LastSnapType = 3;
                JustSnapped = true;
                break;

            case "Level14":
                SnapPoint = 13;
                LastSnapType = 3;
                JustSnapped = true;
                break;

            case "Level15":
                SnapPoint = 14;
                LastSnapType = 3;
                JustSnapped = true;
                break;

            case "Level16":
                SnapPoint = 15;
                LastSnapType = 3;
                JustSnapped = true;
                break;

            case "Level17":
                SnapPoint = 16;
                LastSnapType = 3;
                JustSnapped = true;
                break;

            case "Level18":
                SnapPoint = 17;
                LastSnapType = 3;
                JustSnapped = true;
                break;

            case "Level19":
                SnapPoint = 18;
                LastSnapType = 3;
                JustSnapped = true;
                break;

            case "Level20":
                SnapPoint = 19;
                LastSnapType = 3;
                JustSnapped = true;
                break;
        }
    }

}
