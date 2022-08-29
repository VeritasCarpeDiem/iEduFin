using System;

namespace DefaultNamespace
{
    public partial class CryptoRequest
    {
        public CryptoData CryptoData { get; set; }
    }

    public partial class CryptoData
    {
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public Decimal Volume { get; set; }
        public Decimal MarketCap { get; set; }
    }
}

