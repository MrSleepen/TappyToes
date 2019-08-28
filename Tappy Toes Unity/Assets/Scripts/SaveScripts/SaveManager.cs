using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//////////////////////////////////////////////////CHANGE NOTHING IN THIS SCRIPT/////////////////////////////////////////
public class SaveManager : MonoBehaviour {
    private static SaveManager Instance { set; get; }
    public SaveState state;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        Load();
    }

    //Save the whole state of this savestate script to player pref

    public void Save()
    {
        PlayerPrefs.SetString("save",HelperScript.Serialize<SaveState>(state));
    }

    //Load the Previously saved state from player pref

    public void Load()
    {
        if (PlayerPrefs.HasKey("save"))
        {
            state = HelperScript.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
        }
        else
        {
            state = new SaveState();
            Save();
            Debug.Log("No Save File Found Creating one");
        }
    }

   

}
 //////////////////////////////////////////////////CHANGE NOTHING IN THIS SCRIPT/////////////////////////////////////////