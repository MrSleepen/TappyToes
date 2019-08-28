using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLives : MonoBehaviour {

	void Start () {

        //Debug.Log("Reset Lives At Start");
        GameManager.Instance.lives = 2;
	}
}
