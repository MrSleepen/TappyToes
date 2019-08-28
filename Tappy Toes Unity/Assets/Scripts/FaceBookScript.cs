using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;

public class FaceBookScript : MonoBehaviour {
    public Text FriendsText;
    // Use this for initialization
    private void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(() =>
            {
                if (FB.IsInitialized)
                    FB.ActivateApp();
                else
                    Debug.LogError("Couldent initialize");
            },
             isGameShown =>
             {
                 if (!isGameShown)

                     Time.timeScale = 0;
                 else
                     Time.timeScale = 1;
             });
        }
        else
            FB.ActivateApp();
    }
    #region Login/Logout
    public void FacebookLogin()
    {
        var permissions = new List<string>() { "public_profile", "email", "user_friends" };
        FB.LogInWithPublishPermissions(permissions);
    }
    public void FacebookLogout()
    {
        FB.LogOut();
    }
    #endregion
    public void FacebookShare()
    {
        FB.ShareLink(new System.Uri("link to  Game"), "Tappy Toes", "Come Play this game with me", new System.Uri("LogoHere"));
    }
    #region Inviting
    public void FaebookGameRequest()
    {
        FB.AppRequest("Hey! Come play this awsome game!", title: "Tappy Toes");
    }
    public void FacebookInvite()
    {
        FB.Mobile.AppInvite(new System.Uri("Link to game here"));

    }
    #endregion
    public void GetFriendsPlayingThisGame()
    {
        string query = "/me/friends";
        FB.API(query, HttpMethod.GET, result =>
        {
            var dictionary = (Dictionary<string, object>)Facebook.MiniJSON.Json.Deserialize(result.RawResult);
            var friendsList = (List<object>)dictionary["data"];
            FriendsText.text = string.Empty;
            foreach (var dict in friendsList)
                FriendsText.text += ((Dictionary<string, object>)dict)["name"];
        });
    }

}
