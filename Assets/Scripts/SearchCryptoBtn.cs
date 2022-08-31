using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class SearchCryptoBtn : MonoBehaviour
    {
        public CryptoBuilding cryptoBuilding;
        public TMPro.TMP_InputField cryptoInput;
        private CurrentCryptoData currentCryptoObject;

        private void Start()
        {
            currentCryptoObject = GameObject.FindWithTag("CurrCrypto").GetComponent<CurrentCryptoData>();
        }

        public async void OnClick()
        {
            if (cryptoInput.text == "")
            {
                Debug.Log("Crypto field is empty");
            }

            Debug.Log("clicked");
            
            string symbol = this.cryptoInput.text;
            Debug.Log(symbol);
            
            await cryptoBuilding.RequestCryptoQuote(symbol);

            var crypto = cryptoBuilding.GetCryptoQuote();
            Debug.Log(crypto.Name);
            
            if (crypto != null)
            {
                currentCryptoObject.crypto = crypto;
                SceneManager.LoadScene("CryptoDataScene");
            }
        }
    }
}