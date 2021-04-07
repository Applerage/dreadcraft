﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject impactEffect;
    private Rigidbody2D rb;
    public float damage = 20;
    
    public float speed;

    private Transform player;

    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerResources>().TakeDamage(damage);
        }
    }
}
