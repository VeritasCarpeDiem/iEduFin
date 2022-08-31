using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickCrypto : MonoBehaviour
{
    
    //private bool isBeingHeld = false; 

    //void Update()
    //{
        //Vector3 mousePos; 
        //mousePos = Input.mousePosition; 
        //mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        //if (isBeingHeld == true)
        //{
            //SceneManager.LoadScene("CryptoBuildingScene"); 
        //}
        
    //}

    public void OnMouseDown()
    {

        SceneManager.LoadScene("CryptoBuildingScene"); 


        //if (Input.GetMouseButtonDown(0))
        //{

           // Vector3 mousePos; //creating vector3
           // mousePos = Input.mousePosition; //set value of mousePos to mouse position on screen
           // mousePos = Camera.main.ScreenToWorldPoint(mousePos); //convert screen point of mouse to endgame point

           // isBeingHeld = true;
        //}


    }

    //private void OnMouseUp()
    //{

        //isBeingHeld = false; 
   // }



    //private void cryptoclick()
    //{
    //SceneManager.LoadScene ("CryptoBuildingScene"); 
    //}


}