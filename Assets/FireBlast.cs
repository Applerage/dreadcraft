using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBlast : MonoBehaviour
{
    Meteor meteor;
    Fireball fireball;


    public float cooldownTime;
    private float nextFireTime = 0f;

    public bool castinglaser = false;
    public float castTimelaser = 0.1f;
    private float timerCastTimelaser;

    public bool isOnCd = false;
    private float cooldownTimer;

    public float blastRadius = 5;
    public float damage = 10;
    public bool isCast;
    [SerializeField] public ParticleSystem blastParticles;
    public float particlesTimer;
    private float particlesTimerCd;
    private bool particlesBool;
    private void Start()
    {
        particlesTimerCd = particlesTimer;
        timerCastTimelaser = castTimelaser;
        meteor = GetComponent<Meteor>();
        fireball = GetComponent<Fireball>();
        cooldownTimer = cooldownTime;
        isCast = false;
    }

    void Update()
    {
        if (meteor.casting == false && fireball.castingFireBall == false)
            {
                if (timerCastTimelaser <= 0 && isCast)
                {
                    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                    foreach (GameObject enemy in enemies)
                    {
                        if (blastRadius >= Vector3.Distance(transform.position, enemy.transform.position))
                        {
                            enemy.gameObject.GetComponent<EnemyHp>().takeDamage(damage);
                        }
                    }
                    nextFireTime = Time.time + cooldownTime;
                    cooldownTimer = cooldownTime;
                    timerCastTimelaser = castTimelaser;
                    isCast = false;
                }

                if (Time.time > nextFireTime)
                {
                    if (castinglaser)
                    {
                        timerCastTimelaser -= Time.deltaTime;
                    }
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        castinglaser = true;
                        isCast = true;
                        particlesBool = true;
                        blastParticles.Play();
                    }
                    isOnCd = false;
                }
                
            }
            if (particlesBool)
            {
                particlesTimerCd -= Time.deltaTime;
                if (particlesTimerCd <= 0)
                {
                    blastParticles.Stop();
                    particlesBool = false;
                    particlesTimerCd = particlesTimer;
                }
            }
            if (Time.time <= nextFireTime)
            {
                isOnCd = true;

            }
            // if (isOnCd)
            // {
            //     cooldownTimer -= Time.deltaTime;
            //     firelaserLoading.fillAmount = cooldownTimer / cooldownTime;
            //     fireLaserCd.text = (cooldownTimer % cooldownTime).ToString();
            //     if (firelaserLoading.fillAmount <= 0.05)
            //     {
            //         fireLaserCd.text = "";
            //     }
            // }
        }
        // else
        // {
        //     firelaserLoading.fillAmount = 1;
        // }
}
