using System;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

namespace DefaultNamespace
{
    public class LetsInvestBtn : MonoBehaviour
    {
        private AccountManager accManager;
        private PlayerAccountData playerAccount;

        private void Start()
        {
            accManager =  GameObject.FindWithTag("AccountManager").GetComponent<AccountManager>();
            playerAccount =accManager.playerAccount;
        }

        public async void onClick()
        {
            switch(playerAccount.className)
            {
                case "Racoon":
                    playerAccount.balance = 1000;
                    break;
                
                case "Alumni":
                    playerAccount.balance = 10000;
                    break;
                
                case "Khosla":
                    playerAccount.balance = 50000;
                    break;
                
                //means user didnt change from raccoon, on char selection
                default:
                    playerAccount.balance = 1000;
                    playerAccount.className = "Racoon";
                    break;
            }

            await accManager.saveData();
            SceneManager.LoadScene("MapTest3");
        }
    }
}