using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMapBtn : MonoBehaviour
{
    public void LoadMainMap()
    {
        SceneManager.LoadScene("TestMap2");
    }
}
