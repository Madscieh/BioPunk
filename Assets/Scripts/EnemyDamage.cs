using System.Collections;
using UnityEngine;

namespace BioPunk
{
    public class EnemyDamage : MonoBehaviour
    {
        public Animator animator;
        public int maxHealth = 100;
        public int currentHealth = 100;

        public HealthBar healthBar;

        private void Start()
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        public void OnTriggerEnter(Collider other)
        {
            if (currentHealth > 0)
            {
                if (other.gameObject.CompareTag("Projectile")) StartCoroutine(nameof(Damage));
            }
            else
            {
                animator.SetBool("EnemyDeath", true);
            }
        }

        private IEnumerator Damage()
        {
            animator.SetBool("Damage", true);
            yield return new WaitForSeconds(.2f);
            currentHealth--;
            healthBar.SetHealth(currentHealth);
            animator.SetBool("Damage", false);
        }
    }
}
