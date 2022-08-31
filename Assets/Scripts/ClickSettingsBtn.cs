using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickSettingsBtn : MonoBehaviour
{
    public bool toMap;
    
    public void loadSettings()
    {
        if (toMap)
        {
            Setting_Button_controller.instance.backToMap = true;
            Debug.Log(Setting_Button_controller.instance.backToMap);
        }
        else
        {
            Setting_Button_controller.instance.backToMap = false;
            Debug.Log(Setting_Button_controller.instance.backToMap);
        }
        
        SceneManager.LoadScene("Settings_Scene");
    }

    public void settingsBack()
    {
        if (Setting_Button_controller.instance.backToMap)
        {
            Debug.Log(Setting_Button_controller.instance.backToMap);
            SceneManager.LoadScene("MainMap_Scene");
        }
        else
        {
            Debug.Log(Setting_Button_controller.instance.backToMap);
            SceneManager.LoadScene("MainMenu_Scene");
        }
    }
}
