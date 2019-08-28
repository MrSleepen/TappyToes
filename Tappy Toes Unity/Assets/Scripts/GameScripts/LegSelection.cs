using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegSelection : MonoBehaviour
{
    public Sprite[] LegSprite;

    void Start ()
    {
        //Debug.Log("Leg Changed (Start)");
        gameObject.GetComponent<SpriteRenderer>().sprite = LegSprite[GameManager.Instance.FootNum];
    }
	
	void Update ()
    {
        //Debug.Log("Leg Changed (Update)");
        gameObject.GetComponent<SpriteRenderer>().sprite = LegSprite[GameManager.Instance.FootNum];
    }

}
