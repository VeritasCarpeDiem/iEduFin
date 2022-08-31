using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPopupManager : MonoBehaviour
{
    [SerializeField] private GameObject tutPopup;
    private AccountManager accManager;
    private void Start()
    {   
        accManager = GameObject.FindWithTag("AccountManager").GetComponent<AccountManager>();
        //Runs only on player's first login
        if (accManager.playerAccount.firstLogin)
        {
            tutPopup.SetActive(true);
            ShowTut();
            accManager.playerAccount.firstLogin = false;
            accManager.saveData();
        }
        //pop-up is shown only when user has logged in for the first time; controlled through another script
        // tutPopup.SetActive(false);
    }

    public void ShowTut()
    {
        if (tutPopup.activeSelf)
        {
            tutPopup.SetActive(false);
        }
        
        SceneManager.LoadScene("Tutorial_Scene");

    }
    
    public void HideTut()
    {
        if (tutPopup.activeSelf)
        {
            tutPopup.SetActive(false);

        }

    }
    
}
