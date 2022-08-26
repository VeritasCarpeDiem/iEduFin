using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CurrentStockData : MonoBehaviour
    {
        public StockQuote stock {  get; set; }
        public string stockName { get; set; }
        private void Awake()
        {
            int numstocks = FindObjectsOfType<CurrentStockData>().Length;
            if (numstocks!= 1)
            {
                Destroy(this.gameObject);
            }
            // if more then one music player is in the scene
            //destroy ourselves
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}