using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FootSelect : MonoBehaviour {

    public GameObject[] Locks;

    public GameObject[] FootIcons; // includes Foot_MostRecent in slot "0" (NumFeet +1)
    public GameObject MostRecent;
    public Sprite[] Default;
    public Sprite[] Selected;
    public int NumFeet = 10; // number of feet, not value in array (which is 1 less than this number)

    //All Buttons below asigned to Foot select buttons "Buttons4" on main menu These change the number in the
    //Game manger which in turn selects a number for an array of sprite to choose.

    void Start()
    {
        ResetSelected();
        if (PlayerPrefs.GetInt("FootSelected") == 0)
        {
            FootIcons[0].GetComponent<Image>().sprite = Selected[0]; // set selected to MostRecentFoot
        }
        else
        {
            FootIcons[PlayerPrefs.GetInt("FootSelected")].transform.GetChild(0).GetComponent<Image>().sprite = Selected[PlayerPrefs.GetInt("FootSelected")]; // set selected, must be after ResetSelected()
        }
    }

    public void Bare()
    {
        PlayerPrefs.SetInt("FootSelected", 1);
        PlayerPrefs.SetInt("HasChosenFoot", 1);
        PlayerPrefs.SetInt("FootNumSave", 0);

        ResetSelected();
        FootIcons[1].transform.GetChild(0).GetComponent<Image>().sprite = Selected[1]; // set selected, must be after ResetSelected()
    }

    public void Tatoo()
    {
        if (PlayerPrefs.GetInt("FootUnlocked") >= 1)
        {
            PlayerPrefs.SetInt("FootSelected", 2);
            PlayerPrefs.SetInt("HasChosenFoot", 1);
            PlayerPrefs.SetInt("FootNumSave", 1);

            ResetSelected();
            FootIcons[2].transform.GetChild(0).GetComponent<Image>().sprite = Selected[2]; // set selected, must be after ResetSelected()
        }
    }

    public void Hairy()
    {
        if (PlayerPrefs.GetInt("FootUnlocked") >= 2)
        {
            PlayerPrefs.SetInt("FootSelected", 3);
            PlayerPrefs.SetInt("HasChosenFoot", 1);
            PlayerPrefs.SetInt("FootNumSave", 2);

            ResetSelected();
            FootIcons[3].transform.GetChild(0).GetComponent<Image>().sprite = Selected[3]; // set selected, must be after ResetSelected()
        }
    }

    public void Brown()
    {
        if (PlayerPrefs.GetInt("FootUnlocked") >= 3)
        {
            PlayerPrefs.SetInt("FootSelected", 4);
            PlayerPrefs.SetInt("HasChosenFoot", 1);
            PlayerPrefs.SetInt("FootNumSave", 3);

            ResetSelected();
            FootIcons[4].transform.GetChild(0).GetComponent<Image>().sprite = Selected[4]; // set selected, must be after ResetSelected()
        }
    }

    public void WhiteSock()
    {
        if (PlayerPrefs.GetInt("FootUnlocked") >= 4)
        {
            PlayerPrefs.SetInt("FootSelected", 5);
            PlayerPrefs.SetInt("HasChosenFoot", 1);
            PlayerPrefs.SetInt("FootNumSave", 4);

            ResetSelected();
            FootIcons[5].transform.GetChild(0).GetComponent<Image>().sprite = Selected[5]; // set selected, must be after ResetSelected()
        }
    }

    public void Striped()
    {
        if (PlayerPrefs.GetInt("FootUnlocked") >= 5)
        {
            PlayerPrefs.SetInt("FootSelected", 6);
            PlayerPrefs.SetInt("HasChosenFoot", 1);
            PlayerPrefs.SetInt("FootNumSave", 5);

            ResetSelected();
            FootIcons[6].transform.GetChild(0).GetComponent<Image>().sprite = Selected[6]; // set selected, must be after ResetSelected()
        }
    }

    public void Robot()
    {
        if (PlayerPrefs.GetInt("FootUnlocked") >= 6)
        {
            PlayerPrefs.SetInt("FootSelected", 7);
            PlayerPrefs.SetInt("HasChosenFoot", 1);
            PlayerPrefs.SetInt("FootNumSave", 6);

            ResetSelected();
            FootIcons[7].transform.GetChild(0).GetComponent<Image>().sprite = Selected[7]; // set selected, must be after ResetSelected()
        }
    }

    public void AbSNow()
    {
        if (PlayerPrefs.GetInt("FootUnlocked") >= 7)
        {
            PlayerPrefs.SetInt("FootSelected", 8);
            PlayerPrefs.SetInt("HasChosenFoot", 1);
            PlayerPrefs.SetInt("FootNumSave", 7);

            ResetSelected();
            FootIcons[8].transform.GetChild(0).GetComponent<Image>().sprite = Selected[8]; // set selected, must be after ResetSelected()
        }
    }

    public void Demon()
    {
        if (PlayerPrefs.GetInt("FootUnlocked") >= 8)
        {
            PlayerPrefs.SetInt("FootSelected", 9);
            PlayerPrefs.SetInt("HasChosenFoot", 1);
            PlayerPrefs.SetInt("FootNumSave", 8);

            ResetSelected();
            FootIcons[9].transform.GetChild(0).GetComponent<Image>().sprite = Selected[9]; // set selected, must be after ResetSelected()
        }
    }

    public void Blue()
    {
        if (PlayerPrefs.GetInt("FootUnlocked") >= 9)
        {
            PlayerPrefs.SetInt("FootSelected", 10);
            PlayerPrefs.SetInt("HasChosenFoot", 1);
            PlayerPrefs.SetInt("FootNumSave", 9);

            ResetSelected();
            FootIcons[10].transform.GetChild(0).GetComponent<Image>().sprite = Selected[10]; // set selected, must be after ResetSelected()
        }
    }

    public void ResetSelected()
    {
        for (int i = 0; i < NumFeet; i++)
        {
            if (i != 0) // 0 is MostRecent, which is handled below without the "getchild" as per the hierarchy
                FootIcons[i].transform.GetChild(0).GetComponent<Image>().sprite = Default[i];
        }
        MostRecent.GetComponent<Image>().sprite = Default[0];
    }

    private void Update()
    {
        GameManager.Instance.FootNum = PlayerPrefs.GetInt("FootNumSave"); 

        for (int i = 0; i < PlayerPrefs.GetInt("FootUnlocked") + 1; i++)
        {
            if (i > 9) // out of array
            {
               
            }
            else // in array
            {
                Locks[i].SetActive(false);
            }
        }
    }

}
