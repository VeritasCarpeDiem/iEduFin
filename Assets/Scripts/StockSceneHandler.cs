using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.UIElements;
using System.IO;


public class StockSceneHandler : MonoBehaviour
{
    private String[] StocksToDisplay;
    public StockBuilding stockBuilding;
    //private List<StockQuote> stockList;
    [SerializeField] private GameObject stockTextPrefab;
    [SerializeField] private Transform stockTextParent;
    private StockQuote currStock;
    [SerializeField]  TMP_InputField enterStockSearch;
    [SerializeField] public TextMeshProUGUI  warningText;
        void  Start()
        {
            Debug.Log("PERSISTAJT PATH::: ");
            Debug.Log(Application.persistentDataPath);
            
            // string path = Application.dataPath + "/StockAndCryptoData/StockData.txt";
            string path = Application.streamingAssetsPath + "/stockcryptodata/StockData.txt";
            var data = System.IO.File.ReadAllText(path);
            StocksToDisplay = data.Split(",");

            stockBuilding = GameObject.FindWithTag("StockBuilding").GetComponent<StockBuilding>();
            
            DisplayStocks();
        }
        
       async void DisplayStocks()
       {

           for (int i = 0; i < StocksToDisplay.Length; i++)
           {
               try
               {
                   await stockBuilding.RequestStockQuote(this.StocksToDisplay[i]);
                   StockQuote s = stockBuilding.GetStockQuote();
                   if (s != null)
                   {
                       GameObject stockTextObj = Instantiate(stockTextPrefab, stockTextParent);
                       stockTextObj.GetComponent<StockViewContainer>().stock = s;
                       stockTextObj.GetComponent<StockViewContainer>().stockText.text = s.Symbol;
                       stockTextObj.GetComponent<StockViewContainer>().changeText.text = s.ChangePercent;

                       Decimal roundedPrice = Math.Round(s.Price, 2);
                       stockTextObj.GetComponent<StockViewContainer>().priceText.text = "$" + roundedPrice.ToString();
                   }
               }
               catch (Exception e)
               {
                   Debug.Log(e);
                   warningText.text =
                       "ERROR:Could not connect to server, please check internet connection. Exit building and try again.";
                   return;
               }
           }

       }

}
