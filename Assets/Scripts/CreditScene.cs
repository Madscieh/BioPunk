using UnityEngine;
using UnityEngine.SceneManagement;

namespace BioPunk
{
    public class CreditScene : MonoBehaviour
    {
        public void Start()
        {
            Invoke(nameof(Menu), 3f);
        }

        public void Menu()
        {
            SceneManager.LoadScene(0);
        }
    }
}