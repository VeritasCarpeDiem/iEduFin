using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEditor.PackageManager.Requests;


public class StockSceneHandler : MonoBehaviour
{
    /*Will likely be dynamic list of all owned stocks to display to users upon entering stock market
     Currently a hardcoded array for testing purposes, will likely be a dynamic list populated by 
     call to database later 
     */
    
    //these stocks should be displayed in a scrollview? type object like in the wireframe
    public String[] StocksToDisplay = { "AAPL", "GOOGL", "AMZN", "MSFT" };

public StockBuilding stockBuilding;
        void Start()
        {
            stockBuilding = GameObject.FindWithTag("StockBuilding").GetComponent<StockBuilding>();
            GetData();
            
         }
        
        //Used to fetch data for stocks to be displayed in view
        async void GetData()
        {
           await Task.Run(()=>stockBuilding.RequestStockQuote("AAPL"));
            string s = stockBuilding.GetStockQuoteJson();
            Debug.Log(s);
        }
    }
