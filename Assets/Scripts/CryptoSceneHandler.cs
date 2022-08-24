using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class CryptoSceneHandler : MonoBehaviour
    {
        private string[] CryptoToDisplay =  { "BTC", "ETH","SOL","ADA","XRP" };
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
                    await cryptoBuilding.RequestCryptoQuote(this.CryptoToDisplay[i]);
                    CryptoData c = cryptoBuilding.GetCryptoQuote();

                    GameObject cryptoTextObj = Instantiate(cryptoTextPrefab, cryptoTextParent);
                }
                catch (Exception e)
                {
                    warningText.text =
                        "ERROR:Could not connect to server, please check internet connection. Exit building and try again.";
                    return;
                }
            }
        }
        
        
        
        
        
        
    }
}