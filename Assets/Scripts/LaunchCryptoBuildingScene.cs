using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class LaunchCryptoBuildingScene : MonoBehaviour
    {
        public void OnClick()
        {
            SceneManager.LoadScene("CryptoBuildingScene");
        }
    }

}