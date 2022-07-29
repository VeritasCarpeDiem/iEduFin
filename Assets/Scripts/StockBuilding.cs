using System;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;


    public class StockBuilding : MonoBehaviour
    {
        private const string ApiKey = "5SO0PDYFZVGM2FC4";
        private const string BaseURL = "https://www.alphavantage.co/";
        private const string StockQuoteFunction = "GLOBAL_QUOTE";

        private string currentStockQuote;
        private HttpClient client;

        public StockBuilding()
        {
            this.client = new HttpClient();
            this.client.BaseAddress = new Uri(BaseURL);
        }

        //Need to refactor getter method
        //prints out invalid api call message if failed 
        public async Task RequestStockQuote(string symbol)
        {
            string stockRequestURL = $"query?function={StockQuoteFunction}&symbol={symbol}&apikey={ApiKey}";
        
            var response = await this.client.GetAsync(stockRequestURL);
            var responseBody = await response.Content.ReadAsStringAsync();
            this.currentStockQuote = responseBody; 
            Debug.Log("SENT REQ JSON:");
            Debug.Log(responseBody);
           
        }

        //For testing, probably unecessary 
        public String GetStockQuoteJson()
        {
            String toReturn = this.currentStockQuote;
            this.currentStockQuote = null;   //reset after each call
            return toReturn;
        }
        //Getter Mehtod 
        public Stock GetStockQuote()
        {
            String toReturn = this.currentStockQuote;
            Debug.Log("Type");
            Debug.Log(typeof(Stock));
            var stock = JsonUtility.FromJson<Stock>(toReturn);
            this.currentStockQuote = null;
            return stock;
        }
    }
 

