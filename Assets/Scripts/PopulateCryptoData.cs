using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class PopulateCryptoData : MonoBehaviour
    {
        private const string MAX_QUANTITY = "999";
        private const string DEFAULT_PRICE = "$0.00";
        const string BUY_MESSAGE = "BUY";
        
        [SerializeField]  TMP_Dropdown dropdown;
        [SerializeField] private TextMeshProUGUI quantityPrice;
        
        [SerializeField] private TMP_InputField quantityInputField;
        [SerializeField]  TextMeshProUGUI cryptoTextLeft;
        [SerializeField]  TextMeshProUGUI cryptoName;
        [SerializeField]  TextMeshProUGUI volumeText;
        [SerializeField]  TextMeshProUGUI priceText;
        [SerializeField]  TextMeshProUGUI purchaseMessage;
        
        private CurrentCryptoData currCrypto;
        private AccountManager accManager;
        private CryptoData crypto;
        private PlayerAccountData playerAccount;

        private void Start()
        {
            currCrypto = GameObject.FindWithTag("CurrCrypto").GetComponent<CurrentCryptoData>();
            accManager = GameObject.FindWithTag("AccountManager").GetComponent<AccountManager>();
            Debug.Log(currCrypto.crypto.Name);
            this.crypto = currCrypto.crypto;
          
            cryptoTextLeft.text = crypto.Name;
            populateUI();
            accManager.OnDeserialize();

        }

        void populateUI()
        {
            this.cryptoName.text = crypto.Name;
            this.priceText.text = String.Format("{0:n}","$" + Math.Round(crypto.Price, 2));
            this.volumeText.text = "$" + Math.Round(crypto.Volume, 2);
            
            quantityInputField.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        }
        //TODO: Convert this into a switch statement/reduce 
        public void ValueChangeCheck()
        {
            decimal quantval;
            bool success = decimal.TryParse(quantityInputField.text,out quantval);

            if (quantityInputField.text == "")
            {
                Debug.Log("EMPTY!");
                //quantityInputField.text = "";
                quantityPrice.text = DEFAULT_PRICE;
            }
            else if (quantityInputField.text == "-")
            {
                quantityInputField.text = "";
            }
            else if (quantityInputField.text == ".")
            {
                Debug.Log("EMPTY!");
                //quantityInputField.text = "";
                quantityInputField.text = "0. ";
            }
            else if (!success)
            {
                purchaseMessage.text = "Please enter a valid input";
            }
            else if (decimal.Parse(quantityInputField.text) > (int.Parse(MAX_QUANTITY))) 
            {
                quantityInputField.text = MAX_QUANTITY;
            }
            else
            {
                decimal currCryptoPrice = Convert.ToDecimal(priceText.text.Trim('$'));
                quantityPrice.text = "$" +  String.Format("{0:n}",Math.Round((decimal.Parse(quantityInputField.text) * currCryptoPrice), 2));
            }

        }

        public async void OnSubmit()
        {
            decimal currBalance = accManager.playerAccount.balance;
            decimal numShares = quantityInputField.text == "" ? 0 : decimal.Parse(quantityInputField.text);
            decimal sellPrice = Math.Round(this.crypto.Price, 2);
            string itemName = this.cryptoName.text;
            string action = "BUY";
            string transactionType = "CRYPTO";
            DateTime currDate = DateTime.Now;
            
            if (numShares == 0)
            {
                return;
            }
            if (dropdown.captionText.text == BUY_MESSAGE)
            {
                if (currBalance >= numShares * sellPrice)
                {
                    action = "BUY";
                    accManager.playerAccount.balance -= sellPrice * numShares;
                    if (accManager.playerAccount.ownedCrypto.ContainsKey(itemName))
                    {
                        accManager.playerAccount.ownedCrypto[itemName] += numShares;
                    }
                    else
                    {
                        accManager.playerAccount.ownedCrypto[itemName] = numShares;
                    }
                }
                //failed purchase
                else
                {
                    Debug.Log(accManager.playerAccount.username);
                    purchaseMessage.text =
                        $"Insufficient funds \n Current Balance: ${Math.Round(accManager.playerAccount.balance,2)}";
                    return;
                }
                purchaseMessage.text = $"Successfully PURCHASED {numShares} shares of {this.cryptoName.text} at ${sellPrice} per share \n New Balance: ${ String.Format("{0:n}",Math.Round(accManager.playerAccount.balance,2))}";
            }
            //case where user wants to sell
            else
            {
                action = "SELL";
                decimal numOwned;
                var checkOwned = accManager.playerAccount.ownedCrypto.TryGetValue(cryptoName.text, out numOwned);

                if (numOwned >= numShares)
                {
                    decimal balanceToAdd = numShares * sellPrice;
                    if (numShares == numOwned)
                    {
                        accManager.playerAccount.ownedCrypto.Remove(cryptoName.text);
                    }
                    else
                    {
                        accManager.playerAccount.ownedCrypto[cryptoName.text] -= numShares;
                    }
                    accManager.playerAccount.balance += balanceToAdd;
                    purchaseMessage.text = $"Successfully SOLD {numShares} shares of {this.cryptoName.text} at ${sellPrice} per share \n New Balance: ${ String.Format("{0:n}",Math.Round(accManager.playerAccount.balance,2))}";
                }
                else
                {
                    purchaseMessage.text =
                        $"CANNOT COMPLETE ACTION! \n you only own {numOwned} shares of {cryptoName.text} \n Current Balance: ${ String.Format("{0:n}",Math.Round(accManager.playerAccount.balance,2))}";
                    return;
                }

            }


            accManager.OnDeserialize();
            Transaction t = new Transaction(transactionType, action, itemName, numShares, sellPrice, currDate);
            //purchaseMessage.text = $"Successfully PURCHASED {numShares} shares of {this.cryptoName.text} at ${sellPrice} per share \n New Balance: ${accManager.playerAccount.balance}";
            accManager.playerAccount.transactionHistory.Add(t);
            await accManager.saveData();
            Debug.Log("Total: " + quantityPrice.text);
            Debug.Log(dropdown.captionText.text);
        }

    }
}