using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FirebaseAuthenticator 
{
    //never hardcode like this! This poses a high security risk
    //TODO: refactor hard coded values. See https://codeql.github.com/codeql-query-help/csharp/cs-hardcoded-credentials/
    private const string APIKey = "AIzaSyC0DjFRBcg5diwu6tHCtXFLfD66oJ3_VYk";
    public static void SignInWithToken(string token, string providerId)
    {
        var payLoad =
            $"{{\"postBody\":\"id_token={token}&providerId={providerId}\",\"requestUri\":\"http://localhost\",\"returnIdpCredential\":true,\"returnSecureToken\":true}}";

        RestClient.Post($"https://identitytoolkit.googleapis.com/v1/accounts:signInWithIdp?key={APIKey}", payLoad).Then(
            response =>
            {
                Debug.Log(response.Text);
            }).Catch(Debug.Log);
    }
}
