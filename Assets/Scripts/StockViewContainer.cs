using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StockViewContainer : MonoBehaviour
{/// <summary>
 // ADD CASE FOR SEARCH BUTTON TO SWITCH SCENES TOO BASICALLY SAME AS CLICK 
 /// </summary>
    // Start is called before the first frame update
    [SerializeField] public TextMeshProUGUI stockText;
    [SerializeField] public TextMeshProUGUI  changeText;
    [SerializeField] public TextMeshProUGUI  priceText;
    //add reference to current stoock data object? 
    public CurrentStockData currentStockObject;
    public StockQuote stock { get; set; }
    public void Start()
    {
        currentStockObject = GameObject.FindWithTag("CurrStock").GetComponent<CurrentStockData>();
    }

    public void click()
   {
       //maybe make http request here and fetch, create stock quote object and store that instead
       currentStockObject.stock =  this.stock;
       Debug.Log("CURRENT STOCK NAME: " + currentStockObject.stock.Symbol);
       //update current stock on existing current stock object (maybe create stock obj in STOCKSCENEHANDER)
       SceneManager.LoadScene("StockDataScene");
        Debug.Log("DISPLAYING STOCK");
        Debug.Log(stockText.text);
        Debug.Log(changeText.text);
        Debug.Log(priceText.text);
       Debug.Log(stock.Symbol);
    }

}
