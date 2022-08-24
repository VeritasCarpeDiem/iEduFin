using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSceneLoader : MonoBehaviour
{
    public void LoadMainMap()
    {
        SceneManager.LoadScene("TestMap");
        SFXManager.sfxInstance.audio.PlayOneShot(SFXManager.sfxInstance.click);
    }
}
