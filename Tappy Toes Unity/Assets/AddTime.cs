using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTime : MonoBehaviour
{
    public GameObject Lights;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ball":
                Debug.Log("HUT");
                Lights.GetComponent<DarkenScreen>().AddTime();
                break;
        }
    }
}
