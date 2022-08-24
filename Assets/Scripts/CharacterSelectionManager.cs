using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionManager : MonoBehaviour
{
    [SerializeField] public GameObject[] characterContents;
    [SerializeField] public GameObject[] buttons;
    
    public void ChangeCharacter(GameObject content)
    {
        content.SetActive(true);

        for (int i = 0; i < characterContents.Length; i++)
        {
            if (characterContents[i] != content)
            {
                characterContents[i].SetActive(false);
            }
        }
    } 
    
    public void ChangeButtonColor(GameObject button)
    {
        button.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i] != button)
                {
                    buttons[i].GetComponent<Image>().color = new Color32(150, 150, 150, 180);
                }
            }
    }
}
