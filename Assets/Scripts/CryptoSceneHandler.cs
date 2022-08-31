using System;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

namespace DefaultNamespace
{
    public class CryptoSceneHandler : MonoBehaviour
    {
        private string[] CryptoToDisplay;
        public CryptoBuilding cryptoBuilding;
        private CryptoData currCrypto;
        
        [SerializeField] private GameObject cryptoTextPrefab;
        [SerializeField] private Transform cryptoTextParent;
        [SerializeField]  TMP_InputField enterCryptoSearch;
        [SerializeField] public TextMeshProUGUI  warningText;
        
        void  Start()
        {
            // string path = Application.dataPath + "/StockAndCryptoData/CryptoData.txt";
            string path = Application.streamingAssetsPath + "/stockcryptodata/CryptoData.txt";
            var data = System.IO.File.ReadAllText(path);
            CryptoToDisplay = data.Split(",");
            
            cryptoBuilding = GameObject.FindWithTag("CryptoBuilding").GetComponent<CryptoBuilding>();
           
            DisplayCrypto();
        }

        async void DisplayCrypto()
        {
            for (int i = 0; i < CryptoToDisplay.Length; i++)
            {
                try
                {
                    Debug.Log(CryptoToDisplay[i] + i);
                    
                    await cryptoBuilding.RequestCryptoQuote(this.CryptoToDisplay[i]);
                    CryptoData c = cryptoBuilding.GetCryptoQuote();

                    if (c != null)
                    {
                        GameObject cryptoTextObj = Instantiate(cryptoTextPrefab, cryptoTextParent);

                        cryptoTextObj.GetComponent<CryptoViewContainer>().crypto = c;
                        cryptoTextObj.GetComponent<CryptoViewContainer>().cryptoText.text = c.Name;

                        Decimal roundedVolume = Math.Round(c.Volume, 2);
                        Decimal roundedPrice = Math.Round(c.Price, 2);

                        cryptoTextObj.GetComponent<CryptoViewContainer>().priceText.text = "$" + roundedPrice;
                        cryptoTextObj.GetComponent<CryptoViewContainer>().volumeText.text = "$" + roundedVolume;
                    }
                }
                catch (Exception e)
                {
                    warningText.text =
                        "ERROR:Could not connect to server, please check internet connection. Exit building and try again.";
                    Debug.Log(e);
                    //to avoid crashing game during scene?
                    return;
                }
            }
        }
        
        
        
        
        
        
    }
}