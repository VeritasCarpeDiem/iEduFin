using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class AccountCreation : MonoBehaviour
    {
        //CREATE A POP UP WINDOW HERE 
        [SerializeField] private string authenticationEndpoint = "http://localhost:13756/account/create";
        // should be changed to "http://132.249.242.242/account/create"
        [SerializeField] private TMP_InputField emailInput;
        [SerializeField] private TMP_InputField usernameInput;
        [SerializeField] private TMP_InputField passwordInput;
        [SerializeField] private TMP_InputField confirmPasswordInput;
        [SerializeField] private TextMeshProUGUI alertText;
        [SerializeField] private Button createButton;
        [SerializeField] private TextMeshProUGUI warningText;
        
        private HttpClient client = new HttpClient();
        //create and populate default player data here 
        public async void onClickCreate()
        {
            Debug.Log("test create ");
            await TryCreate();
            Debug.Log("Done w create");
        }

        public async Task TryCreate()
        {
            string username = usernameInput.text.ToLower();
            string password = passwordInput.text;
            string confirmPassword = confirmPasswordInput.text;
            string email = emailInput.text.ToLower();
            alertText.text = "Creating Account";
            this.createButton.interactable = false;
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
                var response = await client.PostAsync(new Uri(this.authenticationEndpoint), data);
                var respBody = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 409)
                {
                    this.createButton.interactable = true;
                    alertText.text = respBody;
                }
                else
                {
                    Debug.Log("Account has been created please return to log in ");
                    alertText.text ="Account has been created please return to log in";
                }

            }
            catch(HttpRequestException e)
            {
                this.createButton.interactable = true;
                alertText.text = "could not connect to server";
                throw;
            }
           

        }

        bool isValidEmail(string email)
        {
            string pattern = "^[^@\\s]+@[^@\\s]+(\\.[^@\\s]+)+$";
            return Regex.IsMatch(email, pattern);
        
        }
        
    }
    