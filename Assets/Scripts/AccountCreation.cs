using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DefaultNamespace;
using Newtonsoft.Json;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class AccountCreation : MonoBehaviour
    {
        //Create references to all necessary UI elements 
        // should be changed to "http://132.249.242.242/account/create"
        [SerializeField] private TMP_InputField emailInput;
        [SerializeField] private TMP_InputField usernameInput;
        [SerializeField] private TMP_InputField passwordInput;
        [SerializeField] private TMP_InputField confirmPasswordInput;
        [SerializeField] private TextMeshProUGUI alertText;
        [SerializeField] private Button createButton;
        [SerializeField] private TextMeshProUGUI warningText;
        //API endpoints
         private string authenticationEndpoint = "http://132.249.242.242";
        const string CREATION_ENDPOINT = "/account/create";
        private const string PLAYERDATA_ENDPOINT = "/account/data"; 
        private HttpClient client = new HttpClient();
        //create and populate default player data here 
        public async void onClickCreate()
        {
     
            await TryCreate();

        }

        public async Task TryCreate()
        {
            string username = usernameInput.text.ToLower();
            string password = passwordInput.text;
            string confirmPassword = confirmPasswordInput.text;
            string email = emailInput.text.ToLower();
            alertText.text = "Creating Account";
            this.createButton.interactable = false;
            if (username == "" || password == "")
            {
                alertText.text = "username and password can't be empty";
                this.createButton.interactable = true; 
                return;
            }
            if (username.Contains(" "))
            {
                alertText.text = "Invalid username, no spaces allowed";
                this.createButton.interactable = true; 
                return;
            }
            
            if (!isValidEmail(email))
            {
                alertText.text = "Please enter a valid email";
                this.createButton.interactable = true;
                return;
            }
            
            if (confirmPassword != password)
            {
                alertText.text = "Passwords do not match";
                this.createButton.interactable = true;
                return;
            }

            try
            {
                
                this.client.BaseAddress = new Uri(this.authenticationEndpoint);

                var accountCredentials = new Dictionary<string, string>()
                {
                    //REMAIL DOESNTEXIST YET
                    //{ "remail", email },
                    { "rusername", username },
                    { "rpassword", password }
                };
                
                var data = new FormUrlEncodedContent(accountCredentials);
                var response = await client.PostAsync(new Uri(this.authenticationEndpoint + CREATION_ENDPOINT), data);
            
                var respBody = await response.Content.ReadAsStringAsync();
                Debug.Log(respBody);
                //invalid authentication case
                if ((int)response.StatusCode == 409)
                {
                    this.createButton.interactable = true;
                    alertText.text = respBody;
                }
                //once account is created
                else
                {
                    //successful account creation, create default account 
                    //String class: string username: string serializedjson : string 
                    //TODO: once basic functionality is implemented, add class selection option
                    PlayerAccountData playerAcc = new PlayerAccountData(username);
                    string serializedAcc = JsonConvert.SerializeObject(playerAcc);
                    
                    //post default account to appropriate route
                    var postPlayerData = new Dictionary<string, string>()
                    {
                        {"username", username},
                        {"serializedData",serializedAcc},
                        // {"Selected Character",characterSelected}
                    };
                    var accData = new FormUrlEncodedContent(postPlayerData);
                    var accResponse = await client.PostAsync(new Uri(this.authenticationEndpoint + PLAYERDATA_ENDPOINT), accData);
                    var accRespBody = await accResponse.Content.ReadAsStringAsync();
                    PlayerAccountData newObj = JsonConvert.DeserializeObject<PlayerAccountData>(accRespBody);
                    
                    //Destroy additional AccountManager gameobject that is created
                    GameObject acDestroy = GameObject.FindWithTag("AccountManager");
                    Destroy(acDestroy);
                    
                    alertText.text ="Account has been created please return to log in";
                }

            }
            catch(Exception e)
            {
                this.createButton.interactable = true;
                alertText.text = "could not connect to server";
                return;
            }
           

        }

        bool isValidEmail(string email)
        {
            string pattern = "^[^@\\s]+@[^@\\s]+(\\.[^@\\s]+)+$";
            return Regex.IsMatch(email, pattern);
        
        }
        
    }
    