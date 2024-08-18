using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 100;

    // Make this enemy take damage
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <=0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Can add death animation gameObject effect.
        // Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
