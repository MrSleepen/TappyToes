using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainToggle : MonoBehaviour {

    public GameObject Rain;
    public GameObject Rain_Clone;
    public GameObject RainCatcher;

    void Start()
    {
        if (PlayerPrefs.GetInt("ChallengeMode") == 1)
        {
            Rain = Resources.Load("Prefabs/Effects/Rain") as GameObject;
            if (Rain == null)
            {
                Debug.Log("Wind is NULL");
            }
            Instantiate(Rain, new Vector3(0, 5, 0), Quaternion.identity);

            RainCatcher = Rain.transform.Find("RainCatcher").gameObject;
        }
    }

    public void Rain_Activate()
    {
        Rain = Resources.Load("Prefabs/Effects/Rain") as GameObject;
        if (Rain == null)
        {
            Debug.Log("Rain is NULL");
        }
        Rain_Clone = Instantiate(Rain, new Vector3(0, 5, 0), Quaternion.identity);

        //RainCatcher = Rain.transform.Find("RainCatcher").gameObject;
        //    Rain.SetActive(true);
        //    RainCatcher.SetActive(false);
    }

    public void Rain_Deactivate()
    {
        Debug.Log("Rain Deactivate");
        RainCatcher.SetActive(true);
        Invoke("Rain_Off", 3.0f);
    }

    void Rain_Off()
    {
        Debug.Log("Rain Off");
        Rain.SetActive(false);
        //Destroy(gameObject);

        Destroy(Rain_Clone);

        //RainCatcher.SetActive(true);
        //Invoke("Rain_Off", 3.0f);

    }

    //void Rain_Off()
    //{
    //    Rain.SetActive(false);
    //}

}
