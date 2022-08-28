using System.Collections;
using System.Collections.Generic;
using System.IO;
// using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Building : MonoBehaviour
{
    public bool firstVisit;
    public string buildingSceneName;
    public string tutorialSceneName;
    
    public Building(string buildingSceneName, string tutorialSceneName )
    {
        this.firstVisit = true;
        this.buildingSceneName = buildingSceneName;
        this.tutorialSceneName = tutorialSceneName;
    }
    //On their first visit to the Building, the User will be shown a tutorial scene for how the building works
    public void Visit()
    {
        if (firstVisit )
        {
            Debug.Log("Starting Tutorial Scene");
            //SceneManager.LoadScene(tutorialSceneName);
            firstVisit = false;
            SceneManager.LoadScene(buildingSceneName);
        }
        else
        {
            Debug.Log("Starting Building Scene");
            SceneManager.LoadScene(buildingSceneName);
        }
       
        
    }
    //Event Trigger will likely be changed based on player movement once implemented
    public void OnMouseDown()
    {
       Visit();
    }
    
    
}
