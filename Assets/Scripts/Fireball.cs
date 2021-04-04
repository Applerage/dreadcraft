﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fireball : MonoBehaviour
{
    Meteor meteor;

    public float cooldownTime = 0.8f;
    private float nextFireTime = 0f;

    public bool castingFireBall = false;
    public float castTimeFireBall;
    private float timerCastTimeFireBall;

    public bool isOnCd = false;
    private float cooldownTimer;

    public Image fireBallLoading;
    public Text fireBallCd;
    public Image fireOverlay;

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
        timerCastTimeFireBall = castTimeFireBall;
        meteor = GetComponent<Meteor>();
        pickUp = GetComponent<SpellGain>();
        cooldownTimer = cooldownTime;
        fireOverlay.enabled = false;
    }

    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(player.transform.position.x, player.transform.position.y);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);
        if (pickUp.gainFireBall == true)
        {
            fireBallLoading.fillAmount = 0;
            if(meteor.casting == false)
            {
                if (timerCastTimeFireBall <= 0.0f)
                {
                    GameObject spellClone = Instantiate(spell);
                    spellClone.transform.position = firePoint.position;
                    spellClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

                    spellClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * spellSpeed;
                    nextFireTime = Time.time + cooldownTime;
                    cooldownTimer = cooldownTime;
                    timerCastTimeFireBall = castTimeFireBall;
                    castingFireBall = false;
                    fireOverlay.enabled = false;
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
                        fireOverlay.enabled = true;
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
                fireBallLoading.fillAmount = cooldownTimer / cooldownTime;
                fireBallCd.text = (cooldownTimer % cooldownTime).ToString();
                if (fireBallLoading.fillAmount <= 0.03)
                {
                    fireBallCd.text = "";
                }
            }
        }
        else
        {
            fireBallLoading.fillAmount = 1;
        }
    }
    
}
