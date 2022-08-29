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
   [SerializeField] private string authenticationEndpoint = "http://localhost:13756";
   const string LOGIN_ENDPOINT = "/account/login";
   private const string PLAYERDATA_ENDPOINT = "/account/data/"; 
  // [SerializeField] string authenticationEndpoint = "http://132.249.242.242";
    
    [SerializeField] private TMP_InputField usernameInput;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private TextMeshProUGUI alertText;
    [SerializeField] private Button loginButton;

    private HttpClient client; 
    public AccountManager accountManager;

    private void Start()
    {
        client = new HttpClient();
    }

    public async void OnClick()
    {
        Debug.Log("test");
        await TryLogin();
        Debug.Log("test end");
    }
    async Task TryLogin()
    {
        string username = usernameInput.text.ToLower();
        string password = passwordInput.text;
        alertText.text = "Signing in...";
        this.loginButton.interactable = false;
        
        Debug.Log("before try ");
        try
        {
            Debug.Log("in try ");

            var loginCredentials = new Dictionary<string, string>()
            {
                { "rusername", username },
                { "rpassword", password }
            };
            
            var data = new FormUrlEncodedContent(loginCredentials);
            var response = await client.PostAsync(new Uri(this.authenticationEndpoint + LOGIN_ENDPOINT),data);
            var respBody = await response.Content.ReadAsStringAsync();

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
                GameObject ccDestroy = GameObject.FindWithTag("CurrCrypto");
                Destroy(ccDestroy);
               // SceneManager.LoadScene("TestMap2");

               if (returnedAccount.className == "")
               {
                   SceneManager.LoadScene("CharacterSelection");
               }
               else
               {
                   // SceneManager.LoadScene("TestMap2");
                   SceneManager.LoadScene("MapTest3");
               }
            }
            //Debug.Log(respBody);
        }
        catch (HttpRequestException e) 
        { 
            this.loginButton.interactable = true;
            alertText.text = "Could not connect to server";
            return;
        }catch (Exception e)
        {
            Debug.Log(e);
            return;
        }
    }



}





