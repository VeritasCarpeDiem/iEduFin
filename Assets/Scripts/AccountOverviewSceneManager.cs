using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FullSerializer;
using TMPro;
using UnityEngine;
using UnityEngine.Networking.Match;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UI;
using UnityEngine.UIElements;
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
        [SerializeField]private Transform balhistBody;
        [SerializeField]private StockBuilding stockBuilding;
        [SerializeField]private CryptoBuilding cryptoBuilding;
        [SerializeField]private GameObject balcellprefab;
       
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
              buyingPowerField.text = "$" +  String.Format("{0:n}",buyingPower);
              
              accountValue = await CalculateAccountValue();
              await updateAccountBalanceHistory();
              PopulateAccountBalanceHistory();
              Debug.Log("accountValue" + accountValue);
              
              accountValueField.text = "$" + String.Format("{0:n}",Math.Round(accountValue, 2));
              
              await PopulateStocks();
              
              await PopulateCrypto();

              PopulateTradeHistory();
        }

        private async Task PopulateStocks()
        {
            foreach (KeyValuePair<string,int> entry in ownedStocks)
            {
                await stockBuilding.RequestStockQuote(entry.Key);
                var stock = stockBuilding.GetStockQuote();
                Debug.Log(stock.Price);
                var price = Math.Round(stock.Price,2);
               
                GameObject cardObj = Instantiate(cardTemplatePrefab, stockBody);
                var x = cardObj.GetComponent<AOCardData>();
                
                x.nameText.text = stock.Symbol;
                //ts
                x.priceText.text = $"${ String.Format("{0:n}",price)}";
                x.changePercentText.text = stock.ChangePercent;
                //changes color of percent text depending whether it's a gain or loss
                if (x.changePercentText.text.Contains("-"))
                {
                    x.changePercentText.GetComponent<TextMeshProUGUI>().color = new Color32(241,52,0,255);
                }
                x.numShares.text =  $"{entry.Value.ToString()} shares";
                
                float portPercent = (float) ((entry.Value * price)/accountValue);
                x.portfolioPercentText.text = $"{Math.Round(portPercent,2) * 100}% of your portfolio";
                
                cardObj.GetComponent<AOCardData>().p.fillAmount = portPercent; 
                
                Debug.Log( cardObj.GetComponent<AOCardData>().priceText.text);
            }
        }


        private async Task PopulateCrypto()
        {
            foreach (KeyValuePair<string,decimal> entry in ownedCrypto)
            {
                await cryptoBuilding.RequestCryptoQuote(entry.Key);
                var crypto = cryptoBuilding.GetCryptoQuote();
                var price = Math.Round(crypto.Price,2);
               
                GameObject cardObj = Instantiate(cardTemplatePrefab, cryptoBody);
                var x = cardObj.GetComponent<AOCardData>();
                
                x.nameText.text = crypto.Name;
                x.priceText.text = $"${ String.Format("{0:n}",price)}";
                x.changePercentText.text = "";
                //changes color of percent text depending whether it's a gain or loss
                if (x.changePercentText.text.Contains("-"))
                {
                    x.changePercentText.GetComponent<TextMeshProUGUI>().color = new Color32(241,52,0,255);
                }
                x.numShares.text = $"{entry.Value.ToString()} shares";
                
                float portPercent = (float) ((entry.Value * price)/accountValue);
                x.portfolioPercentText.text = $"{Math.Round(portPercent,2) * 100}% of your portfolio";
                cardObj.GetComponent<AOCardData>().p.fillAmount = portPercent; 
               
                Debug.Log( cardObj.GetComponent<AOCardData>().priceText.text);
            }
        }


        private void  PopulateTradeHistory()
        {
            int start = accHistory.Count - 1;
            int count = 0;
            for (int i = start; i >= 0; i--)
            {
                Transaction t = accHistory[i];
                GameObject cellObj = Instantiate(tradeCellPrefab, tradeHistoryBody);
                var panel  = cellObj.GetComponent<TradeHistoryPanel>();
                panel.nameText.text = t.itemName;
                panel.dateText.text = t.transactionDate.ToShortDateString();
                panel.actionText.text = t.action;
                panel.quantityText.text = t.quantity.ToString();
                //changes color of action text depending whether it's buy or sell
                if (panel.actionText.text.Equals("SELL"))
                {
                    panel.actionText.GetComponent<TextMeshProUGUI>().color = new Color32(241,52,0,255);
                }
            }
        }
        
        //TODO: REFACTOR
        private async Task<Decimal> CalculateAccountValue()
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

       private async Task updateAccountBalanceHistory()
       {
           string currDate = DateTime.Now.ToString("yyyy-MM-dd");
           accManager.playerAccount.accountValueHistory[currDate] = accountValue;
           await accManager.saveData();
       }

       private void PopulateAccountBalanceHistory()
       {
           var dates =
               from val in accManager.playerAccount.accountValueHistory.Keys.OrderByDescending(d => DateTime.Parse(d))
               select val;
           
           for (int i = 0; i < dates.Count(); i++)
           {
              
               GameObject cellObj = Instantiate(balcellprefab, balhistBody);
               var panel = cellObj.GetComponent<BalHistPanel>();
               
               if (i == dates.Count() - 1)
               {
                   string currDate = dates.ElementAt(i);
                   panel.dateText.text = currDate;
                   panel.acctValueText.text = "$" + String.Format("{0:n}",Math.Round(accManager.playerAccount.accountValueHistory[currDate],2));
                   panel.changeText.text = "___";
               }
               else
               {
                   string currDate = dates.ElementAt(i);
                   
                   //Because list is in descending order
                   string prevDate = dates.ElementAt(i + 1);
                   decimal accValue = Math.Round(accManager.playerAccount.accountValueHistory[currDate],2);
                   decimal prevDayVal = accManager.playerAccount.accountValueHistory[prevDate];
                   decimal change = Math.Round(accValue - prevDayVal,2);
                   decimal percentChange = Math.Abs(Math.Round(change / accValue,4));

                  
                   panel.dateText.text = currDate;
                   panel.acctValueText.text = "$" + String.Format("{0:n}",accValue);
                   panel.changeText.text = $"${change} ( {percentChange}%)";
                   
                   if (change < 0)
                   {
                       panel.changeText.text = $"${change} ( {percentChange}%)";
                       panel.changeText.color = Color.red;
                   }
               }
     
           }
           
       }
    
    
}
}

