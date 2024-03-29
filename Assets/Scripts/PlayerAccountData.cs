﻿using System;
using System.Collections.Generic;
using TMPro;

namespace DefaultNamespace
{
    [Serializable]
    public class PlayerAccountData
    {
        public string username;
        public Dictionary<string, int> ownedStocks;
        public Dictionary<string, decimal> ownedCrypto;
        //<string (date), decimal(currAccountValue)>
        public Dictionary<string, decimal> accountValueHistory;
        public List<Transaction> transactionHistory;
        public decimal balance;
        public string className;
        public bool firstLogin;
        public PlayerAccountData(string username)
        {
            this.username = username;
            
            ownedStocks = new Dictionary<string, int>();

            ownedCrypto = new Dictionary<string, decimal>();
            
            transactionHistory = new List<Transaction>();
            accountValueHistory = new Dictionary<string, decimal>();
            //default balance and class name 
            balance = 0;
            
            className = "";
            firstLogin = true;
        }


    }
 

}
