using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] int damage = 20;
    [SerializeField] GameObject hitEffect;
    public GameObject originPlayer; // The player creating the projectile.

    public bool PVP = false;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;

        Collider2D projectileCollider = GetComponent<Collider2D>();
        Collider2D originPlayerCollider = originPlayer.GetComponent<Collider2D>();

        // Ignore collisions between the game object this script is assigned to and the game object that instantiates it.
        Physics2D.IgnoreCollision(projectileCollider, originPlayerCollider);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log(GetComponent<Collider2D>());
        // Debug.Log(collision);

        DecreaseHealth(collision);
        DecreasePlayerHealth(collision);

        // Control what happens to projectile.
        if (collision.gameObject.tag == "Player" && PVP == false)
        {
            return;
        }
        else
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    // Access enemy health controller/script and decrease health
    private void DecreaseHealth(Collider2D collision)
    {        
        EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }        
    }

    // Aacess player health controller/script, if allowed, and decrease health.
    private void DecreasePlayerHealth(Collider2D collision)
    {
        PlayerHealth player = collision.GetComponent<PlayerHealth>();
        if (player != null && PVP == true)
        {
            player.TakeDamage(damage);
        }
    }
}
