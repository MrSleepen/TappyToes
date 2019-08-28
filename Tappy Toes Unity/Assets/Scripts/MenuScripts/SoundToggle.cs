using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    GameObject MainCamera;
    // Animation Variables
    Image m_Image;
    //Set this in the Inspector
    // public Sprite m_Sprite;
    public Sprite[] SoundSprite;

    private void Update()
    {
        //Debug.Log(GetComponent<Image>());
        m_Image = GetComponent<Image>();

        //set animal sprite to Savestate AnimalNumSave
        GameManager.Instance.AnimalNum = PlayerPrefs.GetInt("SoundNumSave");

        //gameObject.GetComponent<SpriteRenderer>().sprite = AnimalSprite[GameManager.Instance.AnimalNum];
        m_Image.sprite = SoundSprite[PlayerPrefs.GetInt("SoundNumSave")]; 
    }

    public void SoundToggles()
    {
        if (PlayerPrefs.GetInt("SoundNumSave") == 0){
            PlayerPrefs.SetInt("SoundNumSave", 1);
        }
        else
        {
            PlayerPrefs.SetInt("SoundNumSave", 0);
        }
    }

}