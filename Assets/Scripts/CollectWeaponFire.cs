using BioPunk;
using UnityEngine;

public class CollectWeaponFire : MonoBehaviour
{
    public GameObject fireWeapon;
    public CharacterControl control;

    public void OnTriggerEnter (Collider other)
    {
        control.hasWeaponFire = true;
        Destroy(gameObject);
    }
}
