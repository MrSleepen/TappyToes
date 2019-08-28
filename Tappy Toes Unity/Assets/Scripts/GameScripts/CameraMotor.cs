using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

    public bool stopFollowing = false;

    private Vector3 DefaultPos;
    public Transform LookAt;
    private float BoundX = .5f;
    public float BoundY = 5f;
    private float CutOffX;

    void Start()
    {
        // Set Default pos to pos of itself at start
        DefaultPos = transform.position;
    }

    //creat a middle box, if the ball leaves the box make camera follow ball, if it goes past the cutt off stop following again.
    public void LateUpdate()
    {
        if (!stopFollowing)
        {
            CutOffX = transform.position.x;
            Vector3 delta = Vector3.zero;
            // X  Axis
            float dx = LookAt.position.x - transform.position.x;

            if (dx > BoundX || dx < -BoundX)
            {
                if (transform.position.x < LookAt.position.x && CutOffX < 1.3f)
                {
                    delta.x = dx - BoundX;

                }
                else if (transform.position.x > LookAt.position.x && CutOffX > -1.3f)
                {
                    delta.x = dx + BoundX;
                }
            }

            // Move camera
            transform.position = transform.position + delta / 20;
        }
    }

    public void CenterCamera() 
    {
        stopFollowing = true;
        transform.position = DefaultPos; // returns to Default Position
    }

    public void UnCenterCamera()
    {
        stopFollowing = false;
    }
}
