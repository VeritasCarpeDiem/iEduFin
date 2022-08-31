using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialSlideManager : MonoBehaviour
{
    [SerializeField] private GameObject exitBtn;
    [SerializeField] private GameObject[] slides;

    public void ChangeSlide(GameObject newSlide)
    {
        newSlide.SetActive(true);
        
        for (int i = 0; i < slides.Length; i++)
        {
            if (slides[i] != newSlide)
            {
                slides[i].SetActive(false);
            }
        }
    }

    public void ExitTutorial()
    {
        //Add code to load main map
    }
}
