using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoeSelection : MonoBehaviour
{
    public Sprite[] ShoeSprite;

    void Start ()
    {
        //Debug.Log("Shoe Changed (Start)");
        gameObject.GetComponent<SpriteRenderer>().sprite = ShoeSprite[GameManager.Instance.ShoeNum];
    }
	
	void Update ()
    {
        //Debug.Log("Shoe Changed (Update)");
        gameObject.GetComponent<SpriteRenderer>().sprite = ShoeSprite[GameManager.Instance.ShoeNum];
    }
}
