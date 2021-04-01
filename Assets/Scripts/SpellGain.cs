﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellGain : MonoBehaviour
{
    public bool gainFireBall = false;
    public bool gainMeteor = false;
    public bool gainLaser = false;
    public ParticleSystem potionParticles1;
    public ParticleSystem potionParticles2;
    public GameObject potion1;
    public GameObject potion2;
    private PlayerResources pr;

    private void Start()
    {
        pr = GetComponent<PlayerResources>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TutorialWizzard") && potion1 != null)
        {
            gainLaser = true;
            Destroy(potion1);
            potionParticles1.Stop();
        }
        if (collision.gameObject.CompareTag("TutorialWizzard1") && potion2 != null)
        {
            gainFireBall = true;
            Destroy(potion2);
            potionParticles2.Stop();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            pr.stamina += collision.gameObject.GetComponent<ItemStats>().stamina;
            pr.onItemCollection();
            gainMeteor = true;
            Destroy(collision.gameObject);
        }
    }
}
