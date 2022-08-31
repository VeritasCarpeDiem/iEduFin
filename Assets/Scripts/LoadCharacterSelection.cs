using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class LoadCharacterSelection : MonoBehaviour
    {
        public void OnClick()
        {
            SceneManager.LoadScene("CharacterSelection");
        }
    }
}