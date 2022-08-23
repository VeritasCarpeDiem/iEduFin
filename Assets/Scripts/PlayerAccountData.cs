using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    [Serializable]
    public class PlayerAccountData
    {
        //equivalent to Gameaccount _id
        // private string playerID;
        // private string email;
        public string username;
        public Dictionary<string, int> ownedStocks;
        public Dictionary<string, int> ownedCrypto;
        public List<Transaction> transactionHistory;
        public decimal balance;
        //maybe add characterName : string and characterAlreadySelected: bool field?
        public PlayerAccountData(string username)
        {
            this.username = username;
            ownedStocks = new Dictionary<string, int>();
            // ownedStocks.Add("aapl",1);
            ownedCrypto = new Dictionary<string, int>();
            transactionHistory = new List<Transaction>();
            balance = 10000;
        }

        // public PlayerAccountData(string username, Dictionary<string, int> ownedStocks,Dictionary<string, int> ownedCrypto, List<Transaction> transactionHistory,decimal balance)
        // {
        //     this.username = username;
        //     this.dictionary
        // } 
    }
 
    //first constructor sets up a defualt item w/ _id from playeraccount
}
//could potentially post as jsondata: all json data in string format
//then in javascript backend, after retrieving data, construct new object based on data inside nested object and send that.