using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class CryptoViewContainer : MonoBehaviour
    {
        [SerializeField] public TextMeshProUGUI cryptoText;
        [SerializeField] public TextMeshProUGUI  priceText;
        [SerializeField] public TextMeshProUGUI  volumeText;
        //add reference to current stoock data object? 
        public CurrentCryptoData currentCryptoObject;
        public CryptoData crypto { get; set; }

        public void Start()
        {
            currentCryptoObject = GameObject.FindWithTag("CurrCrypto").GetComponent<CurrentCryptoData>();
        }

        public void click()
        {
            currentCryptoObject.crypto = this.crypto;
            SceneManager.LoadScene("CryptoDataScene");
            Debug.Log("DISPLAYING STOCK");
            // Debug.Log(cryptoText.text);
            // Debug.Log(volumeText.text);
            // Debug.Log(priceText.text);
            Debug.Log(crypto.Name);
        }
        
        
    }
}