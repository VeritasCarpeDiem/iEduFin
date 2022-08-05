using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcctOverviewTabManager : MonoBehaviour
{
    [SerializeField] public GameObject[] tabBodies;
    [SerializeField] public GameObject[] tabs;

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
    
    public void ChangeTabColor(GameObject tab)
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
