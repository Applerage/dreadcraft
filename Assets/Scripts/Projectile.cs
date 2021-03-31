using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject impactEffect;
    public DoorAppear da;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        da = GameObject.FindGameObjectWithTag("Door").GetComponent<DoorAppear>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "Item" && collision.gameObject.tag != "Door")
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Dummy")
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            da.count++;
            da.openDoor();
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        
    }

    
}
