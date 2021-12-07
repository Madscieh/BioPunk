using UnityEngine;

namespace BioPunk
{
    public enum TransitionParameter
    {
        isRunning,
        isJumping,
        isGrounded,
        isAgainstWall,
        Attack,
        meleeWeapon,
        fireWeapon,
        basicWeapon,
        empWeapon,
    }

    public class CharacterControl : MonoBehaviour
    {
        public Animator Animator;
        public new AudioSource audio;

        public Transform fireTransform;
        private new Rigidbody rigidbody;
        public Rigidbody Rigidbody
        {
            get
            {
                if (rigidbody == null) rigidbody = GetComponent<Rigidbody>();
                return rigidbody;
            }
        }

        public int maxHealth;
        public int currentHealth;
        public HealthBar healthBar;

        public bool MoveRight;
        public bool MoveLeft;
        public bool Jump;
        public bool Attack;

        public GameObject fireWeapon;
        public GameObject basicWeapon;
        public GameObject empWeapon;

        public ParticleSystem basic;
        public ParticleSystem flames;
        public ParticleSystem emp;
        public ParticleSystem laser;

        public bool weaponMelee;
        public bool weaponFire;
        public bool weaponBasic;
        public bool weaponEMP;

        public bool hasWeaponFire;
        public bool hasWeaponBasic;
        public bool hasWeaponEMP;
    }
}
