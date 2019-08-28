using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoeSelect : MonoBehaviour {

    public GameObject[] Locks;
    public Sprite[] ShoeSprite;

    public GameObject[] ShoeIcons; // includes Shoe_MostRecent in slot "0" (NumShoes +1)
    public GameObject MostRecent;
    public Sprite[] Default;
    public Sprite[] Selected;
    public int NumShoes = 10; // number of shoes, not value in array (which is 1 less than this number)

    //All Buttons below asigned to Shoe select buttons "Buttons4" on main menu These change the number in the
    //Game manger which in turn selects a number for an array of sprite to choose.

    void Start()
    {
        ResetSelected();
        if (PlayerPrefs.GetInt("ShoeSelected") == 0)
        {
            ShoeIcons[0].GetComponent<Image>().sprite = Selected[0]; // set selected to MostRecentShoe
        }
        else
        {
            ShoeIcons[PlayerPrefs.GetInt("ShoeSelected")].transform.GetChild(0).GetComponent<Image>().sprite = Selected[PlayerPrefs.GetInt("ShoeSelected")]; // set selected, must be after ResetSelected()
        } 
    }

    public void Sneaker()
    {
        PlayerPrefs.SetInt("ShoeSelected", 1);
        PlayerPrefs.SetInt("HasChosenShoe", 1);
        PlayerPrefs.SetInt("ShoeNumSave", 0);

        ResetSelected();
        ShoeIcons[1].transform.GetChild(0).GetComponent<Image>().sprite = Selected[1]; // set selected, must be after ResetSelected()
    }

    public void Band()
    {
        if (PlayerPrefs.GetInt("ShoeUnlocked") >= 1)
        {
            PlayerPrefs.SetInt("ShoeSelected", 2);
            PlayerPrefs.SetInt("HasChosenShoe", 1);
            PlayerPrefs.SetInt("ShoeNumSave", 1);

            ResetSelected();
            ShoeIcons[2].transform.GetChild(0).GetComponent<Image>().sprite = Selected[2]; // set selected, must be after ResetSelected()
        }
    }

    public void Dress()
    {
        if (PlayerPrefs.GetInt("ShoeUnlocked") >= 2)
        {
            PlayerPrefs.SetInt("ShoeSelected", 3);
            PlayerPrefs.SetInt("HasChosenShoe", 1);
            PlayerPrefs.SetInt("ShoeNumSave", 2);

            ResetSelected();
            ShoeIcons[3].transform.GetChild(0).GetComponent<Image>().sprite = Selected[3]; // set selected, must be after ResetSelected()
        }
    }

   public void Sand()
   {
        if (PlayerPrefs.GetInt("ShoeUnlocked") >= 3)
        {
            PlayerPrefs.SetInt("ShoeSelected", 4);
            PlayerPrefs.SetInt("HasChosenShoe", 1);
            PlayerPrefs.SetInt("ShoeNumSave", 3);

            ResetSelected();
            ShoeIcons[4].transform.GetChild(0).GetComponent<Image>().sprite = Selected[4]; // set selected, must be after ResetSelected()
        }
   }

    public void RubBoot()
    {
        if (PlayerPrefs.GetInt("ShoeUnlocked") >= 4)
        {
            PlayerPrefs.SetInt("ShoeSelected", 5);
            PlayerPrefs.SetInt("HasChosenShoe", 1);
            PlayerPrefs.SetInt("ShoeNumSave", 4);

            ResetSelected();
            ShoeIcons[5].transform.GetChild(0).GetComponent<Image>().sprite = Selected[5]; // set selected, must be after ResetSelected()
        }
    }

    public void CowBoot()
    {
        if (PlayerPrefs.GetInt("ShoeUnlocked") >=5)
        {
            PlayerPrefs.SetInt("ShoeSelected", 6);
            PlayerPrefs.SetInt("HasChosenShoe", 1);
            PlayerPrefs.SetInt("ShoeNumSave", 5);

            ResetSelected();
            ShoeIcons[6].transform.GetChild(0).GetComponent<Image>().sprite = Selected[6]; // set selected, must be after ResetSelected()
        }
    }

    public void Metal()
    {
        if (PlayerPrefs.GetInt("ShoeUnlocked") >= 6)
        {
            PlayerPrefs.SetInt("ShoeSelected", 7);
            PlayerPrefs.SetInt("HasChosenShoe", 1);
            PlayerPrefs.SetInt("ShoeNumSave", 6);

            ResetSelected();
            ShoeIcons[7].transform.GetChild(0).GetComponent<Image>().sprite = Selected[7]; // set selected, must be after ResetSelected()
        }
    }

    public void Cast()
    {
        if (PlayerPrefs.GetInt("ShoeUnlocked") >= 7)
        {
            PlayerPrefs.SetInt("ShoeSelected", 8);
            PlayerPrefs.SetInt("HasChosenShoe", 1);
            PlayerPrefs.SetInt("ShoeNumSave", 7);

            ResetSelected();
            ShoeIcons[8].transform.GetChild(0).GetComponent<Image>().sprite = Selected[8]; // set selected, must be after ResetSelected()
        }
    }

    public void Hairy()
    {
        if (PlayerPrefs.GetInt("ShoeUnlocked") >= 8)
        {
            PlayerPrefs.SetInt("ShoeSelected", 9);
            PlayerPrefs.SetInt("HasChosenShoe", 1);
            PlayerPrefs.SetInt("ShoeNumSave", 8);

            ResetSelected();
            ShoeIcons[9].transform.GetChild(0).GetComponent<Image>().sprite = Selected[9]; // set selected, must be after ResetSelected()
        }
    }

    public void Flipper()
    {
        if (PlayerPrefs.GetInt("ShoeUnlocked") >= 9)
        {
            PlayerPrefs.SetInt("ShoeSelected", 10);
            PlayerPrefs.SetInt("HasChosenShoe", 1);
            PlayerPrefs.SetInt("ShoeNumSave", 9);

            ResetSelected();
            ShoeIcons[10].transform.GetChild(0).GetComponent<Image>().sprite = Selected[10]; // set selected, must be after ResetSelected()
        }
    }

    public void ResetSelected()
    {
        for (int i = 0; i < NumShoes; i++)
        {
            if (i != 0) // 0 is MostRecent, which is handled below without the "getchild" as per the hierarchy
                ShoeIcons[i].transform.GetChild(0).GetComponent<Image>().sprite = Default[i];
        }
        MostRecent.GetComponent<Image>().sprite = Default[0];
    }

    private void Update()
    {
        GameManager.Instance.ShoeNum = PlayerPrefs.GetInt("ShoeNumSave");
        gameObject.GetComponent<SpriteRenderer>().sprite = ShoeSprite[GameManager.Instance.ShoeNum];

        for (int i = 0; i < PlayerPrefs.GetInt("ShoeUnlocked") + 1; i++)
        {
            if (i > 9) // out of array
            {

            }
            else  // in array
            {
                Locks[i].SetActive(false);
            }
        }
    }

    public void UpdateShoeSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = ShoeSprite[GameManager.Instance.ShoeNum];
    }

}
