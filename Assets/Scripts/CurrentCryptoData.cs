using UnityEngine;

namespace DefaultNamespace
{
    public class CurrentCryptoData : MonoBehaviour
    {
        public CryptoData crypto { get; set; }
        public string cryptoName { get; set; }

        private void Start()
        {
            DontDestroyOnLoad(this);
        }
    }
}