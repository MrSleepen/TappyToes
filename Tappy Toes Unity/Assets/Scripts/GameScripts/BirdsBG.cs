using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsBG : MonoBehaviour
{
    public GameObject Bird;

    public GameObject[] SnapPoint;
    public int SnapLocation;
    private float Speed;
    private bool Sized;


    // Update is called once per frame
    void Update()
    {
        // Choose random size and speed for clouds/ then move them acrost the screen
        if (Sized == false)
        {
            Speed = Random.Range(1f, 1.5f);
            Sized = true;
            SnapLocation = Random.Range(1, 3);
        }

        transform.Translate(Vector3.left * Time.deltaTime * Speed, Space.World);
    }

    //if cloud hits reset bos reset to original and choose new size and speed
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "CloudReset":
                Sized = false;
               Bird.transform.position = SnapPoint[SnapLocation].transform.position;
                break;
        }
    }

}
