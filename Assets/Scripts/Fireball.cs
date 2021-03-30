﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    Meteor meteor;
    public bool gainSpell = false;

    public float cooldownTime = 0.8f;
    private float nextFireTime = 0f;

    public bool castingFireBall = false;
    public float castTimeFireBall;
    private float timerCastTimeFireBall;


    public GameObject spell;
    public Transform firePoint;
    public float spellSpeed = 50;
    public GameObject player;

    Vector2 lookDirection;
    float lookAngle;

    private void Start()
    {
        timerCastTimeFireBall = castTimeFireBall;
        meteor = GetComponent<Meteor>();
    }

    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(player.transform.position.x, player.transform.position.y);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);
        if (gainSpell == true)
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
                }
                if (Time.time > nextFireTime)
                {
                    if(castingFireBall == true)
                    {
                        timerCastTimeFireBall -= Time.deltaTime;
                    }
                    if (Input.GetKeyDown(KeyCode.Alpha1))
                    {
                        Debug.Log(castTimeFireBall);
                        castingFireBall = true;
                    }
                }
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TutorialWizzard")
        {
            gainSpell = true;
            Debug.Log(gainSpell);
        }
    }
}
