using System;
using System.Runtime.CompilerServices;
using System.Xml.Schema;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class PopulateStockData : MonoBehaviour
    {
        private const string MAX_QUANTITY = "999";
        private const string DEFAULT_PRICE = "$0.00";
        const string BUY_MESSAGE = "BUY";
        //FINISH ADDING REFERENCES TO /POPULATINGH EXISTING ONES AND THEN ONCE DONE W/ ACCOUNT ADD PURCHASE FEATURE
        [SerializeField]  TMP_Dropdown dropdown;
        [SerializeField] private TextMeshProUGUI quantityPrice;
            
        [SerializeField] private TMP_InputField quantityInputField;
        [SerializeField]  TextMeshProUGUI stockTextLeft;
        [SerializeField]  TextMeshProUGUI stockName;
        [SerializeField]  TextMeshProUGUI changeText;
        [SerializeField]  TextMeshProUGUI priceText;
        [SerializeField]  TextMeshProUGUI purchaseMessage;
        
        private CurrentStockData currStock;
        private StockQuote stock;
        
        
        private void Start()
        {
            currStock = GameObject.FindWithTag("CurrStock").GetComponent<CurrentStockData>();
            this.stock = currStock.stock;
            // DEFAULT_PRICE = quantityPrice.text;
            stockTextLeft.text = stock.Symbol;
            populateUI();
        }

        void populateUI()
        {
            Debug.Log(dropdown.captionText.text);
            this.stockName.text = stock.Symbol;
            this.priceText.text = "$" + Math.Round((stock.Price ), 2);
            this.changeText.text = stock.ChangePercent;
            Debug.Log("///////////////////////////////");
            Debug.Log(Convert.ToDecimal(priceText.text.Trim('$')));
       
                quantityInputField.onValueChanged.AddListener(delegate { ValueChangeCheck(); });

            }
        public void ValueChangeCheck()
        {
            //if user deletes currrent input 
            if (quantityInputField.text == "")
            {
                Debug.Log("EMPTY!");
                //quantityInputField.text = "";
                quantityPrice.text = DEFAULT_PRICE;
            }
            else if (int.Parse(quantityInputField.text) > (int.Parse(MAX_QUANTITY))) 
            {
                quantityInputField.text = MAX_QUANTITY;
            }
            else
            {
                decimal currStockPrice = Convert.ToDecimal(priceText.text.Trim('$'));
                quantityPrice.text = "$" + Math.Round((int.Parse(quantityInputField.text) * currStockPrice), 2);
            }
  
        }

        public void OnSubmit()
        //TODO: MAYBE ADD CASE for 0 instead of letting them buy/sell 0 shares
        {   //check player acc balance, and if balance >= quantity * price
            //if yes message should say purchased x shares of y at z $. and subtract z from account balance
            //maybe message under saying new account balance: check account overview for more details
            //else should say insufficient funds: account balance 
            var numShares = quantityInputField.text == ""? 0: int.Parse(quantityInputField.text);
            
            if (dropdown.captionText.text == BUY_MESSAGE)
            {
                //TODO: ADd condition for if balance is eneough between thsese lines of code 
                //TODO: if it is enough, proceed: subtract cost from acc balance, create transaction object, push to history and update stocks owned dict with stock:shares
                
                
                
                //TODO: Add aforementioned code between here 
                
                purchaseMessage.text = $"Successfully PURCHASED {numShares} shares of {this.stockName.text} at ${Math.Round(this.stock.Price,2)} per share ";
                Debug.Log("Total: " + quantityPrice.text);

            }
            //CASE WHERE USER WANTS TO SELL 
            else
            { 
                //TODO: add condition to check if user owns atleast N shares of stock, if so allow sell and add total to acc balance, create transaction, push to history and update owned
                purchaseMessage.text = $"Successfully SOLD {numShares} shares of {this.stockName.text} at ${Math.Round(this.stock.Price,2)} per share \n \n New Account Balance: ";
                
                Debug.Log("Total: " + quantityPrice.text);
                
                    
            }
            Debug.Log(dropdown.captionText.text);
        }
 
        //possibly pop up window 
    }
}