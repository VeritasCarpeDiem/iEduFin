using UnityEngine;
using System;
using FullSerializer;
using Newtonsoft.Json;

    [System.Serializable]
    public class Stock {
        public string symbol { get; set; }
        public decimal open { get; set; }
        public decimal high { get; set; }
        public decimal low { get; set; }
        public decimal volume { get; set; }
        // [JsonProperty( "latest trading day")]
        // public DateTime latestTradingDay { get; set; }
        // [JsonProperty( "previous close")]
        // public decimal previousClose { get; set; }
        public decimal change { get; set; }
        // [JsonProperty( "change percent")]
        // public decimal changePercent { get; set; }
    }




 

