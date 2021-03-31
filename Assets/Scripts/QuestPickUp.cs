using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPickUp : MonoBehaviour
{
    public bool gainFireBall = false;
    public bool gainMeteor = false;
    public bool gainLaser = false;
    public ParticleSystem potionParticles1;
    public ParticleSystem potionParticles2;
    public GameObject potion1;
    public GameObject potion2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TutorialWizzard")
        {
            gainLaser = true;
            Destroy(potion1);
            potionParticles1.Stop();
        }
        if (collision.gameObject.tag == "TutorialWizzard1")
        {
            gainFireBall = true;
            Destroy(potion2);
            potionParticles2.Stop();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            gainMeteor = true;
            Destroy(collision.gameObject);
        }
    }
}
