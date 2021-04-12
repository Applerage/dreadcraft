using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnPickUpInspect : MonoBehaviour
{
    public Image currentItem;

    public Image pickUpItem;
    // Start is called before the first frame update
    void Start()
    {
        currentItem.enabled = true;
        pickUpItem.enabled = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            currentItem.enabled = false;
            pickUpItem.enabled = true;
        }
    }
}
