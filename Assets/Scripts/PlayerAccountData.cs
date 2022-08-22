using System.Collections.Generic;

namespace DefaultNamespace
{
    public class PlayerAccountData
    {
        //equivalent to Gameaccount _id
        private string playerID;
        private string email;
        private Dictionary<string, int> ownedStocks;
        private Dictionary<string, int> ownedCrypto;
        private List<Transaction> transactionHistory;
        private decimal balance;
        
    }
    //first constructor sets up a defualt item w/ _id from playeraccount
}