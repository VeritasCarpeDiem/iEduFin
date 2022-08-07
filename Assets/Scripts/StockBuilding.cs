using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Android;


public class StockBuilding : MonoBehaviour
    {
        //TODO: Remove API Key
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
        //TODO: Handle case where API fails 
        public async Task RequestStockQuote(string symbol)
        {
            string stockRequestURL = $"query?function={StockQuoteFunction}&symbol={symbol}&apikey={ApiKey}";
        
            var response = await this.client.GetAsync(stockRequestURL);
            var responseBody = await response.Content.ReadAsStringAsync();
          
            this.currentStockQuote = responseBody; 

            Debug.Log(responseBody);
            
        }
        
        //Getter Mehtod 
        public StockQuote GetStockQuote()
        {
            String toReturn = this.currentStockQuote;
            QuoteRequest quote = JsonConvert.DeserializeObject<QuoteRequest>(toReturn);
            StockQuote stock = quote.StockQuote;
            return stock;
        }
        public String GetStockTimeSeries(string typeOfSeries)
        {
            // String toReturn = this.currentStockQuote;
            // QuoteRequest quote = JsonConvert.DeserializeObject<QuoteRequest>(toReturn);
            // StockQuote stock = quote.StockQuote;
            // return stock;
            return "";
        }
    }
 

