using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 1;
    int currentHealth;
    public EnemyBulletScript bulletScript; // Reference to the EnemyBulletScript

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            // Optionally, you can add logic for when the enemy is not dead yet.
        }
    }

    private void Die()
    {
        animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;

        // Set the 'destroyed' variable to false in the EnemyBulletScript
        if (bulletScript != null)
        {
            bulletScript.SetDestroyed(false);
        }

        // Disable this script
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Optionally, you can add update logic here if needed.
    }
}
