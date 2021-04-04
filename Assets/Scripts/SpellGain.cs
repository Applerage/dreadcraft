using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellGain : MonoBehaviour
{
    public bool gainFireBall = false;
    public bool gainMeteor = false;
    public bool gainLaser = false;
    public bool gainIncinerate = false;
    public ParticleSystem potionParticles1;
    public ParticleSystem potionParticles2;
    public GameObject potion1;
    public GameObject potion2;
    private PlayerResources pr;
    private TutorialDialogue td;
    private void Start()
    {
        pr = GetComponent<PlayerResources>();
        td = GetComponent<TutorialDialogue>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TutorialWizzard") && potion1 != null && !td.onStart && !td.onWizard1Collision && !td.onItemPickUp)
        {
            gainLaser = true;
            Destroy(potion1);
            potionParticles1.Stop();
        }
        if (collision.gameObject.CompareTag("TutorialWizzard1") && potion2 != null && !td.onStart && !td.onWizardCollision && !td.onItemPickUp)
        {
            gainFireBall = true;
            Destroy(potion2);
            potionParticles2.Stop();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item") && !td.onStart && !td.onWizard1Collision && !td.onWizardCollision)
        {
            pr.stamina += collision.gameObject.GetComponent<ItemStats>().stamina;
            pr.intellect += collision.gameObject.GetComponent<ItemStats>().intellect;
            pr.onItemCollection();
            gainMeteor = true;
            gainIncinerate = true;
            Destroy(collision.gameObject);
        }
    }
}
