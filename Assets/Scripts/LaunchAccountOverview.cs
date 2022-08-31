using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class LaunchAccountOverview : MonoBehaviour
    {
        public void OnMouseDown()
        {
            Debug.Log("clicked");
            SceneManager.LoadScene("AccountOverview_Scene");
        }
    }
}