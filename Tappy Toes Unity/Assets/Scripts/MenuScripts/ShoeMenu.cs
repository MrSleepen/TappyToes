using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoeMenu : MonoBehaviour
{
    // Animation Variables
    Image m_Image;
    //Set this in the Inspector
    // public Sprite m_Sprite;
    public Sprite[] ShoeSprite;


    private void Update()
    {
        m_Image = GetComponent<Image>();

        GameManager.Instance.ShoeNum = PlayerPrefs.GetInt("ShoeNumSave");
        m_Image.sprite = ShoeSprite[GameManager.Instance.ShoeNum];
    }

   

}

    

    

        
