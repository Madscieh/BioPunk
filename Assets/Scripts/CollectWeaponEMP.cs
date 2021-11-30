using BioPunk;
using UnityEngine;

public class CollectWeaponEMP : MonoBehaviour
{
    public GameObject empWeapon;
    public CharacterControl control;

    public void OnTriggerEnter (Collider other)
    {
        control.hasWeaponEMP = true;
        Destroy(gameObject);
    }
}