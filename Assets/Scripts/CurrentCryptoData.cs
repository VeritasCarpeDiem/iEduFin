using UnityEngine;

namespace DefaultNamespace
{
    public class CurrentCryptoData : MonoBehaviour
    {
        public CryptoData crypto { get; set; }
        public string cryptoName { get; set; }

        private void Awake()
        {
            int numcrypto = FindObjectsOfType<CurrentCryptoData>().Length;
            if (numcrypto!= 1)
            {
                Destroy(this.gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}