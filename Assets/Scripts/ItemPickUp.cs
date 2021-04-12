using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    private PlayerResources pr;
    
    private void Start()
    {
        pr = GetComponent<PlayerResources>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            pr.stamina += collision.gameObject.GetComponent<ItemStats>().stamina;
            pr.intellect += collision.gameObject.GetComponent<ItemStats>().intellect;
            pr.currentXp += collision.gameObject.GetComponent<ItemStats>().xp;
            pr.onItemCollection();
            Destroy(collision.gameObject);
        }
    }
}
