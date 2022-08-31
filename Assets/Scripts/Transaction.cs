using System;
using System.IO;
using UnityEngine.Rendering.VirtualTexturing;



    public class Transaction
    {
        //CHANGE QUANT TO INT 
        //Stock or crypto 
        public string transactionType;
        //buy or sell
        public string action;
        public string itemName;
        public decimal quantity;
        public decimal price;
        public DateTime transactionDate;

        public Transaction(string transactionType,string action, string itemName, decimal quantity, decimal price, DateTime date)
        {
            this.transactionType = transactionType;
            this.itemName = itemName;
            this.quantity = quantity;
            this.price = price;
            this.action = action;
            this.transactionDate = date;
        }
    }
