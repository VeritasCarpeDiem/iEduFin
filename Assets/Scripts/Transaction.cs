using System;
using System.IO;
using UnityEditor.MPE;
using UnityEngine.Rendering.VirtualTexturing;



    public class Transaction
    {
        //Stock or crypto 
        private string transactionType;
        //buy or sell
        private string action;
        private string itemName;
        private int quantity;
        private decimal price;
        private DateTime transactionDate;

        public Transaction(string transactionType,string action, string itemName, int quantity, decimal price, DateTime date)
        {
            this.transactionType = transactionType;
            this.itemName = itemName;
            this.quantity = quantity;
            this.price = price;
            this.transactionDate = date;
        }
    }
