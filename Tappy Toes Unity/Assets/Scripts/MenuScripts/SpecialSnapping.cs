using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialSnapping : MonoBehaviour {

    public Camera refCamera;
    public GameObject ButtonScript;
    public GameObject Animal_ScrollingButtons;

    private Vector3 ScreenCenter;
    private Vector2 StartingLocation = new Vector2(33f, -39.2f);
    private Vector2 DesiredLocation;

    private float SnappingSpeed = Screen.width * 0.025f;
    private float SnapDistance = Screen.width * 0.9372f; //0.3124f = 1 row
    private int SnapPoint;
    private int CurrentPage;


    void Update()
    {
        //Debug.Log("CurrentPage " + CurrentPage);
        ScreenCenter = refCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));


        if (Input.touchCount >= 1 || Input.GetMouseButton(0))
        {
            // do nothing (scrolls using the rect transform)
            this.GetComponent<CircleCollider2D>().enabled = true;
        }
        else if (Input.touchCount == 0)
        {
            CurrentPage = SnapPoint; // update CurrentPage
            this.GetComponent<CircleCollider2D>().enabled = false;

            // CHOOSE SNAPPOINT LOCATION 
            DesiredLocation = new Vector2(SnapDistance* 0.45f - (SnapPoint * SnapDistance), StartingLocation.y);

            // MOVE TO SNAPPOINT
            switch (ButtonScript.GetComponent<MainMenu>().SelectType) // ball, foot, shoe, level
            {
                case 1: // Animal (Ball)
                    if (Animal_ScrollingButtons.transform.position.x > DesiredLocation.x + SnappingSpeed)
                    {
                        Animal_ScrollingButtons.transform.position = new Vector2(Animal_ScrollingButtons.transform.position.x - SnappingSpeed, Animal_ScrollingButtons.transform.position.y);
                    }
                    else if (Animal_ScrollingButtons.transform.position.x < DesiredLocation.x - SnappingSpeed)
                    {
                        Animal_ScrollingButtons.transform.position = new Vector2(Animal_ScrollingButtons.transform.position.x + SnappingSpeed, Animal_ScrollingButtons.transform.position.y);
                    }
                    else
                    {
                        Animal_ScrollingButtons.transform.position = new Vector2(DesiredLocation.x, Animal_ScrollingButtons.transform.position.y);
                    }
                    break;

                case 2: // Foot
                    break;

                case 3: // Shoe
                    break;

                case 4: // Level
                    break;
            }
        }
        else
        {
            Debug.Log("Invalid TouchCount");
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.name)
        {
            // ANIMAL Buttons
            case "Ball01":
                SnapPoint = 0;
                break;

            case "Ball02":
                SnapPoint = 0; 
                break;

            case "Ball03":
                if (CurrentPage < 1)
                {
                    SnapPoint = 1;
                }
                else if (CurrentPage >= 1)
                {
                    SnapPoint = 0;
                }
                break;

            case "Ball13":
                if (CurrentPage < 1)
                {
                    SnapPoint = 1;
                }
                else if (CurrentPage >= 1)
                {
                    SnapPoint = 0;
                }
                break;

            case "Ball14":
                SnapPoint = 1;
                break;

            case "Ball15":
                if (CurrentPage < 2)
                {
                    SnapPoint = 2;
                }
                else if (CurrentPage >= 2)
                {
                    SnapPoint = 1;
                }
                break;

            case "Ball25":
                if (CurrentPage < 2)
                {
                    SnapPoint = 2;
                }
                else if (CurrentPage >= 2)
                {
                    SnapPoint = 1;
                }
                break;

            case "Ball26":
                SnapPoint = 2;
                break;

            case "Ball27":
                if (CurrentPage < 3)
                {
                    SnapPoint = 3;
                }
                else if (CurrentPage >= 3)
                {
                    SnapPoint = 2;
                }
                break;

            //case "Ball37":
            //    if (CurrentPage < 3)
            //    {
            //        SnapPoint = 3;
            //    }
            //    else if (CurrentPage >= 3)
            //    {
            //        SnapPoint = 2;
            //    }
            //    break;

            //case "Ball38":
            //    SnapPoint = 3;
            //    break;

            //case "Ball39":
            //    if (CurrentPage < 4)
            //    {
            //        SnapPoint = 4;
            //    }
            //    else if (CurrentPage >= 4)
            //    {
            //        SnapPoint = 3;
            //    }
            //    break;

                //case "Ball49":
                //    if (CurrentPage < 4)
                //    {
                //        SnapPoint = 4;
                //    }
                //    else if (CurrentPage >= 4)
                //    {
                //        SnapPoint = 3;
                //    }
                //    break;

                //case "Ball50":
                //    SnapPoint = 4; 
                //    break;

                //case "Ball51":
                //    SnapPoint = 4; 
                //    break;
        }
    }

    void EnableUpperSnap()
    {
        this.GetComponent<CircleCollider2D>().enabled = true;
    }

}
