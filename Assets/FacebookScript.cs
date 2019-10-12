using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;

public class FacebookScript : MonoBehaviour
{
    private void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(() =>
            {
                // if facebook initialized then activate the app
                if (FB.IsInitialized)
                {
                    FB.ActivateApp();
                }
                else
                {
                    Debug.LogError("Couldn't initialize!");
                }
            },
            isGameShown =>
            {
                // if the game is not shown that means if the game is currently hidden
                if (!isGameShown)
                {
                    Time.timeScale = 0;     // freeze the game
                }
                else
                {
                    Time.timeScale = 1;     // game will run in normal speed
                }
            });
        }
        else
        {
            FB.ActivateApp();
        }
    }

    #region login/logout
    public void FacebookLogin()
    {
        var permissions = new List<string>() { "public_profile", "email", "user_friends" };
        FB.LogInWithReadPermissions(permissions);
    }

    public void FacebookLogout()
    {var permissions = new List<string>() { "public_profile", "email", "user_friends" };
        FB.LogOut();
    }
    #endregion
}
