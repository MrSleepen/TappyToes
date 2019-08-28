using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoeLocks : MonoBehaviour {

    public GameObject[] Locks;
	
	// Set the locks to the size of the shoe list
	void Update () {

        for (int i = 0; i < PlayerPrefs.GetInt("ShoeUnlocked") + 1; i++)
        {
            Locks[i].SetActive(false);
        }
    }
}
