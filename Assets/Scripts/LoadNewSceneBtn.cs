using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewSceneBtn : MonoBehaviour
{
    public void LoadMainMap()
    {
        SceneManager.LoadScene("TestMap");
    }
    
    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings_Scene");
    }
    
    public void LoadHomepage()
    {
        SceneManager.LoadScene("MainMenu_Scene");
    }
}
