using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMenu : MonoBehaviour
{
    // Animation Variables
    Image m_Image;
    //Set this in the Inspector
    //public Sprite m_Sprite;
    public Sprite[] BallSprite;

    void Start()
    {
        m_Image = GetComponent<Image>();
        UpdateBallIcon();
    }

    public void UpdateBallIcon()
    {
        //set animal sprite to Savestate AnimalNumSave
        GameManager.Instance.AnimalNum = PlayerPrefs.GetInt("AnimalNumSave");
        if (m_Image != null)
            m_Image.sprite = BallSprite[GameManager.Instance.AnimalNum];
    }

}

    

    

        
