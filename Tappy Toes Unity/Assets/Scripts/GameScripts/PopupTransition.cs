using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupTransition : MonoBehaviour {

    public GameObject Popup;
    private float TransitionSpeed = Screen.height * 1.75f; // slinding up to screen at start

    public void AnimatedPopup()
    {
        // Set Popup Position (above screen)
        Popup.transform.position = new Vector3(Popup.transform.position.x, Screen.height * 1.1f, Popup.transform.position.z);
        GameObject ButtonScript = GameObject.Find("ButtonScript");
        ButtonScript.GetComponent<LastChance>().PopupActive = true;
    }

	void Update ()
    {
        //Move "LastChancePopup"
        if (Popup.transform.position.y > Screen.height * 0.5f + 1f)
        {
            Popup.transform.Translate(Vector3.down * TransitionSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            Popup.transform.position = new Vector3(Popup.transform.position.x, Screen.height * 0.5f, Popup.transform.position.z);
            Time.timeScale = 0;
        }
    }
}
