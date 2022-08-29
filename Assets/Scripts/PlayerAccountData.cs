using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    [Serializable]
    public class PlayerAccountData
    {
        public string username;
        public Dictionary<string, int> ownedStocks;
        public Dictionary<string, decimal> ownedCrypto;
        public List<Transaction> transactionHistory;
        public decimal balance;
        public string className;
 
        public PlayerAccountData(string username)
        {
            this.username = username;
            
            ownedStocks = new Dictionary<string, int>();

            ownedCrypto = new Dictionary<string, decimal>();
            
            transactionHistory = new List<Transaction>();
            //default balance and class name 
            balance = 0;
            
            className = "";
        }


    }
 

}
