using UnityEngine;
using UnityEngine.SceneManagement;

namespace BioPunk
{
    public class LoadNextScene : MonoBehaviour
    {
        public int sceneNumber;
        private void OnTriggerEnter()
        {
            SceneManager.LoadScene(sceneNumber);
        }
    }
}