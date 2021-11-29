using UnityEngine;

public class ProjectileTTL : MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject, 1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
