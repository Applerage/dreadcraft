using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject impactEffect;
    private Rigidbody2D rb;
    public float damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "Item" && collision.gameObject.tag != "Door")
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Dummy")
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            
            Destroy(gameObject);
            collision.gameObject.GetComponent<EnemyHp>().takeDamage(damage);
        }
    }

    
}
