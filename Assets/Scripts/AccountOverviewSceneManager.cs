﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

namespace DefaultNamespace
{
    
    public class AccountOverviewSceneManager : MonoBehaviour
    {
        //references to relevant objects in scene 
        [SerializeField] private TextMeshProUGUI buyingPowerField;
        [SerializeField] private TextMeshProUGUI accountValueField;
        [SerializeField] private GameObject cardTemplatePrefab;
        [SerializeField] private GameObject tradeCellPrefab;
        [SerializeField] private Transform stockBody;
        [SerializeField]private Transform cryptoBody;
        [SerializeField]private Transform tradeHistoryBody;
        [SerializeField]private StockBuilding stockBuilding;
        [SerializeField]private CryptoBuilding cryptoBuilding;
        
        private AccountManager accManager;
        private PlayerAccountData playerData;
        private Dictionary<string, decimal> ownedCrypto;
        private decimal buyingPower;
        private decimal accountValue;
        private Dictionary<string, int> ownedStocks;
        private decimal accountBuyingPower;
        private List<Transaction> accHistory;
        
        private async void Start()
        {
              accManager = GameObject.FindWithTag("AccountManager").GetComponent<AccountManager>();
              playerData = accManager.playerAccount;
              ownedStocks = playerData.ownedStocks;
              ownedCrypto = playerData.ownedCrypto;
              accHistory = playerData.transactionHistory;
              
              buyingPower = Math.Round(playerData.balance,2);
              buyingPowerField.text = "$" + buyingPower.ToString();
              
              accountValue = await CalculateAccountValue();
              Debug.Log("accountValue" + accountValue);
              
              accountValueField.text = "$" + Math.Round(accountValue, 2).ToString();
              
              await PopulateStocks();
              
              await PopulateCrypto();

              await PopulateTradeHistory();
        }

        public async Task PopulateStocks()
        {
            foreach (KeyValuePair<string,int> entry in ownedStocks)
            {
                await stockBuilding.RequestStockQuote(entry.Key);
                var stock = stockBuilding.GetStockQuote();
                var price = Math.Round(stock.Price,2);
               
                GameObject cardObj = Instantiate(cardTemplatePrefab, stockBody);
                var x = cardObj.GetComponent<AOCardData>();
                
                x.nameText.text = stock.Symbol;
                x.priceText.text = $"${price.ToString()}";
                x.changePercentText.text = stock.ChangePercent;
                //changes color of percent text depending whether it's a gain or loss
                if (x.changePercentText.text.Contains("-"))
                {
                    x.changePercentText.GetComponent<TextMeshProUGUI>().color = new Color32(241,52,0,255);
                }
                x.numShares.text =  $"{entry.Value.ToString()} shares";
                
                float portPercent = (float) ((entry.Value * price)/accountValue);
                x.portfolioPercentText.text = $"{Math.Round(portPercent,2)}% of your portfolio";
                
                cardObj.GetComponent<AOCardData>().p.fillAmount = portPercent; 
                
                Debug.Log( cardObj.GetComponent<AOCardData>().priceText.text);
                Debug.Log("j");
            }
        }


        public async Task PopulateCrypto()
        {
            foreach (KeyValuePair<string,decimal> entry in ownedCrypto)
            {
                await cryptoBuilding.RequestCryptoQuote(entry.Key);
                var crypto = cryptoBuilding.GetCryptoQuote();
                var price = Math.Round(crypto.Price,2);
               
                GameObject cardObj = Instantiate(cardTemplatePrefab, cryptoBody);
                var x = cardObj.GetComponent<AOCardData>();
                
                x.nameText.text = crypto.Name;
                x.priceText.text = $"${price.ToString()}";
                x.changePercentText.text = "";
                x.numShares.text = $"{entry.Value.ToString()} shares";
                
                float portPercent = (float) ((entry.Value * price)/accountValue);
                x.portfolioPercentText.text = $"{Math.Round(portPercent,2)}% of your portfolio";
                cardObj.GetComponent<AOCardData>().p.fillAmount = portPercent; 
               
                Debug.Log( cardObj.GetComponent<AOCardData>().priceText.text);
                Debug.Log("j");
            }
        }
        

        public async Task PopulateTradeHistory()
        {
            int start = accHistory.Count - 1;
            for (int i = start; i >= 0; i--)
            {
                Transaction t = accHistory[i];
                GameObject cellObj = Instantiate(tradeCellPrefab, tradeHistoryBody);
                var panel  = cellObj.GetComponent<TradeHistoryPanel>();
                panel.nameText.text = t.itemName;
                panel.dateText.text = t.transactionDate.ToShortDateString();
                panel.actionText.text = t.action;
                //changes color of action text depending whether it's buy or sell
                if (panel.actionText.text.Equals("SELL"))
                {
                    panel.actionText.GetComponent<TextMeshProUGUI>().color = new Color32(241,52,0,255);
                }
            }
            // foreach (Transaction t in this.accHistory)
            // {
            //     GameObject cellObj = Instantiate(tradeCellPrefab, tradeHistoryBody);
            //     var panel  = cellObj.GetComponent<TradeHistoryPanel>();
            //     panel.nameText.text = t.itemName;
            //     panel.dateText.text = t.transactionDate.ToShortDateString();
            //     panel.actionText.text = t.action;
            // }
        }
        //possibly remove/refactor depending on performance (needed for percent of shares accountvalue)
        //TODO: REFACTOR
       public async Task<Decimal> CalculateAccountValue()
       {
           decimal accValue = buyingPower;
           //loop through each k,v pair of stocks and add them up to calculate account value (key = stock, value = numshares)
           foreach (KeyValuePair<string, int> entry in ownedStocks)
           {
               await stockBuilding.RequestStockQuote(entry.Key);
               var stock = stockBuilding.GetStockQuote();

               accValue += stock.Price * entry.Value;
           }
           //loop through each k,v pair of crypto and add them up to calculate account value 
           foreach (KeyValuePair<string, decimal> entry in ownedCrypto)
           {
               await cryptoBuilding.RequestCryptoQuote(entry.Key);
               var crypto = cryptoBuilding.GetCryptoQuote();
               accValue += crypto.Price * entry.Value;
           }

           return accValue;
       }
       

        //get isntance of a card and copy/ edit each card for owned stock and do same for crypto 
    
    
}
}

