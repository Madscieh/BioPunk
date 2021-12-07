using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace BioPunk
{
    public class BackgroundMenu : MonoBehaviour
    {
        public RawImage background;
        public Texture[] backgroundImages;

        private void Start()
        {
            background = GetComponent<RawImage>();
            StartCoroutine(nameof(Background));
        }

        private IEnumerator Background()
        {
            while (true)
            {
                foreach (var texture in backgroundImages)
                {
                    yield return new WaitForSeconds(.04f);
                    background.texture = texture;
                }
            }
        }
    }
}