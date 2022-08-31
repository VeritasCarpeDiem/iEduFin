using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class LaunchInfoBooth : MonoBehaviour
    {
      public void  OnClick()
       {
           SceneManager.LoadScene("(New)InfoBooth_Scene");
       }
    }
}