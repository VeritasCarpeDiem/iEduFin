using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMiniMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    private void Start()
    {
        menu.SetActive(false);
    }

    public void ShowMenu()
    {
        if (!menu.activeSelf)
        {
            Debug.Log("menu is not active");
            menu.SetActive(true);
            Debug.Log("menu is now active");
        }
        else
        {
            Debug.Log("menu is already active");
            menu.SetActive(false);
            Debug.Log("menu is now inactive");
        }
        
        
    }
}
