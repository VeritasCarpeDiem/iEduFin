// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Net.Http;
// using System.Threading.Tasks;
// using DefaultNamespace;
// using UnityEditor.VersionControl;
// //using UnityEngine;
//
// public class AvHandler
// {
//     //TODO: NEEDS REFACTORING
//
//     private const string BaseURL = "https://www.alphavantage.co/";
//     
//     //api parameters required for sending requests
//     private const string StockQuoteFunction = "GLOBAL_QUOTE";
//     private const string TimeSeriesFunction = "TIME_SERIES_";
//     private const string DefaultCurrency = "USD";
//     private const string ExchangeFunction = "CURRENCY_EXCHANGE_RATE";
//     
//     private string apiKey;
//     private HttpClient client;
//     
//     public AvHandler(string apiKey)
//     {
//         client = new HttpClient();
//         client.BaseAddress = new Uri(BaseURL);
//         this.apiKey = apiKey;
//     }
//     
//     public async Task<string> GetData(string functionName, string symbol)
//     {
//         string requestURL = $"query?function={functionName}&symbol={symbol}&apikey={this.apiKey}";
//         
//         string response = await GetResponse(requestURL);
//
//         return response;
//     }
//     
//     //retrieves individual stock quote 
//     public async Task<string> GetStockQuote(string symbol)
//     {
//         string requestURL = $"query?function={StockQuoteFunction}&symbol={symbol}&apikey={this.apiKey}";
//         
//         string response = await GetResponse(requestURL);
//
//         return response;
//     }
//
//
//     public async Task<string> GetTimeSeries(string seriesType, string symbol)
//     {
//         string requestURL = $"query?function={TimeSeriesFunction+seriesType}&symbol={symbol}&apikey={this.apiKey}";
//
//         string response = await GetResponse(requestURL);
//
//         return response;
//     }
//     //Gets exchange rate of  (crypto) currency to USD
//     public async Task<string> GetCryptoToUsd(string crypto)
//     {
//         string requestURL = $"query?function={ExchangeFunction}&from_currency={crypto}&to_currency={DefaultCurrency}&apikey={this.apiKey}";
//         
//         string response = await GetResponse(requestURL);
//
//         return response;
//     }
//
//     private async Task<string> GetResponse(string requestURL)
//     {
//         
//         var response = await this.client.GetAsync(requestURL);
//         var responseBody = await response.Content.ReadAsStringAsync();
//         
//         return responseBody;
//     }
// }
