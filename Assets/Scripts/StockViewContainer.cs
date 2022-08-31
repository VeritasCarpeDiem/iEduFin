using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StockViewContainer : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI stockText;
    [SerializeField] public TextMeshProUGUI  changeText;
    [SerializeField] public TextMeshProUGUI  priceText;
    //add reference to current stoock data object
    public CurrentStockData currentStockObject;
    public StockQuote stock { get; set; }
    public void Start()
    {
        currentStockObject = GameObject.FindWithTag("CurrStock").GetComponent<CurrentStockData>();
    }

    public void click()
   {
       currentStockObject.stock =  this.stock;
       Debug.Log("CURRENT STOCK NAME: " + currentStockObject.stock.Symbol);
       SceneManager.LoadScene("StockDataScene");
   }

}
