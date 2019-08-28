using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquishBall : MonoBehaviour
{
    // NOTE
    // this scripts scales the BallObject, which is the Parent of the Ball thus that the ball is be scaled in the axis that this BallObject is rotated.

    private bool JustKicked = false;
    private bool Squishing = false;

    private float SquishAmmount = 0.91f; // percentage of original "Y" to squish to  // 0.91 = barely noticeable,  0.88 = very noticable,    anything else won't look good
    //private float BloatAmmount = 1.06f;  // percentage of original "X" to squish to  // 1.06 = barely noticeable,  1.08 = very noticable,    anything else won't look good

    private float SquishRate_Y = 0.03f; // how much it squishes on the "Y" per update  // 0.03
    //private float SquishRate_X = 0.02f;  // how much it squishes on the "X" per update // 0.02


    void FixedUpdate()
    {
        // Trigger a squish
        if (JustKicked)
        {
            JustKicked = false;
            Squishing = true;
        }

        // Squishing
        if (Squishing)
        {
            // Decrease Y
            if (transform.localScale.y > SquishAmmount)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - SquishRate_Y, 1);
            }
            else
            {
                Squishing = false;
            }

            //// Increase X
            //if (transform.localScale.x < BloatAmmount)
            //{
            //    transform.localScale = new Vector3(transform.localScale.x + SquishRate_X, transform.localScale.y, 1);
            //}

            ////Stop Squishing when reached squish thresholds
            //if (transform.localScale.y <= SquishAmmount && transform.localScale.x >= BloatAmmount)
            //{
            //    Squishing = false;
            //}
        }
        else // un-Squishing
        {
            // Increase Y back to default
            if (transform.localScale.y < 1.0f)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + SquishRate_Y, 1);
            }
            else if (transform.localScale.y != 1.0f)
            {
                transform.localScale = new Vector3(transform.localScale.x, 1, 1);
            }

            //// Decrease X back to default
            //if (transform.localScale.x > 1.0f)
            //{
            //    transform.localScale = new Vector3(transform.localScale.x - SquishRate_X, transform.localScale.y, 1);
            //}
            //else if (transform.localScale.x != 1.0f)
            //{
            //    transform.localScale = new Vector3(1, transform.localScale.y, 1);
            //}
        }
    }

    // triggers a squish
    public void JustGotKicked()
    {
        JustKicked = true;
    }

}
