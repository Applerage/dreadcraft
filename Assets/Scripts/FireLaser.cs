using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLaser : MonoBehaviour
{
    Meteor meteor;
    Fireball fireball;

    public float cooldownTime = 0.8f;
    private float nextFireTime = 0f;

    public bool castinglaser = false;
    public float castTimelaser = 1f;
    private float timerCastTimelaser;


    [SerializeField] ParticleSystem castParticles;

    public GameObject spell;
    public Transform firePoint;
    public float spellSpeed = 50;
    public GameObject player;

    Vector2 lookDirection;
    float lookAngle;


    QuestPickUp pickUp;

    private void Start()
    {
        timerCastTimelaser = castTimelaser;
        meteor = GetComponent<Meteor>();
        fireball = GetComponent<Fireball>();
        pickUp = GetComponent<QuestPickUp>();
    }

    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(player.transform.position.x, player.transform.position.y);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);
        if (pickUp.gainLaser == true)
        {
            if (meteor.casting == false && fireball.castingFireBall == false)
            {
                if (timerCastTimelaser <= 0)
                {
                    GameObject spellClone1 = Instantiate(spell);
                    spellClone1.transform.position = firePoint.position;
                    spellClone1.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

                    spellClone1.GetComponent<Rigidbody2D>().velocity = firePoint.right * spellSpeed;
                    
                    nextFireTime = Time.time + cooldownTime;
                    timerCastTimelaser = castTimelaser;
                    castinglaser = false;
                    castParticles.Stop();
                }

                if (Time.time > nextFireTime)
                {
                    if (castinglaser == true)
                    {
                        timerCastTimelaser -= Time.deltaTime;
                    }
                    if (Input.GetKeyDown(KeyCode.Alpha1))
                    {
                        castinglaser = true;
                        castParticles.Play();
                    }
                }
            }

        }
    }
}
