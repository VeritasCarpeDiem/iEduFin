using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StockViewContainer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public TextMeshProUGUI stockText;
    [SerializeField] public TextMeshProUGUI  changeText;
    [SerializeField] public TextMeshProUGUI  priceText;
    public StockQuote stock;
   public void click()
   {
       SceneManager.LoadScene("StockDataScene");
        Debug.Log("DISPLAYING STOCK");
        Debug.Log(stockText.text);
        Debug.Log(changeText.text);
        Debug.Log(priceText.text);
        Debug.Log(stock.Symbol);
    }

}
