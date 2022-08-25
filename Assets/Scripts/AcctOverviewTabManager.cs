using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AcctOverviewTabManager : MonoBehaviour
{
    [SerializeField] public GameObject[] tabBodies;
    [SerializeField] public GameObject[] tabs;
    [SerializeField] public GameObject[] buttons; //refers to buttons that are not tabs

    //Each time a tab is clicked, the content of that tab will be shown and the other tab contents will be hidden
    public void OnTabSwitch(GameObject tabBody)
    {
        tabBody.SetActive(true);

        for (int i = 0; i < tabBodies.Length; i++)
        {
            if (tabBodies[i] != tabBody)
            {
                tabBodies[i].SetActive(false);
            }
        }
    } 
    
    //The color of selected tab will change to white, while the other tabs will be grayed out
    //If the "tab" is a button, then the selected & unselected colors will be different (not white/gray)
    public void ChangeTabColor(GameObject tab)
    {
        if (buttons.Contains(tab))
        {
            tab.GetComponent<Image>().color = new Color32(179, 189, 241, 255);
        
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i] != tab)
                {
                    buttons[i].GetComponent<Image>().color = new Color32(128, 135, 176, 255);
                }
            
            }
        }
        else
        {
            tab.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        
            for (int i = 0; i < tabs.Length; i++)
            {
                if (tabs[i] != tab)
                {
                    tabs[i].GetComponent<Image>().color = new Color32(207, 207, 207, 255);
                }
            
            }
        }

    }
}
