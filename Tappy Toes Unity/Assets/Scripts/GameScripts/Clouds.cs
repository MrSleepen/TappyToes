using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour {
    private Vector2 CloudSize;
    public GameObject Cloud;
  
    public GameObject[] SnapPoint;
    public int SnapLocation;
    private float Speed;
    private bool Sized;


    // Update is called once per frame
    void Update () {

// Choose random size and speed for clouds/ then move them acrost the screen
        if (Sized == false)
        { 
            CloudSize.x = Random.Range(.5f, 1.5f);
            CloudSize.y = Random.Range(.5f, 1.5f);
            Speed = Random.Range(.5f, 3f);
            Sized = true;
            SnapLocation = Random.Range(1, 3);
        }

        transform.localScale = CloudSize;

        transform.Translate(Vector3.left * Time.deltaTime * Speed, Space.World);
        
    }
    //if cloud hits reset bos reset to original and choose new size and speed
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "CloudReset":
                Sized = false;
                Cloud.transform.position = SnapPoint[SnapLocation].transform.position;
                break;
        }
    }

}
