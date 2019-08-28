using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalSelectorMenu : MonoBehaviour {

    public GameObject[] Locks;

    public GameObject[] BallIcons; // includes Ball_LevelBased in slot "0" (NumBalls +1)
    public GameObject LevelBall;
    public Sprite Default;
    public Sprite Selected;

    public int NumBalls = 42; // number of balls, not value in array (which is 1 less than this number)

    //All Buttons below asigned to animal select buttons "Buttons3" on main menu These change the number in the
    //Game manger which in turn selects a number for an array of sprite to choose.

    void Start()
    {
        ResetSelected();
        BallIcons[PlayerPrefs.GetInt("BallSelected")].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
    }

    public void Ball()
    {
        PlayerPrefs.SetInt("BallSelected", 1);
        PlayerPrefs.SetInt("HasChosenSprite", 1);
        PlayerPrefs.SetInt("AnimalNumSave", 0);

        ResetSelected();
        BallIcons[1].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
    }

    public void Dog()
    {
        if(PlayerPrefs.GetInt("AnimalsUnlocked") >= 1)
        {
            PlayerPrefs.SetInt("BallSelected", 2);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 1);

            ResetSelected();
            BallIcons[2].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Cat()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 2)
        {
            PlayerPrefs.SetInt("BallSelected", 3);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 2);

            ResetSelected();
            BallIcons[3].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }
 
    public void Fox()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 3)
        {
            PlayerPrefs.SetInt("BallSelected", 4);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 3);

            ResetSelected();
            BallIcons[4].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Racoon()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 4)
        {
            PlayerPrefs.SetInt("BallSelected", 5);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 4);

            ResetSelected();
            BallIcons[5].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Squirrel()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 5)
        {
            PlayerPrefs.SetInt("BallSelected", 6);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 5);

            ResetSelected();
            BallIcons[6].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Owl()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 6)
        {
            PlayerPrefs.SetInt("BallSelected", 7);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 6);

            ResetSelected();
            BallIcons[7].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void ReinDeer()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 7)
        {
            PlayerPrefs.SetInt("BallSelected", 8);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 7);

            ResetSelected();
            BallIcons[8].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Rabbit()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 8)
        {
            PlayerPrefs.SetInt("BallSelected", 9);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 8);

            ResetSelected();
            BallIcons[9].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Frog()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 9)
        {
            PlayerPrefs.SetInt("BallSelected", 10);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 9);

            ResetSelected();
            BallIcons[10].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void YOwl()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 10)
        {
            PlayerPrefs.SetInt("BallSelected", 11);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 10);

            ResetSelected();
            BallIcons[11].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Turtle()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 11)
        {
            PlayerPrefs.SetInt("BallSelected", 12);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 11);

            ResetSelected();
            BallIcons[12].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Goat()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 12)
        {
            PlayerPrefs.SetInt("BallSelected", 13);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 12);

            ResetSelected();
            BallIcons[13].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void BBird()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 13)
        {
            PlayerPrefs.SetInt("BallSelected", 14);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 13);

            ResetSelected();
            BallIcons[14].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Donkey()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 14)
        {
            PlayerPrefs.SetInt("BallSelected", 15);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 14);

            ResetSelected();
            BallIcons[15].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Chicken()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 15)
        {
            PlayerPrefs.SetInt("BallSelected", 16);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 15);

            ResetSelected();
            BallIcons[16].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Sheep()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 16)
        {
            PlayerPrefs.SetInt("BallSelected", 17);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 16);

            ResetSelected();
            BallIcons[17].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Horse()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 17)
        {
            PlayerPrefs.SetInt("BallSelected", 18);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 17);

            ResetSelected();
            BallIcons[18].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Pig()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 18)
        {
            PlayerPrefs.SetInt("BallSelected", 19);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 18);

            ResetSelected();
            BallIcons[19].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Cow()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 19)
        {
            PlayerPrefs.SetInt("BallSelected", 20);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 19);

            ResetSelected();
            BallIcons[20].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Pbear()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 20)
        {
            PlayerPrefs.SetInt("BallSelected", 21);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 20);

            ResetSelected();
            BallIcons[21].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Husky()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 21)
        {
            PlayerPrefs.SetInt("BallSelected", 22);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 21);

            ResetSelected();
            BallIcons[22].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Seal()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 22)
        {
            PlayerPrefs.SetInt("BallSelected", 23);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 22);

            ResetSelected();
            BallIcons[23].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Penguin()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 23)
        {
            PlayerPrefs.SetInt("BallSelected", 24);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 23);

            ResetSelected();
            BallIcons[24].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Octo()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 24)
        {
            PlayerPrefs.SetInt("BallSelected", 25);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 24);

            ResetSelected();
            BallIcons[25].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Shark()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 25)
        {
            PlayerPrefs.SetInt("BallSelected", 26);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 25);

            ResetSelected();
            BallIcons[26].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void SeaHorse()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 26)
        {
            PlayerPrefs.SetInt("BallSelected", 27);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 26);

            ResetSelected();
            BallIcons[27].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Dolphin()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 27)
        {
            PlayerPrefs.SetInt("BallSelected", 28);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 27);

            ResetSelected();
            BallIcons[28].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Zebra()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 28)
        {
            PlayerPrefs.SetInt("BallSelected", 29);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 28);

            ResetSelected();
            BallIcons[29].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Monkey()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 29)
        {
            PlayerPrefs.SetInt("BallSelected", 30);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 29);

            ResetSelected();
            BallIcons[30].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Panda()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 30)
        {
            PlayerPrefs.SetInt("BallSelected", 31);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 30);

            ResetSelected();
            BallIcons[31].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Giraf()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 31)
        {
            PlayerPrefs.SetInt("BallSelected", 32);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 31);

            ResetSelected();
            BallIcons[32].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Koala()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 32)
        {
            PlayerPrefs.SetInt("BallSelected", 33);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 32);

            ResetSelected();
            BallIcons[33].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Tiger()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 33)
        {
            PlayerPrefs.SetInt("BallSelected", 34);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 33);

            ResetSelected();
            BallIcons[34].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Hippo()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 34)
        {
            PlayerPrefs.SetInt("BallSelected", 35);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 34);

            ResetSelected();
            BallIcons[35].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void lion()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 35)
        {
            PlayerPrefs.SetInt("BallSelected", 36);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 35);

            ResetSelected();
            BallIcons[36].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Santa()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 36)
        {
            PlayerPrefs.SetInt("BallSelected", 37);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 36);

            ResetSelected();
            BallIcons[37].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Dragon()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 37)
        {
            PlayerPrefs.SetInt("BallSelected", 38);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 37);

            ResetSelected();
            BallIcons[38].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Yetti()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 38)
        {
            PlayerPrefs.SetInt("BallSelected", 39);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 38);

            ResetSelected();
            BallIcons[39].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Alien()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 39)
        {
            PlayerPrefs.SetInt("BallSelected", 40);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 39);

            ResetSelected();
            BallIcons[40].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void YpwBird()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 40)
        {
            PlayerPrefs.SetInt("BallSelected", 41);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 40);

            ResetSelected();
            BallIcons[41].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    public void Elvis()
    {
        if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 41)
        {
            PlayerPrefs.SetInt("BallSelected", 42);
            PlayerPrefs.SetInt("HasChosenSprite", 1);
            PlayerPrefs.SetInt("AnimalNumSave", 41);

            ResetSelected();
            BallIcons[42].GetComponent<Image>().sprite = Selected; // set selected, must be after ResetSelected()
        }
    }

    //public void Unicorn()
    //{
    //    if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 42)
    //    {
    //        PlayerPrefs.SetInt("HasChosenSprite", 1);
    //        PlayerPrefs.SetInt("AnimalNumSave", 42);
    //    }
    //}

    //public void Pheonix()
    //{
    //    if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 43)
    //    {
    //        PlayerPrefs.SetInt("HasChosenSprite", 1);
    //        PlayerPrefs.SetInt("AnimalNumSave", 43);
    //    }
    //}

    //public void Hulkster()
    //{
    //    if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 44)
    //    {
    //        PlayerPrefs.SetInt("HasChosenSprite", 1);
    //        PlayerPrefs.SetInt("AnimalNumSave", 44);
    //    }
    //}

    //public void PgWBird()
    //{
    //    if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 45)
    //    {
    //        PlayerPrefs.SetInt("HasChosenSprite", 1);
    //        PlayerPrefs.SetInt("AnimalNumSave", 45);
    //    }
    //}

    //public void Luckycharms()
    //{
    //    if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 46)
    //    {
    //        PlayerPrefs.SetInt("HasChosenSprite", 1);
    //        PlayerPrefs.SetInt("AnimalNumSave", 46);
    //    }
    //}

    //public void UsaGuy()
    //{
    //    if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 47)
    //    {
    //        PlayerPrefs.SetInt("HasChosenSprite", 1);
    //        PlayerPrefs.SetInt("AnimalNumSave", 47);
    //    }
    //}

    //public void WebMan()
    //{
    //    if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 48)
    //    {
    //        PlayerPrefs.SetInt("HasChosenSprite", 1);
    //        PlayerPrefs.SetInt("AnimalNumSave", 48);
    //    }
    //}

    //public void Fastguy()
    //{
    //    if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 49)
    //    {
    //        PlayerPrefs.SetInt("HasChosenSprite", 1);
    //        PlayerPrefs.SetInt("AnimalNumSave", 49);
    //    }
    //}

    //public void Darkman()
    //{
    //    if (PlayerPrefs.GetInt("AnimalsUnlocked") >= 50)
    //    {
    //        PlayerPrefs.SetInt("HasChosenSprite", 1);
    //        PlayerPrefs.SetInt("AnimalNumSave", 50);
    //    }
    //}

    public void ResetSelected()
    {
        for (int i = 0; i < NumBalls; i++)
        {
            BallIcons[i].GetComponent<Image>().sprite = Default;
        }
        LevelBall.GetComponent<Image>().sprite = Default;
    }

    public void Update()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("AnimalsUnlocked")+1; i++)
        {
            Locks[i].SetActive(false);

            if (i > 50) // out of array
            {

            }
            else  // in array
            {
                Locks[i].SetActive(false);
            }

        }
    }
}
