using System;
using UnityEngine;
using UnityEngine.SceneManagement;



    public class launchcreateacc : MonoBehaviour
    {
        public void OnMouseDown()
        {
            Debug.Log("clicked");
            SceneManager.LoadScene("CreateAccountScene");
        }
    }
