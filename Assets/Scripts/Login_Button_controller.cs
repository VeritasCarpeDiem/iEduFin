using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login_Button_controller : MonoBehaviour
{

    public void clicked()
    {
        SceneManager.LoadScene(5);
    }
}
