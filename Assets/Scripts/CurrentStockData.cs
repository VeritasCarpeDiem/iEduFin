using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CurrentStockData : MonoBehaviour
    {
        public StockQuote stock {  get; set; }
        public string stockName { get; set; }
        private void Start()
        {
            DontDestroyOnLoad(this);
        }
    }
}