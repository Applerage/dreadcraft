using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    public GameObject impactEffect;
    private Rigidbody2D rb;
    public float damage = 20;
    private PlayerResources playerResources;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerResources = GameObject.FindWithTag("Player").GetComponent<PlayerResources>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Item") && !collision.gameObject.CompareTag("Door") && !collision.gameObject.CompareTag("TutorialItem") && !collision.gameObject.CompareTag("Bullet") && !collision.gameObject.CompareTag("Potion"))
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Dummy"))
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy") && !collision.gameObject.GetComponent<EnemyHp>().isDead)
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            damage = damage + playerResources.intellect * 0.5f;
            collision.gameObject.GetComponent<EnemyHp>().takeDamage(damage);
        }
    }
}
