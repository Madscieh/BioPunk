using System.Collections;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public Animator animator;
    private int lives = 1;

    public void OnTriggerEnter(Collider other)
    {
        if (lives > 0)
        {
            if (other.gameObject.tag == "Projectile") StartCoroutine("Damage");
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
        lives--;
        animator.SetBool("Damage", false);
    }
}
