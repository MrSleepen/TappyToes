using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPart : MonoBehaviour
{
    public ParticleSystem ParticleLauncher;
    
    public Gradient PartColorGrad;
    public float ColorNumber;
    public Color ColorOfPart;
   

	void Update () {

      // Set Color According to Ball Number
        if (PlayerPrefs.GetInt("AnimalNumSave") == 0) // Soccerball (black)
        {
            ColorOfPart = new Color(0.30f, 0.30f, 0.30f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 1) // Soccerball (brown)
        {
            ColorOfPart = new Color(0.38f, 0.22f, 0.19f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 2) // Soccerball (purple)
        {
            ColorOfPart = new Color(0.35f, 0.26f, 0.36f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 3) // Beach Ball 1
        {
            ColorOfPart = new Color(0.96f, 0.96f, 0.96f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 4) // Beach Ball 2
        {
            ColorOfPart = new Color(0.96f, 0.96f, 0.96f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 5) // Beach Ball 3
        {
            ColorOfPart = new Color(1.0f, 0.97f, 0.53f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 6) // Grey Ball
        {
            ColorOfPart = new Color(0.33f, 0.33f, 0.33f, 1f); 
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 7) // Brown Ball
        {
            ColorOfPart = new Color(0.43f, 0.23f, 0.26f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 8) // Pink-ish Ball
        {
            ColorOfPart = new Color(0.90f, 0.31f, 0.31f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 9) // Basketball (yellow)
        {
            ColorOfPart = new Color(0.97f, 0.71f, 0.0f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 10) // Basketball (light brown)
        {
            ColorOfPart = new Color(1.0f, 0.73f, 0.3f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 11) // Basketball (redish orange)
        {
            ColorOfPart = new Color(1.0f, 0.22f, 0.05f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 12) // Baseball 1
        {
            ColorOfPart = new Color(0.89f, 0.89f, 0.89f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 13) // Baseball 2
        {
            ColorOfPart = new Color(0.87f, 0.67f, 0.82f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 14) // Baseball 3
        {
            ColorOfPart = new Color(0.87f, 0.67f, 0.82f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 15) // Bowling Ball (black)
        {
            ColorOfPart = new Color(0.18f, 0.18f, 0.18f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 16) // Bowling Ball (red)
        {
            ColorOfPart = new Color(0.38f, 0.04f, 0.12f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 17) // Bowling Ball (purple)
        {
            ColorOfPart = new Color(0.40f, 0.06f, 0.29f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 18) // Poolball(8) (black)
        {
            ColorOfPart = new Color(0.1f, 0.1f, 0.1f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 19) // Poolball(8) (red)
        {
            ColorOfPart = new Color(0.46f, 0.09f, 0.18f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 20) // Poolball(8) (purple)
        {
            ColorOfPart = new Color(0.40f, 0.06f, 0.29f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 21) // Waterballon 1
        {
            ColorOfPart = new Color(0.15f, 0.39f, 0.74f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 22) // Waterballon 2
        {
            ColorOfPart = new Color(0.20f, 0.31f, 0.42f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 23) // Waterballon 3
        {
            ColorOfPart = new Color(0.20f, 0.28f, 0.89f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 24) // Blueball 1
        {
            ColorOfPart = new Color(0.31f, 0.60f, 0.87f, 0.75f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 25) // Blueball 2
        {
            ColorOfPart = new Color(0.31f, 0.48f, 0.86f, 0.75f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 26) // Blueball 3
        {
            ColorOfPart = new Color(0.31f, 0.45f, 0.85f, 0.75f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 27) // Bubbleball 1
        {
            ColorOfPart = new Color(0.31f, 0.86f, 0.75f, 0.75f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 28) // Bubbleball 2
        {
            ColorOfPart = new Color(0.39f, 0.15f, 1.0f, 0.5f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 29) // Bubbleball 3
        {
            ColorOfPart = new Color(0.32f, 0.11f, 0.92f, 0.5f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 30) // Egg 1
        {
            ColorOfPart = new Color(0.97f, 0.97f, 0.81f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 31) // Egg 2
        {
            ColorOfPart = new Color(0.98f, 0.85f, 0.77f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 32) // Egg 3
        {
            ColorOfPart = new Color(0.99f, 0.80f, 0.90f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 33) // Donut 1
        {
            ColorOfPart = new Color(0.99f, 0.40f, 0.76f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 34) // Donut 2
        {
            ColorOfPart = new Color(0.94f, 0.36f, 0.69f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 35) // Donut 3
        {
            ColorOfPart = new Color(0.89f, 0.32f, 0.65f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 36) // Eyeball left
        {
            ColorOfPart = new Color(0.31f, 0.62f, 0.15f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 37) // Eyeball forward
        {
            ColorOfPart = new Color(0.31f, 0.62f, 0.15f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 38) // Eyeball right
        {
            ColorOfPart = new Color(0.31f, 0.62f, 0.15f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 39) // Monster (1-eye)
        {
            ColorOfPart = new Color(0.0f, 0.65f, 0.58f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 40) // Demon
        {
            ColorOfPart = new Color(0.92f, 0.43f, 0.76f, 1f);
        }
        else if (PlayerPrefs.GetInt("AnimalNumSave") == 41) // AbSnowman
        {
            ColorOfPart = new Color(0.43f, 0.80f, 0.70f, 1f);
        }

        ParticleSystem.MainModule psMain = ParticleLauncher.main;
        psMain.startColor = ColorOfPart;
        ParticleSystem.TrailModule Trails = ParticleLauncher.trails;
        Trails.colorOverLifetime = ColorOfPart;
        Trails.colorOverTrail = ColorOfPart;
    }

}
