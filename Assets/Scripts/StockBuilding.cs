using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.Android;


public class StockBuilding : MonoBehaviour
    {
        //TODO: Remove API Key
        //private const string ApiKey = "5SO0PDYFZVGM2FC4";
        //rivate const string BaseURL = "https://www.alphavantage.co/";
        private const string StockQuoteFunction = "GLOBAL_QUOTE";
       // https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=AAPL&apikey=5SO0PDYFZVGM2FC4
        private string currentStockQuote;
        private HttpClient client;
        private const string FAILED_RESPONSE = "Stock not found";

        public StockBuilding()
        {
            this.client = new HttpClient();
            //this.client.BaseAddress = new Uri(BaseURL);
            //this.client.BaseAddress = new Uri("http://localhost:13756/stocks/");
            this.client.BaseAddress = new Uri("http://132.249.242.242/stocks/");
        }
        
        public async Task RequestStockQuote(string symbol)
        {
            //string stockRequestURL = $"query?function={StockQuoteFunction}&symbol={symbol}&apikey={ApiKey}";
        
            var response = await this.client.GetAsync(symbol);
            var responseBody = await response.Content.ReadAsStringAsync();
          
            if (responseBody == FAILED_RESPONSE)
            {
                this.currentStockQuote = null;
            }

            else
            {
                this.currentStockQuote = responseBody;
            }
            
            Debug.Log("Response Body" + responseBody);
        }
        
        //Getter Mehtod 
        public StockQuote GetStockQuote()
        {
            try
            {
                String toReturn = this.currentStockQuote;
                QuoteRequest quote = JsonConvert.DeserializeObject<QuoteRequest>(toReturn);
                StockQuote stock = quote.StockQuote;
                this.currentStockQuote = null;
                return stock;
            }
            catch (Exception e)
            {
                return null;
            }
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
 

