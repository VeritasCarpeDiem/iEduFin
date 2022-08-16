using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DefaultNamespace;
using Newtonsoft.Json;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;


public class NewLoginBtn : UnityEngine.MonoBehaviour
{
    [SerializeField] private string authenticationEndpoint = "http://localhost:13756/account/login";
    
    [SerializeField] private TMP_InputField usernameInput;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private TextMeshProUGUI alertText;
    [SerializeField] private Button loginButton;
   
    private HttpClient client = new HttpClient();

    public async void OnClick()
    {
        Debug.Log("test");
        await TryLogin();
    Debug.Log("test");
    }
    async Task TryLogin()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;
        alertText.text = "Signing in...";
        this.loginButton.interactable = false;
        Debug.Log("before try ");
        try
        {
            Debug.Log("in try ");
            this.client.BaseAddress = new Uri(this.authenticationEndpoint);
            
            string requrl = $"?rusername={username}&rpassword={password}";
            
            var loginCredentials = new Dictionary<string, string>()
            {
                { "rusername", username },
                { "rpassword", password }
            };
            
            var data = new FormUrlEncodedContent(loginCredentials);
            var response = await client.PostAsync(new Uri(this.authenticationEndpoint),data);
            var respBody = await response.Content.ReadAsStringAsync();
            Debug.Log("here");
            if (response.StatusCode.ToString() == "Unauthorized") 
            {
                this.loginButton.interactable = true;
                alertText.text = respBody;
            }
            else
            {
                GameAccount returnedAccount = JsonUtility.FromJson<GameAccount>(respBody);
                alertText.text = $"Welcome {returnedAccount.username}";
                Debug.Log("here");
                Debug.Log(response);
                Debug.Log(respBody);
            }
            Debug.Log(respBody);
        }
        catch (HttpRequestException e) 
        { this.loginButton.interactable = true;
            alertText.text = "Could not connect to server";
            throw;
        }
    }

}

// async Task TryLogin()
// {
//     string username = usernameInput.text;
//     string password = passwordInput.text;
//     alertText.text = "Signing in...";
//
//     this.client.BaseAddress = new Uri(this.authenticationEndpoint);
//     string requrl = $"?rusername={username}&rpassword={password}";
//     var response = await client.GetAsync(requrl);
//     if (response.IsSuccessStatusCode)
//     {
//         alertText.text = "Welcome";
//         var respbody = await response.Content.ReadAsStringAsync();
//         Debug.Log(respbody);
//         Debug.Log(response.StatusCode.ToString() == "OK");
//         loginButton.interactable = false;
//     }
//
//     else
//     {
//         loginButton.interactable = true;
//             
//         if ((int)response.StatusCode == 401)
//         {
//             var respobody = await response.Content.ReadAsStringAsync();
//             this.alertText.text = "Invalid Credentials";
//             Debug.Log(respobody);
//         }
//         else
//         {
//             alertText.text = "Could not connect to server, please try again";
//         }
//
//     }
// }




