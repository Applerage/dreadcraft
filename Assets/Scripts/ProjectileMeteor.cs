using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMeteor : MonoBehaviour
{
    public GameObject impactEffect;
    private Rigidbody2D rb;
    public float damage = 20;
    private PlayerResources playerResources;
    public float blastRadius = 10f;
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
            damage = damage + playerResources.intellect * 0.5f;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                if (blastRadius >= Vector3.Distance(transform.position, enemy.transform.position))
                {
                    enemy.gameObject.GetComponent<EnemyHp>().takeDamage(damage);
                }
            }
            Destroy(gameObject);
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            
        }
    }
}
