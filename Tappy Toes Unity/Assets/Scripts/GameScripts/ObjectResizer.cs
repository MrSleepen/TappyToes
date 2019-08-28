using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectResizer : MonoBehaviour {

    void Start()
    {
        float ScaleFactor = Screen.width / 480f; // 480f is the screenWidth it was designed for (480 x 800)
        ScaleFactor = 1 / ScaleFactor; // inverse the result

        transform.localScale = new Vector2(transform.localScale.x * ScaleFactor, transform.localScale.y * ScaleFactor); 
    }

}
