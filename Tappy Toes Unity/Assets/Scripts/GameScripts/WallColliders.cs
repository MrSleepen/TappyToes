using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Original Script FROM
// https://forum.unity.com/threads/collision-with-sides-of-screen.228865/

public class WallColliders : MonoBehaviour {

    // game Objects references, used if updating the colliders
    private GameObject TopColliderObj;
    private GameObject BottomColliderObj;
    private GameObject LeftColliderObj;
    private GameObject RightColliderObj;

    // variables for setting size
    private Vector2 screenSize;
    public float colThickness = 4f;
    public float zPosition = 0f;

    // Inward offsets on collider positions
    private float TopOffset = 0f;
    private float BottomOffset = 0.6f;
    private float RightOffset = 0f;
    private float LeftOffset = 0f;

 
    void Start()
    {
        //Create a Dictionary to contain all our Objects/Transforms
        System.Collections.Generic.Dictionary<string, Transform> colliders = new System.Collections.Generic.Dictionary<string, Transform>();
        
        //Create our GameObjects and add their Transform components to the Dictionary we created above
        colliders.Add("Top", new GameObject().transform);
        colliders.Add("Bottom", new GameObject().transform);
        colliders.Add("Left", new GameObject().transform);
        colliders.Add("Right", new GameObject().transform);

        //Generate world space point information for position and scale calculations
        Vector3 cameraPos = Camera.main.transform.position;
        //Grab the world-space position values of the start and end positions of the screen, then calculate the distance between them and store it as half, since we only need half that value for distance away from the camera to the edge
        screenSize.x = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f; 
        screenSize.y = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;
       
        //For each Transform/Object in our Dictionary
        foreach (KeyValuePair<string, Transform> valPair in colliders)
        {
            valPair.Value.gameObject.AddComponent<BoxCollider2D>(); //Add our colliders. Remove the "2D", if you would like 3D colliders.
            valPair.Value.name = valPair.Key + "Collider"; //Set the object's name to it's "Key" name, and take on "Collider".  i.e: TopCollider
            valPair.Value.parent = transform; //Make the object a child of whatever object this script is on (preferably the camera)

            if (valPair.Key == "Left" || valPair.Key == "Right") //Scale the object to the width and height of the screen, using the world-space values calculated earlier
                valPair.Value.localScale = new Vector3(colThickness, screenSize.y * 2, colThickness);
            else
                valPair.Value.localScale = new Vector3(screenSize.x * 2, colThickness, colThickness);
        }
       
        //Change positions to align perfectly with outter-edge of screen, adding the world-space values of the screen we generated earlier, and adding/subtracting them with the current camera position, as well as add/subtracting half out objects size so it's not just half way off-screen
        colliders["Top"].position = new Vector3(cameraPos.x, cameraPos.y + screenSize.y + (colliders["Top"].localScale.y * 0.5f) - TopOffset, zPosition);
        colliders["Bottom"].position = new Vector3(cameraPos.x, cameraPos.y - screenSize.y - (colliders["Bottom"].localScale.y * 0.5f) + BottomOffset, zPosition);
        colliders["Left"].position = new Vector3(cameraPos.x - screenSize.x - (colliders["Left"].localScale.x * 0.5f) + LeftOffset, cameraPos.y, zPosition);
        colliders["Right"].position = new Vector3(cameraPos.x + screenSize.x + (colliders["Right"].localScale.x * 0.5f) + RightOffset, cameraPos.y, zPosition);

        // set GameObject References (used only in LateUpdate)
        TopColliderObj = colliders["Top"].transform.gameObject;
        BottomColliderObj = colliders["Bottom"].transform.gameObject;
        LeftColliderObj = colliders["Left"].transform.gameObject;
        RightColliderObj = colliders["Right"].transform.gameObject;

        // Set Tag = "Wall"
        colliders["Top"].transform.gameObject.tag = "Wall";
        colliders["Bottom"].transform.gameObject.tag = "Wall";
        colliders["Left"].transform.gameObject.tag = "Wall";
        colliders["Right"].transform.gameObject.tag = "Wall";
    }

    void LateUpdate()
    {
        //Generate world space point information for position and scale calculations
        Vector3 cameraPos = Camera.main.transform.position;
        //Grab the world-space position values of the start and end positions of the screen, then calculate the distance between them and store it as half, since we only need half that value for distance away from the camera to the edge
        screenSize.x = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
        screenSize.y = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;

        //Change positions to align perfectly with outter-edge of screen, like we did earlier but using the GameObject references
        TopColliderObj.transform.position = new Vector3(cameraPos.x, cameraPos.y + screenSize.y + (TopColliderObj.transform.localScale.y * 0.5f) - TopOffset, zPosition);
        BottomColliderObj.transform.position = new Vector3(cameraPos.x, cameraPos.y - screenSize.y - (BottomColliderObj.transform.localScale.y * 0.5f) + BottomOffset, zPosition);
        LeftColliderObj.transform.position = new Vector3(cameraPos.x - screenSize.x - (LeftColliderObj.transform.localScale.x * 0.5f) + LeftOffset, cameraPos.y, zPosition);
        RightColliderObj.transform.position = new Vector3(cameraPos.x + screenSize.x + (RightColliderObj.transform.localScale.x * 0.5f) + RightOffset, cameraPos.y, zPosition);
    }

}
