using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class StockSearchBtn : MonoBehaviour
{
    //These are attatched to button object via editor 
    public StockBuilding stockBuilding;
    public TMPro.TMP_InputField stockInput;
    private CurrentStockData currentStockObject;

    private void Start()
    {
        currentStockObject = GameObject.FindWithTag("CurrStock").GetComponent<CurrentStockData>();
    }

    public async void OnClick()
    {
        if (stockInput.text == "")
        {
            Debug.Log("Stock field is empty");
        }
        
        Debug.Log("clicked");
        
        string symbol = this.stockInput.text;
        
        Debug.Log(symbol);
     
        await stockBuilding.RequestStockQuote(symbol);

        // var stock =  Task.Run(() => stockBuilding.GetStockQuote(symbol));
        
        var stock = stockBuilding.GetStockQuote();
        Debug.Log("outside");
        if (stock != null)
        {
            Debug.Log("inside");
            currentStockObject.stock = stock;
            SceneManager.LoadScene("StockDataScene");
        }

    }
}

