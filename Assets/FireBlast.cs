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

    public bool castingBlast = false;
    public float castTimeBlast = 0.1f;
    private float timerCastTimeBlast;

    public bool isOnCd = false;
    private float cooldownTimer;

    public float blastRadius = 5;
    public float damage = 10;
    public bool isCast;
    [SerializeField] public ParticleSystem blastParticles;
    public float particlesTimer;
    private float particlesTimerCd;
    private bool particlesBool;
    
    public Image fireBlastLoading;
    public Text fireBlastCd;

    private SpellGain pickUp;
    private void Start()
    {
        particlesTimerCd = particlesTimer;
        timerCastTimeBlast = castTimeBlast;
        meteor = GetComponent<Meteor>();
        fireball = GetComponent<Fireball>();
        cooldownTimer = cooldownTime;
        isCast = false;
        pickUp = GetComponent<SpellGain>();
    }

    void Update()
    {
        if (pickUp.gainFireBlast)
        { 
            if (meteor.casting == false && fireball.castingFireBall == false)
            { 
                if (timerCastTimeBlast <= 0 && isCast)
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
                    timerCastTimeBlast = castTimeBlast;
                    isCast = false;
                }
                if (Time.time > nextFireTime)
                {
                    if (castingBlast)
                    {
                        timerCastTimeBlast -= Time.deltaTime;
                    }

                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        castingBlast = true;
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

            if (isOnCd)
            {
                cooldownTimer -= Time.deltaTime;
                fireBlastLoading.fillAmount = cooldownTimer / cooldownTime;
                fireBlastCd.text = (cooldownTimer % cooldownTime).ToString();
                if (fireBlastLoading.fillAmount <= 0.05)
                {
                    fireBlastCd.text = "";
                }
            }
            else
            {
                fireBlastLoading.fillAmount = -1;
            }
        }
    }
}
