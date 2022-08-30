using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

namespace DefaultNamespace
{
    public class CryptoBuilding : MonoBehaviour
    {
        private string currentCrypto;
        private HttpClient client;
        private const string FAILED_RESPONSE = "Crypto not found";

        public CryptoBuilding()
        {
            this.client = new HttpClient();

            this.client.BaseAddress = new Uri(("http://132.249.242.242/crypto/"));
           

        }

        public async Task RequestCryptoQuote(string symbol)
        {
            var response = await this.client.GetAsync(symbol);

            var responseBody = await response.Content.ReadAsStringAsync();
            
            if(responseBody == FAILED_RESPONSE)
            {
                this.currentCrypto = null;
                Debug.Log(responseBody);
                return;
            }

            this.currentCrypto = responseBody;
            Debug.Log("Top");
            Debug.Log(responseBody);
            Debug.Log("bot");
        }

        public CryptoData GetCryptoQuote()
        {
            try
            {
                string toReturn = this.currentCrypto;
                CryptoRequest cryptoRequest = JsonConvert.DeserializeObject<CryptoRequest>(toReturn);
                CryptoData crypto = cryptoRequest.CryptoData;
                this.currentCrypto = null;
                return crypto;

            }
            catch (Exception e)
            {
                Debug.Log(e);
                return null;
            }
        }
    }
}