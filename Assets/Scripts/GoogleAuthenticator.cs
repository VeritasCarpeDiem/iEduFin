using Proyecto26;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles UI button functions on signin scene
/// </summary>
public static class GoogleAuthenticator 
{
    private const string ClientId = "992076931933-1bl335kc6vhkguilhf5fsimdn2t8hsqm.apps.googleusercontent.com"; 
    private const string ClientSecret = "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";

    private const int Port = 1234;
    private static readonly string RedirectUri = $"http://localhost:{Port}";

    private static readonly HttpCodeListener codeListener = new HttpCodeListener(Port);

    public static void GetAuthCode()
    {
        //Instead of making a POST request to the Restclient.POST(), send a request to open the browser
        Application.OpenURL($"https://accounts.google.com/o/oauth2/v2/auth?client_id={ClientId}&redirect_uri={RedirectUri}&response_type=code&scope=email");

        codeListener.StartListening(code =>
        {
            ExchangeAuthCodeWithIdToken(code, idToken =>
            {
                FirebaseAuthenticator.SignInWithToken(idToken, "google.com");
            });

            codeListener.StopListening();
        });
    }

    /// <summary>
    /// The <code>ExchangeAuthCodeWithIDToken</code> exchanges the Auth Code with the user's Id Token
    /// For documentation on how to make a POST request, see https://github.com/proyecto26/RestClient#generic-request-method
    /// </summary>
    /// <param name="code">auth code</param> 
    /// <param name="callback">what action to take after this method is executed</param> 
    public static void ExchangeAuthCodeWithIdToken(string code, Action<string> callback)
    {
        try
        {
            RestClient.Request(new RequestHelper
            {
                Method = "POST",
                Uri = "https://oauth2.googleapis.com/token",
                Params = new Dictionary<string, string>
                {
                    {"code", code},
                    {"client_id", ClientId},
                    {"client_secret", ClientSecret},
                    {"redirect_uri", RedirectUri},
                    {"grant_type", "authorization_code"}
                }
            }).Then(
                response =>
                {
                    var data =
                        StringSerializationAPI.Deserialize(typeof(GoogleIdTokenResponse), response.Text) as
                            GoogleIdTokenResponse;
                    callback(data.id_token);
                }).Catch(Debug.Log);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
}
