using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    Meteor meteor;

    public float cooldownTime = 0.8f;
    private float nextFireTime = 0f;

    public bool castingFireBall = false;
    public float castTimeFireBall;
    private float timerCastTimeFireBall;

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
        timerCastTimeFireBall = castTimeFireBall;
        meteor = GetComponent<Meteor>();
        pickUp = GetComponent<QuestPickUp>();
    }

    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(player.transform.position.x, player.transform.position.y);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);
        if (pickUp.gainFireBall == true)
        {
            if(meteor.casting == false)
            {
                if (timerCastTimeFireBall <= 0.0f)
                {
                    GameObject spellClone = Instantiate(spell);
                    spellClone.transform.position = firePoint.position;
                    spellClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

                    spellClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * spellSpeed;
                    nextFireTime = Time.time + cooldownTime;
                    timerCastTimeFireBall = castTimeFireBall;
                    castingFireBall = false;
                    castParticles.Stop();
                }
                if (Time.time > nextFireTime)
                {
                    if(castingFireBall == true)
                    {
                        timerCastTimeFireBall -= Time.deltaTime;
                    }
                    if (Input.GetKeyDown(KeyCode.Alpha2))
                    {
                        castingFireBall = true;
                        castParticles.Play();
                    }
                }
            }
            
        }
    }
    
}
