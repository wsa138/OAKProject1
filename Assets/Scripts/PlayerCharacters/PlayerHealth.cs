using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] FloatingHealthbar healthBar;

    private float maxHealth;
    private GameObject fillArea;

    private void Awake()
    {
        // Access the fill area of the healthBar slider.
        fillArea = healthBar.transform.Find("Fill Area").gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.UpdateHealthBar(health, maxHealth);
        
        if (health <=0)
        {
            Debug.Log(gameObject.name + " died");

            // Turn off health bar fill
            fillArea.SetActive(false);
        }
    }
}
