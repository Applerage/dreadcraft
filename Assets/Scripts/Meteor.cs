using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    Fireball fireball;

    public float cooldownTime = 0.8f;
    private float nextFireTime = 0f;

    public bool casting = false;
    public float castTime;
    private float timerCastTime;

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
        timerCastTime = castTime;
        fireball = GetComponent<Fireball>();
        pickUp = GetComponent<QuestPickUp>();
    }

    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(player.transform.position.x, player.transform.position.y);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);
        if (pickUp.gainMeteor == true)
        {
            if(fireball.castingFireBall == false)
            {
                if (timerCastTime <= 0.0f)
                {
                    GameObject spellClone = Instantiate(spell);
                    spellClone.transform.position = firePoint.position;
                    spellClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

                    spellClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * spellSpeed;
                    nextFireTime = Time.time + cooldownTime;
                    timerCastTime = castTime;
                    casting = false;
                    castParticles.Stop();
                }
                if (Time.time > nextFireTime)
                {
                    if (casting == true)
                    {
                        timerCastTime -= Time.deltaTime;
                    }
                    if (Input.GetKeyDown(KeyCode.Alpha3))
                    {
                        casting = true;
                        castParticles.Play();
                    }
                }
            }
            
        }
    }
}
