using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DefaultNamespace;
using Newtonsoft.Json;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NewLoginBtn : UnityEngine.MonoBehaviour
{
   // [SerializeField] private string authenticationEndpoint = "http://132.249.242.242/account/login";
   [SerializeField] string authenticationEndpoint = "http://localhost:13756";
    [SerializeField] private TMP_InputField usernameInput;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private TextMeshProUGUI alertText;
    [SerializeField] private Button loginButton;
     //string authenticationEndpoint = "http://localhost:13756";
     const string LOGIN_ENDPOINT = "/account/login";
     private const string PLAYERDATA_ENDPOINT = "/account/data/"; 
    private HttpClient client = new HttpClient();
    
    public AccountManager accountManager;

    private void Start()
    {

    }

    public async void OnClick()
    {
        Debug.Log("test");
        await TryLogin();
    Debug.Log("test end");
    }
    async Task TryLogin()
    {
    //add email here maybe 
        string username = usernameInput.text.ToLower();
        string password = passwordInput.text;
        alertText.text = "Signing in...";
        this.loginButton.interactable = false;
        Debug.Log("before try ");
        try
        {
            Debug.Log("in try ");
            //this.client.BaseAddress = new Uri(this.authenticationEndpoint);
            //.Log(this.client.BaseAddress);
            //string requrl = $"?rusername={username}&rpassword={password}";
            
            var loginCredentials = new Dictionary<string, string>()
            {
                { "rusername", username },
                { "rpassword", password }
            };
            
            var data = new FormUrlEncodedContent(loginCredentials);
            var response = await client.PostAsync(new Uri(this.authenticationEndpoint + LOGIN_ENDPOINT),data);
            var respBody = await response.Content.ReadAsStringAsync();
            Debug.Log("here");
            Debug.Log(respBody);
            if (response.StatusCode.ToString() == "Unauthorized") 
            {
                this.loginButton.interactable = true;
                alertText.text = respBody;
            }
            else
            {
                Debug.Log("SSSSS");
                var accResponse = await client.GetAsync(new Uri(this.authenticationEndpoint + PLAYERDATA_ENDPOINT + username));
                var accRespBody = await accResponse.Content.ReadAsStringAsync();
                //maybe instantiate a global account here with same fields + account info 
                PlayerAccountData returnedAccount = JsonConvert.DeserializeObject<PlayerAccountData>(accRespBody);
                accountManager.playerAccount = returnedAccount;
                alertText.text = $"Welcome {returnedAccount.username}";
                accountManager.OnDeserialize();
                string testSerialize = JsonConvert.SerializeObject(accountManager.playerAccount);
                Debug.Log("test//// + " + testSerialize);
                Debug.Log("Balance + " + returnedAccount.balance);
                Debug.Log("here");
                Debug.Log(response);
                Debug.Log(respBody);
                SceneManager.LoadScene("TestMap");
            }
            //Debug.Log(respBody);
        }
        catch (Exception e) 
        { this.loginButton.interactable = true;
            alertText.text = "Could not connect to server";
            return;
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




