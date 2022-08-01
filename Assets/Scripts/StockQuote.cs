using System;
using Newtonsoft.Json;

        public partial class QuoteRequest
        {
            [JsonProperty("Global Quote")]
            public StockQuote StockQuote { get; set; }
        }

        public partial class StockQuote
        {
            [JsonProperty("01. symbol")]
            public string Symbol { get; set; }

            [JsonProperty("02. open")]
            public decimal Open { get; set; }

            [JsonProperty("03. high")]
            public decimal High { get; set; }

            [JsonProperty("04. low")]
            public decimal Low { get; set; }

            [JsonProperty("05. price")]
            public decimal Price { get; set; }

            [JsonProperty("06. volume")]
            public decimal Volume { get; set; }

            [JsonProperty("07. latest trading day")]
            public DateTimeOffset LatestTradingDay { get; set; }

            [JsonProperty("08. previous close")]
            public string PreviousClose { get; set; }

            [JsonProperty("09. change")]
            public decimal Change { get; set; }

            [JsonProperty("10. change percent")]
            public string ChangePercent { get; set; }
        }
    
