using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{

    public class AccountManager : MonoBehaviour
    { public PlayerAccountData playerAccount;
       private string authenticationEndpoint = "http://132.249.242.242";
       const string CREATION_ENDPOINT = "/account/create";
       private const string PLAYERDATA_ENDPOINT = "/account/data";
       private HttpClient client = new HttpClient();
        // private void Start()
        // {
        //     DontDestroyOnLoad(this);
        // }
        private void Awake()
        {
            int numAM = FindObjectsOfType<AccountManager>().Length;
            if (numAM!= 1)
            {
                Destroy(this.gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        public async Task saveData()
        {
            string serializedAcc = JsonConvert.SerializeObject(playerAccount);
            Debug.Log(serializedAcc);
            //post default account to appropriate route
            var postPlayerData = new Dictionary<string, string>()
            {
                {"username", playerAccount.username},
                {"serializedData",serializedAcc},
            };
            Debug.Log("SERIALIZED STRING: " + serializedAcc);
            Debug.Log(playerAccount.username);
            var accData = new FormUrlEncodedContent(postPlayerData);
            
            Debug.Log(this.authenticationEndpoint + PLAYERDATA_ENDPOINT);
            var accResponse = await client.PostAsync(new Uri(this.authenticationEndpoint + PLAYERDATA_ENDPOINT), accData);
            
            var accRespBody = await accResponse.Content.ReadAsStringAsync();
            //PlayerAccountData newObj = JsonConvert.DeserializeObject<PlayerAccountData>(accRespBody); 
            //Debug.Log(accRespBody);
        }
        

        public void OnDeserialize()
        {
            if (playerAccount.ownedCrypto == null)
            {
                playerAccount.ownedCrypto = new Dictionary<string, decimal>();
            }

            if (playerAccount.ownedStocks == null)
            {
                playerAccount.ownedStocks = new Dictionary<string, int>();
            }

            if (playerAccount.transactionHistory == null)
            {
                playerAccount.transactionHistory = new List<Transaction>();
            }
            
            if (playerAccount.accountValueHistory == null)
            {
                playerAccount.accountValueHistory = new Dictionary<string, decimal>();
            }
        }
    }
}