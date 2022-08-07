using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
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

    public void OnClick()
    {
        Debug.Log("clicked");
        string symbol = this.stockInput.text;
        Debug.Log(symbol);
        
        var task = Task.Run(() => stockBuilding.RequestStockQuote(symbol));
        task.Wait(); 
        
        var stock  = stockBuilding.GetStockQuote();
    }
}
