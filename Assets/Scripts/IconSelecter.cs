using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class IconSelecter : MonoBehaviour
    {
        [SerializeField] private GameObject racoonIcon;
        [SerializeField] private GameObject alumniIcon;
        [SerializeField] private GameObject khoslaIcon;
        [SerializeField] private PlayerAccountData playerAcc;

        private void Start()
        {
            playerAcc = GameObject.FindWithTag("AccountManager").GetComponent<AccountManager>().playerAccount;
            switch (playerAcc.className)
            {
                case "Racoon":
                    racoonIcon.SetActive(true);
                    break;
                case "Alumni":
                    alumniIcon.SetActive(true);
                    break;
                case "Khosla":
                    khoslaIcon.SetActive(true);
                    break;
            }
        }
    }
}