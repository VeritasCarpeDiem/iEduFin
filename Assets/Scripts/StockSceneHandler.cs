using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager.Requests;
using UnityEngine.UIElements;


public class StockSceneHandler : MonoBehaviour
{
    /*Will likely be dynamic list of all owned stocks to display to users upon entering stock market
     Currently a hardcoded array for testing purposes, will likely be  populated by 
     call to database later 
     */
    
    //these stocks should be displayed in a scrollview type object like in the wireframe
    
    private String[] StocksToDisplay =  { "AAPL", "GOOGL","TSLA","AMZN","META" };
    public StockBuilding stockBuilding;
    //private List<StockQuote> stockList;
    [SerializeField] private GameObject stockTextPrefab;
    [SerializeField] private Transform stockTextParent;
    private StockQuote currStock;
        void  Start()
        {
            stockBuilding = GameObject.FindWithTag("StockBuilding").GetComponent<StockBuilding>();
            DisplayStocks();
        }
        
       async void DisplayStocks()
       {
          
           for (int i = 0; i < 5; i++)
           {  
               
               await stockBuilding.RequestStockQuote(this.StocksToDisplay[i]);
               StockQuote s = stockBuilding.GetStockQuote();
               
               GameObject stockTextObj = Instantiate(stockTextPrefab, stockTextParent);
               stockTextObj.GetComponent<StockViewContainer>().stock = s;
               stockTextObj.GetComponent<StockViewContainer>().stockText.text = s.Symbol;
               stockTextObj.GetComponent<StockViewContainer>().changeText.text = s.ChangePercent;
               
               Decimal roundedPrice = Math.Round(s.Price, 2);
               stockTextObj.GetComponent<StockViewContainer>().priceText.text =  "$" + roundedPrice.ToString();

           }
   
       }

}
