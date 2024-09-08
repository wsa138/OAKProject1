using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] GameObject deathEffect;
    [SerializeField] FloatingHealthbar healthBar;

    private float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Make this enemy take damage
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.UpdateHealthBar(health, maxHealth);

        if (health <=0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
