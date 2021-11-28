using UnityEngine;

public class ProjectileTTL : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 2f);
    }
}
