using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangeBgScreen : MonoBehaviour
{
    [SerializeField] private List<GameObject> backgrounds;
    [SerializeField] private List<GameObject> defaultBgScreens;
    [SerializeField] private List<GameObject> displayBgScreens;
    [SerializeField] private List<GameObject> displayAltBgScreens;

    public void SetScreen(GameObject newScreen)
    {
        //find and deactivate current screen game object
        GameObject[] activeScreens;
        activeScreens = GameObject.FindGameObjectsWithTag("Parent");
        foreach (GameObject screen in activeScreens)
        {
            screen.SetActive(false);
        }
        
        //Default BG is element 0, display area BG = 1, display area alt BG = 2
        if (defaultBgScreens.Contains(newScreen))
        {
            SetBackground(0);
        }
        else if (displayBgScreens.Contains(newScreen))
        {
            SetBackground(1);
        }
        else
        {
            SetBackground(2);
        }
        
        newScreen.SetActive(true);
    }

    private void SetBackground(int index)
    {
        for (int i = 0; i < backgrounds.Count; i++)
        {
            if (i != index)
            {
                backgrounds[i].SetActive(false);
            }
            else
            {
                backgrounds[i].SetActive(true);
            }
        }
    }
}
