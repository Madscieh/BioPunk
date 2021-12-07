using UnityEngine;
using UnityEngine.SceneManagement;

namespace BioPunk
{
    public class GameOver : MonoBehaviour
    {
        public void Continue()
        {
            SceneManager.LoadScene(0);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}