using UnityEngine;

namespace BioPunk
{
    public class Billboard : MonoBehaviour
    {
        public new Transform camera;

        public void LateUpdate()
        {
            transform.LookAt(transform.position + camera.forward);
        }
    }
}