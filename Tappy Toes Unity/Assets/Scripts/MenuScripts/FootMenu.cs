using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FootMenu : MonoBehaviour
{
    Image m_Image;
    public Sprite[] FootSprite;

    private void Update()
    {
        m_Image = GetComponent<Image>();
        m_Image.sprite = FootSprite[GameManager.Instance.FootNum];
    }

}

    

    

        
