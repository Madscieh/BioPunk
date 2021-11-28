using BioPunk;
using UnityEngine;

public class CollectWeaponBasic : MonoBehaviour
{
    public GameObject basicWeapon;
    public CharacterControl control;

    public void OnTriggerEnter (Collider other)
    {
        control.hasWeaponBasic = true;
        Destroy(gameObject);
    }
}
