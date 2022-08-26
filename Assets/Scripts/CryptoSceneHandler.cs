using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class CryptoSceneHandler : MonoBehaviour
    {
        private string[] CryptoToDisplay =  { "BTC", "BNB","TRX","DOGE","ETH","SOL","ADA","XRP","LTC", "LINK","FIL"};
        public CryptoBuilding cryptoBuilding;

        [SerializeField] private GameObject cryptoTextPrefab;
        [SerializeField] private Transform cryptoTextParent;

        private CryptoData currCrypto;
        
        [SerializeField]  TMP_InputField enterCryptoSearch;
        [SerializeField] public TextMeshProUGUI  warningText;
        
        void  Start()
        {
           cryptoBuilding = GameObject.FindWithTag("CryptoBuilding").GetComponent<CryptoBuilding>();
            DisplayCrypto();


        }

        async void DisplayCrypto()
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    Debug.Log(CryptoToDisplay[i] + i);
                    await cryptoBuilding.RequestCryptoQuote(this.CryptoToDisplay[i]);
                    CryptoData c = cryptoBuilding.GetCryptoQuote();

                    GameObject cryptoTextObj = Instantiate(cryptoTextPrefab, cryptoTextParent);
                    
                    cryptoTextObj.GetComponent<CryptoViewContainer>().crypto = c;
                    cryptoTextObj.GetComponent<CryptoViewContainer>().cryptoText.text = c.Name;
                    
                    Decimal roundedVolume =  Math.Round(c.Volume, 2);
                    Decimal roundedPrice = Math.Round(c.Price, 2);
                    cryptoTextObj.GetComponent<CryptoViewContainer>().priceText.text = "$" + roundedPrice;
                    cryptoTextObj.GetComponent<CryptoViewContainer>().volumeText.text = "$" + roundedVolume;

                }
                catch (Exception e)
                {
                    warningText.text =
                        "ERROR:Could not connect to server, please check internet connection. Exit building and try again.";
                    Debug.Log(e);
                    return;
                }
            }
        }
        
        
        
        
        
        
    }
}