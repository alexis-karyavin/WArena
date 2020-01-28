using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public int damage = 3;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthPlayer health = collision.GetComponent<HealthPlayer>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }

        Destroy(gameObject);

        //Enemy enemy = collision.GetComponent<Enemy>();
        //if (enemy != null)
        //{
        //    enemy.TakeDamage(damage);
        //}
        //Destroy(gameObject);

    }
}
