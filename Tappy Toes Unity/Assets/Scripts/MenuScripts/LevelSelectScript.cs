using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour {

    public GameObject[] Locks;

    // all functions below are attached to buttons6 for level selection, if the level is unlocked load level.
	public void LoadLevel1()
    {
        GameManager.Instance.ActiveLevel = 1;
        PlayerPrefs.SetInt("ActiveLevel", GameManager.Instance.ActiveLevel);
        SceneManager.LoadScene("Level1");

        // Set FOOT SKIN
        if (PlayerPrefs.GetInt("HasChosenFoot") == 0)
        {
            // set Foot sprite
            GameManager.Instance.FootNum = PlayerPrefs.GetInt("FootUnlocked");
            PlayerPrefs.SetInt("FootNum", GameManager.Instance.FootNum);
            PlayerPrefs.SetInt("FootNumSave", GameManager.Instance.FootNum);
        }

        // Set SHOE SKIN
        if (PlayerPrefs.GetInt("HasChosenShoe") == 0)
        {
            // set Shoe sprite
            GameManager.Instance.ShoeNum = PlayerPrefs.GetInt("ShoeUnlocked");
            PlayerPrefs.SetInt("ShoeNum", GameManager.Instance.ShoeNum);
            PlayerPrefs.SetInt("ShoeNumSave", GameManager.Instance.ShoeNum);
        }
    }

    public void LoadLevel2() 
    {
        if(PlayerPrefs.GetInt("LevelUnlocked") >= 2)
        {
            GameManager.Instance.ActiveLevel = 2;
            PlayerPrefs.SetInt("ActiveLevel", GameManager.Instance.ActiveLevel);

            // Set BALL SKIN
            if (PlayerPrefs.GetInt("HasChosenSprite") == 0)
            {
                // set ball sprite
                GameManager.Instance.AnimalNum = PlayerPrefs.GetInt("ActiveLevel") - 1;
                PlayerPrefs.SetInt("AnimalNum", GameManager.Instance.AnimalNum);
            }

            // Set FOOT SKIN
            if (PlayerPrefs.GetInt("HasChosenFoot") == 0)
            {
                // set Foot sprite
                GameManager.Instance.FootNum = PlayerPrefs.GetInt("FootUnlocked");
                PlayerPrefs.SetInt("FootNum", GameManager.Instance.FootNum);
                PlayerPrefs.SetInt("FootNumSave", GameManager.Instance.FootNum);
            }

            // Set SHOE SKIN
            if (PlayerPrefs.GetInt("HasChosenShoe") == 0)
            {
                // set Shoe sprite
                GameManager.Instance.ShoeNum = PlayerPrefs.GetInt("ShoeUnlocked");
                PlayerPrefs.SetInt("ShoeNum", GameManager.Instance.ShoeNum);
                PlayerPrefs.SetInt("ShoeNumSave", GameManager.Instance.ShoeNum);
            }

            SceneManager.LoadScene("Level2");
        }
    }

    public void LoadLevel3()
    {
        if (PlayerPrefs.GetInt("LevelUnlocked") >= 3)
        {
            GameManager.Instance.ActiveLevel = 3;
            PlayerPrefs.SetInt("ActiveLevel", GameManager.Instance.ActiveLevel);

            // Set BALL SKIN
            if (PlayerPrefs.GetInt("HasChosenSprite") == 0)
            {
                // set ball sprite
                GameManager.Instance.AnimalNum = PlayerPrefs.GetInt("ActiveLevel") - 1;
                PlayerPrefs.SetInt("AnimalNum", GameManager.Instance.AnimalNum);
            }

            // Set FOOT SKIN
            if (PlayerPrefs.GetInt("HasChosenFoot") == 0)
            {
                // set Foot sprite
                GameManager.Instance.FootNum = PlayerPrefs.GetInt("FootUnlocked");
                PlayerPrefs.SetInt("FootNum", GameManager.Instance.FootNum);
                PlayerPrefs.SetInt("FootNumSave", GameManager.Instance.FootNum);
            }

            // Set SHOE SKIN
            if (PlayerPrefs.GetInt("HasChosenShoe") == 0)
            {
                // set Shoe sprite
                GameManager.Instance.ShoeNum = PlayerPrefs.GetInt("ShoeUnlocked");
                PlayerPrefs.SetInt("ShoeNum", GameManager.Instance.ShoeNum);
                PlayerPrefs.SetInt("ShoeNumSave", GameManager.Instance.ShoeNum);
            }

            SceneManager.LoadScene("Level3");
        }
    }

    public void LoadLevel4()
    {
        if (PlayerPrefs.GetInt("LevelUnlocked") >= 4)
        {
            GameManager.Instance.ActiveLevel = 4;
            PlayerPrefs.SetInt("ActiveLevel", GameManager.Instance.ActiveLevel);

            // Set BALL SKIN
            if (PlayerPrefs.GetInt("HasChosenSprite") == 0)
            {
                // set ball sprite
                GameManager.Instance.AnimalNum = PlayerPrefs.GetInt("ActiveLevel") - 1;
                PlayerPrefs.SetInt("AnimalNum", GameManager.Instance.AnimalNum);
            }

            // Set FOOT SKIN
            if (PlayerPrefs.GetInt("HasChosenFoot") == 0)
            {
                // set Foot sprite
                GameManager.Instance.FootNum = PlayerPrefs.GetInt("FootUnlocked");
                PlayerPrefs.SetInt("FootNum", GameManager.Instance.FootNum);
                PlayerPrefs.SetInt("FootNumSave", GameManager.Instance.FootNum);
            }

            // Set SHOE SKIN
            if (PlayerPrefs.GetInt("HasChosenShoe") == 0)
            {
                // set Shoe sprite
                GameManager.Instance.ShoeNum = PlayerPrefs.GetInt("ShoeUnlocked");
                PlayerPrefs.SetInt("ShoeNum", GameManager.Instance.ShoeNum);
                PlayerPrefs.SetInt("ShoeNumSave", GameManager.Instance.ShoeNum);
            }

            SceneManager.LoadScene("Level4");
        }
    }

    public void LoadLevel5()
    {
        if (PlayerPrefs.GetInt("LevelUnlocked") >= 5)
        {
            GameManager.Instance.ActiveLevel = 5;
            PlayerPrefs.SetInt("ActiveLevel", GameManager.Instance.ActiveLevel);

            // Set BALL SKIN
            if (PlayerPrefs.GetInt("HasChosenSprite") == 0)
            {
                // set ball sprite
                GameManager.Instance.AnimalNum = PlayerPrefs.GetInt("ActiveLevel") - 1;
                PlayerPrefs.SetInt("AnimalNum", GameManager.Instance.AnimalNum);
            }

            // Set FOOT SKIN
            if (PlayerPrefs.GetInt("HasChosenFoot") == 0)
            {
                // set Foot sprite
                GameManager.Instance.FootNum = PlayerPrefs.GetInt("FootUnlocked");
                PlayerPrefs.SetInt("FootNum", GameManager.Instance.FootNum);
                PlayerPrefs.SetInt("FootNumSave", GameManager.Instance.FootNum);
            }

            // Set SHOE SKIN
            if (PlayerPrefs.GetInt("HasChosenShoe") == 0)
            {
                // set Shoe sprite
                GameManager.Instance.ShoeNum = PlayerPrefs.GetInt("ShoeUnlocked");
                PlayerPrefs.SetInt("ShoeNum", GameManager.Instance.ShoeNum);
                PlayerPrefs.SetInt("ShoeNumSave", GameManager.Instance.ShoeNum);
            }

            SceneManager.LoadScene("Level5");
        }
    }

    public void LoadLevel6()
    {
        if (PlayerPrefs.GetInt("LevelUnlocked") >= 6)
        {
            GameManager.Instance.ActiveLevel = 6;
            PlayerPrefs.SetInt("ActiveLevel", GameManager.Instance.ActiveLevel);

            // Set BALL SKIN
            if (PlayerPrefs.GetInt("HasChosenSprite") == 0)
            {
                // set ball sprite
                GameManager.Instance.AnimalNum = PlayerPrefs.GetInt("ActiveLevel") - 1;
                PlayerPrefs.SetInt("AnimalNum", GameManager.Instance.AnimalNum);
            }

            // Set FOOT SKIN
            if (PlayerPrefs.GetInt("HasChosenFoot") == 0)
            {
                // set Foot sprite
                GameManager.Instance.FootNum = PlayerPrefs.GetInt("FootUnlocked");
                PlayerPrefs.SetInt("FootNum", GameManager.Instance.FootNum);
                PlayerPrefs.SetInt("FootNumSave", GameManager.Instance.FootNum);
            }

            // Set SHOE SKIN
            if (PlayerPrefs.GetInt("HasChosenShoe") == 0)
            {
                // set Shoe sprite
                GameManager.Instance.ShoeNum = PlayerPrefs.GetInt("ShoeUnlocked");
                PlayerPrefs.SetInt("ShoeNum", GameManager.Instance.ShoeNum);
                PlayerPrefs.SetInt("ShoeNumSave", GameManager.Instance.ShoeNum);
            }

            SceneManager.LoadScene("Level6");
        }
    }

    public void LoadLevel7()
    {
        if (PlayerPrefs.GetInt("LevelUnlocked") >= 7)
        {
            GameManager.Instance.ActiveLevel = 7;
            PlayerPrefs.SetInt("ActiveLevel", GameManager.Instance.ActiveLevel);

            // Set BALL SKIN
            if (PlayerPrefs.GetInt("HasChosenSprite") == 0)
            {
                // set ball sprite
                GameManager.Instance.AnimalNum = PlayerPrefs.GetInt("ActiveLevel") - 1;
                PlayerPrefs.SetInt("AnimalNum", GameManager.Instance.AnimalNum);
            }

            // Set FOOT SKIN
            if (PlayerPrefs.GetInt("HasChosenFoot") == 0)
            {
                // set Foot sprite
                GameManager.Instance.FootNum = PlayerPrefs.GetInt("FootUnlocked");
                PlayerPrefs.SetInt("FootNum", GameManager.Instance.FootNum);
                PlayerPrefs.SetInt("FootNumSave", GameManager.Instance.FootNum);
            }

            // Set SHOE SKIN
            if (PlayerPrefs.GetInt("HasChosenShoe") == 0)
            {
                // set Shoe sprite
                GameManager.Instance.ShoeNum = PlayerPrefs.GetInt("ShoeUnlocked");
                PlayerPrefs.SetInt("ShoeNum", GameManager.Instance.ShoeNum);
                PlayerPrefs.SetInt("ShoeNumSave", GameManager.Instance.ShoeNum);
            }

            SceneManager.LoadScene("Level7");
        }
    }

    public void LoadLevel8()
    {
        if (PlayerPrefs.GetInt("LevelUnlocked") >= 8)
        {
            GameManager.Instance.ActiveLevel = 8;
            PlayerPrefs.SetInt("ActiveLevel", GameManager.Instance.ActiveLevel);

            // Set BALL SKIN
            if (PlayerPrefs.GetInt("HasChosenSprite") == 0)
            {
                // set ball sprite
                GameManager.Instance.AnimalNum = PlayerPrefs.GetInt("ActiveLevel") - 1;
                PlayerPrefs.SetInt("AnimalNum", GameManager.Instance.AnimalNum);
            }

            // Set FOOT SKIN
            if (PlayerPrefs.GetInt("HasChosenFoot") == 0)
            {
                // set Foot sprite
                GameManager.Instance.FootNum = PlayerPrefs.GetInt("FootUnlocked");
                PlayerPrefs.SetInt("FootNum", GameManager.Instance.FootNum);
                PlayerPrefs.SetInt("FootNumSave", GameManager.Instance.FootNum);
            }

            // Set SHOE SKIN
            if (PlayerPrefs.GetInt("HasChosenShoe") == 0)
            {
                // set Shoe sprite
                GameManager.Instance.ShoeNum = PlayerPrefs.GetInt("ShoeUnlocked");
                PlayerPrefs.SetInt("ShoeNum", GameManager.Instance.ShoeNum);
                PlayerPrefs.SetInt("ShoeNumSave", GameManager.Instance.ShoeNum);
            }

            SceneManager.LoadScene("Level8");
        }
    }

    public void LoadLevel9()
    {
        if (PlayerPrefs.GetInt("LevelUnlocked") >= 9)
        {
            GameManager.Instance.ActiveLevel = 9;
            PlayerPrefs.SetInt("ActiveLevel", GameManager.Instance.ActiveLevel);

            // Set BALL SKIN
            if (PlayerPrefs.GetInt("HasChosenSprite") == 0)
            {
                // set ball sprite
                GameManager.Instance.AnimalNum = PlayerPrefs.GetInt("ActiveLevel") - 1;
                PlayerPrefs.SetInt("AnimalNum", GameManager.Instance.AnimalNum);
            }

            // Set FOOT SKIN
            if (PlayerPrefs.GetInt("HasChosenFoot") == 0)
            {
                // set Foot sprite
                GameManager.Instance.FootNum = PlayerPrefs.GetInt("FootUnlocked");
                PlayerPrefs.SetInt("FootNum", GameManager.Instance.FootNum);
                PlayerPrefs.SetInt("FootNumSave", GameManager.Instance.FootNum);
            }

            // Set SHOE SKIN
            if (PlayerPrefs.GetInt("HasChosenShoe") == 0)
            {
                // set Shoe sprite
                GameManager.Instance.ShoeNum = PlayerPrefs.GetInt("ShoeUnlocked");
                PlayerPrefs.SetInt("ShoeNum", GameManager.Instance.ShoeNum);
                PlayerPrefs.SetInt("ShoeNumSave", GameManager.Instance.ShoeNum);
            }

            SceneManager.LoadScene("Level9");
        }
    }

    public void LoadLevel10()
    {
        if (PlayerPrefs.GetInt("LevelUnlocked") >= 10)
        {
            GameManager.Instance.ActiveLevel = 10;
            PlayerPrefs.SetInt("ActiveLevel", GameManager.Instance.ActiveLevel);

            // Set BALL SKIN
            if (PlayerPrefs.GetInt("HasChosenSprite") == 0)
            {
                // set ball sprite
                GameManager.Instance.AnimalNum = PlayerPrefs.GetInt("ActiveLevel") - 1;
                PlayerPrefs.SetInt("AnimalNum", GameManager.Instance.AnimalNum);
            }

            // Set FOOT SKIN
            if (PlayerPrefs.GetInt("HasChosenFoot") == 0)
            {
                // set Foot sprite
                GameManager.Instance.FootNum = PlayerPrefs.GetInt("FootUnlocked");
                PlayerPrefs.SetInt("FootNum", GameManager.Instance.FootNum);
                PlayerPrefs.SetInt("FootNumSave", GameManager.Instance.FootNum);
            }

            // Set SHOE SKIN
            if (PlayerPrefs.GetInt("HasChosenShoe") == 0)
            {
                // set Shoe sprite
                GameManager.Instance.ShoeNum = PlayerPrefs.GetInt("ShoeUnlocked");
                PlayerPrefs.SetInt("ShoeNum", GameManager.Instance.ShoeNum);
                PlayerPrefs.SetInt("ShoeNumSave", GameManager.Instance.ShoeNum);
            }

            SceneManager.LoadScene("Level10");
        }
    }

    public void LoadLevel11()
    {
        if (PlayerPrefs.GetInt("LevelUnlocked") >= 11)
        {
            GameManager.Instance.ActiveLevel = 11;
            PlayerPrefs.SetInt("ActiveLevel", GameManager.Instance.ActiveLevel);

            // Set BALL SKIN
            if (PlayerPrefs.GetInt("HasChosenSprite") == 0)
            {
                // set ball sprite
                GameManager.Instance.AnimalNum = PlayerPrefs.GetInt("ActiveLevel") - 1;
                PlayerPrefs.SetInt("AnimalNum", GameManager.Instance.AnimalNum);
            }

            // Set FOOT SKIN
            if (PlayerPrefs.GetInt("HasChosenFoot") == 0)
            {
                // set Foot sprite
                GameManager.Instance.FootNum = PlayerPrefs.GetInt("FootUnlocked");
                PlayerPrefs.SetInt("FootNum", GameManager.Instance.FootNum);
                PlayerPrefs.SetInt("FootNumSave", GameManager.Instance.FootNum);
            }

            // Set SHOE SKIN
            if (PlayerPrefs.GetInt("HasChosenShoe") == 0)
            {
                // set Shoe sprite
                GameManager.Instance.ShoeNum = PlayerPrefs.GetInt("ShoeUnlocked");
                PlayerPrefs.SetInt("ShoeNum", GameManager.Instance.ShoeNum);
                PlayerPrefs.SetInt("ShoeNumSave", GameManager.Instance.ShoeNum);
            }

            SceneManager.LoadScene("Level11");
        }
    }

    public void LoadLevel12()
    {
        if (PlayerPrefs.GetInt("LevelUnlocked") >= 12)
        {
            GameManager.Instance.ActiveLevel = 12;
            PlayerPrefs.SetInt("ActiveLevel", GameManager.Instance.ActiveLevel);

            // Set BALL SKIN
            if (PlayerPrefs.GetInt("HasChosenSprite") == 0)
            {
                // set ball sprite
                GameManager.Instance.AnimalNum = PlayerPrefs.GetInt("ActiveLevel") - 1;
                PlayerPrefs.SetInt("AnimalNum", GameManager.Instance.AnimalNum);
            }

            // Set FOOT SKIN
            if (PlayerPrefs.GetInt("HasChosenFoot") == 0)
            {
                // set Foot sprite
                GameManager.Instance.FootNum = PlayerPrefs.GetInt("FootUnlocked");
                PlayerPrefs.SetInt("FootNum", GameManager.Instance.FootNum);
                PlayerPrefs.SetInt("FootNumSave", GameManager.Instance.FootNum);
            }

            // Set SHOE SKIN
            if (PlayerPrefs.GetInt("HasChosenShoe") == 0)
            {
                // set Shoe sprite
                GameManager.Instance.ShoeNum = PlayerPrefs.GetInt("ShoeUnlocked");
                PlayerPrefs.SetInt("ShoeNum", GameManager.Instance.ShoeNum);
                PlayerPrefs.SetInt("ShoeNumSave", GameManager.Instance.ShoeNum);
            }

            SceneManager.LoadScene("Level12");
        }
    }

    public void LoadLevel13()
    {
        if (PlayerPrefs.GetInt("LevelUnlocked") >= 13)
        {
            GameManager.Instance.ActiveLevel = 13;
            PlayerPrefs.SetInt("ActiveLevel", GameManager.Instance.ActiveLevel);

            // Set BALL SKIN
            if (PlayerPrefs.GetInt("HasChosenSprite") == 0)
            {
                // set ball sprite
                GameManager.Instance.AnimalNum = PlayerPrefs.GetInt("ActiveLevel") - 1;
                PlayerPrefs.SetInt("AnimalNum", GameManager.Instance.AnimalNum);
            }

            // Set FOOT SKIN
            if (PlayerPrefs.GetInt("HasChosenFoot") == 0)
            {
                // set Foot sprite
                GameManager.Instance.FootNum = PlayerPrefs.GetInt("FootUnlocked");
                PlayerPrefs.SetInt("FootNum", GameManager.Instance.FootNum);
                PlayerPrefs.SetInt("FootNumSave", GameManager.Instance.FootNum);
            }

            // Set SHOE SKIN
            if (PlayerPrefs.GetInt("HasChosenShoe") == 0)
            {
                // set Shoe sprite
                GameManager.Instance.ShoeNum = PlayerPrefs.GetInt("ShoeUnlocked");
                PlayerPrefs.SetInt("ShoeNum", GameManager.Instance.ShoeNum);
                PlayerPrefs.SetInt("ShoeNumSave", GameManager.Instance.ShoeNum);
            }

            SceneManager.LoadScene("Level13");
        }
    }

    public void LoadLevel14()
    {
        if (PlayerPrefs.GetInt("LevelUnlocked") >= 14)
        {
            GameManager.Instance.ActiveLevel = 14;
            PlayerPrefs.SetInt("ActiveLevel", GameManager.Instance.ActiveLevel);

            // Set BALL SKIN
            if (PlayerPrefs.GetInt("HasChosenSprite") == 0)
            {
                // set ball sprite
                GameManager.Instance.AnimalNum = PlayerPrefs.GetInt("ActiveLevel") - 1;
                PlayerPrefs.SetInt("AnimalNum", GameManager.Instance.AnimalNum);
            }

            // Set FOOT SKIN
            if (PlayerPrefs.GetInt("HasChosenFoot") == 0)
            {
                // set Foot sprite
                GameManager.Instance.FootNum = PlayerPrefs.GetInt("FootUnlocked");
                PlayerPrefs.SetInt("FootNum", GameManager.Instance.FootNum);
                PlayerPrefs.SetInt("FootNumSave", GameManager.Instance.FootNum);
            }

            // Set SHOE SKIN
            if (PlayerPrefs.GetInt("HasChosenShoe") == 0)
            {
                // set Shoe sprite
                GameManager.Instance.ShoeNum = PlayerPrefs.GetInt("ShoeUnlocked");
                PlayerPrefs.SetInt("ShoeNum", GameManager.Instance.ShoeNum);
                PlayerPrefs.SetInt("ShoeNumSave", GameManager.Instance.ShoeNum);
            }

            SceneManager.LoadScene("Level14");
        }
    }

    public void LoadLevel15()
    {
        if (PlayerPrefs.GetInt("LevelUnlocked") >= 15)
        {
            GameManager.Instance.ActiveLevel = 15;
            PlayerPrefs.SetInt("ActiveLevel", GameManager.Instance.ActiveLevel);

            // Set BALL SKIN
            if (PlayerPrefs.GetInt("HasChosenSprite") == 0)
            {
                // set ball sprite
                GameManager.Instance.AnimalNum = PlayerPrefs.GetInt("ActiveLevel") - 1;
                PlayerPrefs.SetInt("AnimalNum", GameManager.Instance.AnimalNum);
            }

            // Set FOOT SKIN
            if (PlayerPrefs.GetInt("HasChosenFoot") == 0)
            {
                // set Foot sprite
                GameManager.Instance.FootNum = PlayerPrefs.GetInt("FootUnlocked");
                PlayerPrefs.SetInt("FootNum", GameManager.Instance.FootNum);
                PlayerPrefs.SetInt("FootNumSave", GameManager.Instance.FootNum);
            }

            // Set SHOE SKIN
            if (PlayerPrefs.GetInt("HasChosenShoe") == 0)
            {
                // set Shoe sprite
                GameManager.Instance.ShoeNum = PlayerPrefs.GetInt("ShoeUnlocked");
                PlayerPrefs.SetInt("ShoeNum", GameManager.Instance.ShoeNum);
                PlayerPrefs.SetInt("ShoeNumSave", GameManager.Instance.ShoeNum);
            }

            SceneManager.LoadScene("Level15");
        }
    }

    public void LoadLevel16()
    {
        if (PlayerPrefs.GetInt("LevelUnlocked") >= 16)
        {
            GameManager.Instance.ActiveLevel = 16;
            PlayerPrefs.SetInt("ActiveLevel", GameManager.Instance.ActiveLevel);

            // Set BALL SKIN
            if (PlayerPrefs.GetInt("HasChosenSprite") == 0)
            {
                // set ball sprite
                GameManager.Instance.AnimalNum = PlayerPrefs.GetInt("ActiveLevel") - 1;
                PlayerPrefs.SetInt("AnimalNum", GameManager.Instance.AnimalNum);
            }

            // Set FOOT SKIN
            if (PlayerPrefs.GetInt("HasChosenFoot") == 0)
            {
                // set Foot sprite
                GameManager.Instance.FootNum = PlayerPrefs.GetInt("FootUnlocked");
                PlayerPrefs.SetInt("FootNum", GameManager.Instance.FootNum);
                PlayerPrefs.SetInt("FootNumSave", GameManager.Instance.FootNum);
            }

            // Set SHOE SKIN
            if (PlayerPrefs.GetInt("HasChosenShoe") == 0)
            {
                // set Shoe sprite
                GameManager.Instance.ShoeNum = PlayerPrefs.GetInt("ShoeUnlocked");
                PlayerPrefs.SetInt("ShoeNum", GameManager.Instance.ShoeNum);
                PlayerPrefs.SetInt("ShoeNumSave", GameManager.Instance.ShoeNum);
            }

            SceneManager.LoadScene("Level16");
        }
    }

    public void LoadLevel17()
    {
        if (PlayerPrefs.GetInt("LevelUnlocked") >= 17)
        {
            GameManager.Instance.ActiveLevel = 17;
            PlayerPrefs.SetInt("ActiveLevel", GameManager.Instance.ActiveLevel);

            // Set BALL SKIN
            if (PlayerPrefs.GetInt("HasChosenSprite") == 0)
            {
                // set ball sprite
                GameManager.Instance.AnimalNum = PlayerPrefs.GetInt("ActiveLevel") - 1;
                PlayerPrefs.SetInt("AnimalNum", GameManager.Instance.AnimalNum);
            }

            // Set FOOT SKIN
            if (PlayerPrefs.GetInt("HasChosenFoot") == 0)
            {
                // set Foot sprite
                GameManager.Instance.FootNum = PlayerPrefs.GetInt("FootUnlocked");
                PlayerPrefs.SetInt("FootNum", GameManager.Instance.FootNum);
                PlayerPrefs.SetInt("FootNumSave", GameManager.Instance.FootNum);
            }

            // Set SHOE SKIN
            if (PlayerPrefs.GetInt("HasChosenShoe") == 0)
            {
                // set Shoe sprite
                GameManager.Instance.ShoeNum = PlayerPrefs.GetInt("ShoeUnlocked");
                PlayerPrefs.SetInt("ShoeNum", GameManager.Instance.ShoeNum);
                PlayerPrefs.SetInt("ShoeNumSave", GameManager.Instance.ShoeNum);
            }

            SceneManager.LoadScene("Level17");
        }
    }

    public void LoadLevel18()
    {
        if (PlayerPrefs.GetInt("LevelUnlocked") >= 18)
        {
            GameManager.Instance.ActiveLevel = 18;
            PlayerPrefs.SetInt("ActiveLevel", GameManager.Instance.ActiveLevel);

            // Set BALL SKIN
            if (PlayerPrefs.GetInt("HasChosenSprite") == 0)
            {
                // set ball sprite
                GameManager.Instance.AnimalNum = PlayerPrefs.GetInt("ActiveLevel") - 1;
                PlayerPrefs.SetInt("AnimalNum", GameManager.Instance.AnimalNum);
            }

            // Set FOOT SKIN
            if (PlayerPrefs.GetInt("HasChosenFoot") == 0)
            {
                // set Foot sprite
                GameManager.Instance.FootNum = PlayerPrefs.GetInt("FootUnlocked");
                PlayerPrefs.SetInt("FootNum", GameManager.Instance.FootNum);
                PlayerPrefs.SetInt("FootNumSave", GameManager.Instance.FootNum);
            }

            // Set SHOE SKIN
            if (PlayerPrefs.GetInt("HasChosenShoe") == 0)
            {
                // set Shoe sprite
                GameManager.Instance.ShoeNum = PlayerPrefs.GetInt("ShoeUnlocked");
                PlayerPrefs.SetInt("ShoeNum", GameManager.Instance.ShoeNum);
                PlayerPrefs.SetInt("ShoeNumSave", GameManager.Instance.ShoeNum);
            }

            SceneManager.LoadScene("Level18");
        }
    }

    public void LoadLevel19()
    {
        if (PlayerPrefs.GetInt("LevelUnlocked") >= 19)
        {
            GameManager.Instance.ActiveLevel = 19;
            PlayerPrefs.SetInt("ActiveLevel", GameManager.Instance.ActiveLevel);

            // Set BALL SKIN
            if (PlayerPrefs.GetInt("HasChosenSprite") == 0)
            {
                // set ball sprite
                GameManager.Instance.AnimalNum = PlayerPrefs.GetInt("ActiveLevel") - 1;
                PlayerPrefs.SetInt("AnimalNum", GameManager.Instance.AnimalNum);
            }

            // Set FOOT SKIN
            if (PlayerPrefs.GetInt("HasChosenFoot") == 0)
            {
                // set Foot sprite
                GameManager.Instance.FootNum = PlayerPrefs.GetInt("FootUnlocked");
                PlayerPrefs.SetInt("FootNum", GameManager.Instance.FootNum);
                PlayerPrefs.SetInt("FootNumSave", GameManager.Instance.FootNum);
            }

            // Set SHOE SKIN
            if (PlayerPrefs.GetInt("HasChosenShoe") == 0)
            {
                // set Shoe sprite
                GameManager.Instance.ShoeNum = PlayerPrefs.GetInt("ShoeUnlocked");
                PlayerPrefs.SetInt("ShoeNum", GameManager.Instance.ShoeNum);
                PlayerPrefs.SetInt("ShoeNumSave", GameManager.Instance.ShoeNum);
            }

            SceneManager.LoadScene("Level19");
        }
    }

    public void LoadLevel20()
    {
        if (PlayerPrefs.GetInt("LevelUnlocked") >= 20)
        {
            GameManager.Instance.ActiveLevel = 20;
            PlayerPrefs.SetInt("ActiveLevel", GameManager.Instance.ActiveLevel);

            // Set BALL SKIN
            if (PlayerPrefs.GetInt("HasChosenSprite") == 0)
            {
                // set ball sprite
                GameManager.Instance.AnimalNum = PlayerPrefs.GetInt("ActiveLevel") - 1;
                PlayerPrefs.SetInt("AnimalNum", GameManager.Instance.AnimalNum);
            }

            // Set FOOT SKIN
            if (PlayerPrefs.GetInt("HasChosenFoot") == 0)
            {
                // set Foot sprite
                GameManager.Instance.FootNum = PlayerPrefs.GetInt("FootUnlocked");
                PlayerPrefs.SetInt("FootNum", GameManager.Instance.FootNum);
                PlayerPrefs.SetInt("FootNumSave", GameManager.Instance.FootNum);
            }

            // Set SHOE SKIN
            if (PlayerPrefs.GetInt("HasChosenShoe") == 0)
            {
                // set Shoe sprite
                GameManager.Instance.ShoeNum = PlayerPrefs.GetInt("ShoeUnlocked");
                PlayerPrefs.SetInt("ShoeNum", GameManager.Instance.ShoeNum);
                PlayerPrefs.SetInt("ShoeNumSave", GameManager.Instance.ShoeNum);
            }

            SceneManager.LoadScene("Level20");
        }
    }

    private void Update()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("LevelUnlocked"); i++)
        {
            if (i <= 19) // 19 = max level - 1, (used to prevent out of array exception)
            {
                Locks[i].SetActive(false);
            }
            
        }
    }

}
