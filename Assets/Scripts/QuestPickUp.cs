using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPickUp : MonoBehaviour
{
    public bool gainFireBall = false;
    public bool gainMeteor = false;
    public bool gainLaser = false;
    public ParticleSystem potionParticles;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TutorialWizzard")
        {
            gainFireBall = true;
            gainMeteor = true;
            potionParticles.Stop();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            gainLaser = true;
            Destroy(collision.gameObject);
        }
    }
}
