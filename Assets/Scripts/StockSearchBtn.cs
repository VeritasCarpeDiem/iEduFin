using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Scripting;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;
public class StockSearchBtn : MonoBehaviour
{
    //These are attatched to button object via editor 
    public StockBuilding stockBuilding;
    public TMPro.TMP_InputField stockInput;

    public async void OnClick()
    {
        Debug.Log("clicked");
        string symbol = this.stockInput.text;
        await stockBuilding.RequestStockQuote(symbol);
        Stock result = stockBuilding.GetStockQuote();
        Debug.Log(result);
        

    }
}
