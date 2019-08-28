using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkenScreen : MonoBehaviour {

    public GameObject LightSwitch;
    public GameObject Ball;
    public GameObject LastChance;

    private Image image;
    private float Timer = 10;
    private float LightLevel = 0;
    private bool PlayedEnum = false;

    // Update is called once per frame
    void Update() {
        Debug.Log(Timer);
        if (LastChance.GetComponent<LastChance>().Lights == false)
        {
            LastchanceActive();
            
        }
        image = GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = LightLevel;
        image.color = tempColor;

        if (Ball.GetComponent<AdvancedBall>().WindBlowing == true)
        {
            Timer -= Time.deltaTime;
        }
        if (GameManager.Instance.lives < 0)
        {
            LightLevel = 0;
        }

        if (Timer <= 1f && PlayedEnum == false)
        {
            StartCoroutine(Flicker());
            PlayedEnum = true;
        }


    }

    private void timerEnded()
    {
        LightLevel = 1;
    }

    private IEnumerator Flicker()
    {
        LightLevel = .5f;
        yield return new WaitForSeconds(.1f);
        LightLevel = 0;
        yield return new WaitForSeconds(.1f);
        LightLevel = .5f;
        yield return new WaitForSeconds(.1f);
        LightLevel = 0;
        yield return new WaitForSeconds(.1f);
        LightLevel = .5f;
        yield return new WaitForSeconds(.1f);
        LightLevel = 0;
        yield return new WaitForSeconds(.1f);
        LightLevel = .5f;
        yield return new WaitForSeconds(.1f);
        LightLevel = 0;
        yield return new WaitForSeconds(.1f);
        LightLevel = .5f;
        yield return new WaitForSeconds(.1f);
        LightLevel = 0;
        yield return new WaitForSeconds(.1f);
        LightLevel = .5f;
        yield return new WaitForSeconds(.1f);
        LightLevel = 0;
        yield return new WaitForSeconds(.1f);
        timerEnded();
    }


        public void LastchanceActive()
    {
        PlayedEnum = false;
        if (Timer < 5)
        {
            Timer = 5;
        }
        LastChance.GetComponent<LastChance>().Lights = true;
    }
    public void AddTime()
    {
        Timer += 5;
    }

}
