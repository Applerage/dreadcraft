using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Image spellIncinerateIcon;
    public Image spellBookIncinerate;
    public Image spellBookIncinerateBorder;
    private void Start()
    {
        spellIncinerateIcon.enabled = false;
        spellBookIncinerate.enabled = false;
        spellBookIncinerateBorder.enabled = false;
        pr = GetComponent<PlayerResources>();
        td = GetComponent<TutorialDialogue>();
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
        if (collision.gameObject.CompareTag("TutorialItem"))
        {
            pr.stamina += collision.gameObject.GetComponent<ItemStats>().stamina;
            pr.intellect += collision.gameObject.GetComponent<ItemStats>().intellect;
            pr.onItemCollection();
            gainMeteor = true;           
            Destroy(collision.gameObject);
        }
    }
}
