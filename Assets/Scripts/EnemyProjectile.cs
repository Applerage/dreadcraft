using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject impactEffect;
    private Difficulty difficulty;
    private Rigidbody2D rb;
    public float damage = 20;
    public float speed;
    private Transform player;
    private Vector3 target;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(player.position.x, player.position.y);
        rb = GetComponent<Rigidbody2D>();
        difficulty = GameObject.FindGameObjectWithTag("Difficulty").GetComponent<Difficulty>();
        UpdateDamageAndSpeedOnDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        
    }
    void UpdateDamageAndSpeedOnDifficulty()
    {
        if (difficulty.difficulty == 1)
        {
            speed *= 1.8f;
            damage *= 2.2f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerResources>().TakeDamage(damage);
        }
        if (collision.gameObject.CompareTag("Dummy"))
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else if(!collision.gameObject.CompareTag("Enemy") && !collision.gameObject.CompareTag("Bullet"))
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
