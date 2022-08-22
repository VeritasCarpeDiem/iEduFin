using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class launchStockBuildingScene : MonoBehaviour
    {
        public void OnClick()
        {
            SceneManager.LoadScene("StockBuildingScene");

        }
    }
}