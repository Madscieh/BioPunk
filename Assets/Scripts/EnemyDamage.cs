using System.Collections;
using UnityEngine;

namespace BioPunk
{
    public class EnemyDamage : MonoBehaviour
    {
        public Animator animator;
        public int maxHealth = 100;
        public int currentHealth;

        public HealthBar healthBar;

        private void Start()
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        public void TakeDamage(string kind)
        {
            if (currentHealth > 0)
            {
                if (kind == "basic") currentHealth -= 10;
                if (kind == "fire") currentHealth -= 10;
                if (kind == "emp") currentHealth -= 10;
                if (kind == "melee") currentHealth -= 5;
                healthBar.SetHealth(currentHealth);
                StartCoroutine(nameof(Damage));
            }
            else
            {
                animator.SetBool("EnemyDeath", true);
                StartCoroutine(nameof(Death));
            }
        }

        private IEnumerator Damage()
        {
            animator.SetBool("Damage", true);
            yield return new WaitForSeconds(.2f);
            animator.SetBool("Damage", false);
        }

        private IEnumerator Death()
        {
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }
    }
}
