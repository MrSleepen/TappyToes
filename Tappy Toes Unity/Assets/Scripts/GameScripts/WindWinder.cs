using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindWinder : MonoBehaviour {

    public AreaEffector2D WindEffector;

    public ParticleSystem Westward_Gust;
    public ParticleSystem Westward_Breeze;
    public ParticleSystem Central_Updraft;
    public ParticleSystem Eastward_Breeze;
    public ParticleSystem Eastward_Gust;
    public GameObject Ball;

    private bool WindEnabled;
    private int WindDir;
    private float WindTimer;
    private float WindDelay = 2.0f;

    private float WindForce;


    // Use this for initialization
    void Start () {
        HaltWind();

        if (Ball == null)
        {
            Ball = GameObject.FindWithTag("Ball");
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(Ball.GetComponent<AdvancedBall>().WindBlowing == true)
        {
            WindPhysics_Enable();
        }
        else if (Ball.GetComponent<AdvancedBall>().WindBlowing == false)
        {
            Wind_Disable();
        }

        if (WindEnabled)
        {
            WindTimer -= Time.deltaTime;

            if (WindTimer <= 0)
            {
                HaltWind();
                ChangeWindDir();
            }
        }
	}

    public void Wind_Enable()
    {
        WindEnabled = true;
    }

    public void Wind_Disable()
    {
        WindEnabled = false;
        HaltWind();
    }

    // make wind physics affect the ball (called on foot kicks ball)
    public void WindPhysics_Enable()
    {
        WindEffector.forceMagnitude = WindForce;
        WindEnabled = true;
    }

    // make wind physics stop affecting the ball (called on ball hit ground)
    public void WindPhysics_Disable()
    {
        WindEffector.forceMagnitude = 0;
        WindEnabled = false;
    }

    void HaltWind()
    {
        WindEffector.forceMagnitude = 0;
        WindForce = 0;
        Westward_Gust.Stop();
        Westward_Breeze.Stop();
        Central_Updraft.Stop();
        Eastward_Breeze.Stop();
        Eastward_Gust.Stop();
    }

    void ChangeWindDir()
    {
        WindPhysics_Enable();
            int rand = Random.Range(-2, 2); // -1, 0, 1
            WindDir += rand;

            // don't exceed possible conditions
            if (WindDir > 2)
            {
                WindDir = 2;
            }
            else if (WindDir < -2)
            {
                WindDir = -2;
            }

            switch (WindDir)
            {
                case -2:
                    WindTimer = 3f + WindDelay;
                    Invoke("West_Gust", WindDelay);
                    break;

                case -1:
                    WindTimer = 7f + WindDelay;
                    Invoke("West_Breeze", WindDelay);
                    break;

                case 0:
                    WindTimer = 2f + WindDelay;
                    Invoke("Center_Updraft", WindDelay);
                    break;

                case 1:
                    WindTimer = 7f + WindDelay;
                    Invoke("East_Breeze", WindDelay);
                    break;

                case 2:
                    WindTimer = 3f + WindDelay;
                    Invoke("East_Gust", WindDelay);
                    break;
        }
    }

    private void West_Gust()
    {
        Westward_Gust.Play();
        WindEffector.forceAngle = 180;
        WindEffector.forceMagnitude = 10;
        WindForce = 10;
    }

    private void West_Breeze()
    {
        Westward_Breeze.Play();
        WindEffector.forceAngle = 180;
        WindEffector.forceMagnitude = 5;
        WindForce = 5;
    }

    private void Center_Updraft()
    {
        Central_Updraft.Play();
        WindEffector.forceAngle = 90;
        WindEffector.forceMagnitude = 5;
        WindForce = 5;
    }

    private void East_Breeze()
    {
        Eastward_Breeze.Play();
        WindEffector.forceAngle = 0;
        WindEffector.forceMagnitude = 5;
        WindForce = 5;
    }

    private void East_Gust()
    {
        Eastward_Gust.Play();
        WindEffector.forceAngle = 0;
        WindEffector.forceMagnitude = 10;
        WindForce = 10;
    }
}
