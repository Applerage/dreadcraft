using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireLaser : MonoBehaviour
{
    Meteor meteor;
    Fireball fireball;

    public SoundManager soundManager;

    public float cooldownTime;
    private float nextFireTime = 0f;

    public bool castinglaser = false;
    public float castTimelaser = 1f;
    private float timerCastTimelaser;

    public bool isOnCd = false;
    private float cooldownTimer;

    public Image firelaserLoading;
    public Text fireLaserCd;

    [SerializeField] ParticleSystem castParticles;

    public GameObject spell;
    public Transform firePoint;
    public float spellSpeed = 50;
    public GameObject player;

    Vector2 lookDirection;
    float lookAngle;


    SpellGain pickUp;

    private void Start()
    {
        timerCastTimelaser = castTimelaser;
        meteor = GetComponent<Meteor>();
        fireball = GetComponent<Fireball>();
        pickUp = GetComponent<SpellGain>();
        cooldownTimer = cooldownTime;
    }

    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(player.transform.position.x, player.transform.position.y);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);
        if (pickUp.gainLaser == true)
        {
            firelaserLoading.fillAmount = 0;
            if (meteor.casting == false && fireball.castingFireBall == false)
            {
                
                if (timerCastTimelaser <= 0)
                {
                    soundManager.fireLaser.Play();
                    GameObject spellClone1 = Instantiate(spell);
                    spellClone1.transform.position = firePoint.position;
                    spellClone1.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

                    spellClone1.GetComponent<Rigidbody2D>().velocity = firePoint.right * spellSpeed;
                    
                    nextFireTime = Time.time + cooldownTime;
                    cooldownTimer = cooldownTime;
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
                    if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        castinglaser = true;
                        castParticles.Play();
                    }
                    isOnCd = false;
                }
                
            }
            if (Time.time <= nextFireTime)
            {
                isOnCd = true;

            }
            if (isOnCd)
            {
                cooldownTimer -= Time.deltaTime;
                firelaserLoading.fillAmount = cooldownTimer / cooldownTime;
                fireLaserCd.text = (cooldownTimer % cooldownTime).ToString();
                if (firelaserLoading.fillAmount <= 0.05)
                {
                    fireLaserCd.text = "";
                }
            }
        }
        else
        {
            firelaserLoading.fillAmount = 1;
        }
    }
}
