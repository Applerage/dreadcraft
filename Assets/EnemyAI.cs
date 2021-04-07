using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Diagnostics;
using Random = UnityEngine.Random;
public class EnemyAI : MonoBehaviour
{
    public Animator myAnim;
    private Transform target;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float maxRange;
    
    [SerializeField]
    private float minRange;

    public Vector3 startPosition;

    public bool isAbleToAttack = true;
    public bool isMoving = false;
    public bool isDetected = false;
    private float attackTimer;
    private float attackCd = 2;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        startPosition = transform.position;
        attackTimer = attackCd;
    }

    private void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            myAnim.Play("FlyForward");
            FollowPlayer();
        }
        else if (Vector3.Distance(target.position, transform.position) > maxRange)
        {
            GoHome();
        }
        else
        {
            isMoving = false;
            myAnim.Play("Idle");
            transform.position = this.transform.position;
            Debug.Log(isAbleToAttack);
            if (isAbleToAttack)
            {
                attackTimer -= Time.deltaTime;
                if (attackTimer <= 0)
                {
                    myAnim.Play("ShockwaveAttack");
                    attackTimer = attackCd;
                }
            }
        }

        if (gameObject.GetComponent<EnemyHp>().isDead)
        {
            myAnim.Play("Die");
        }
    }

    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        isMoving = true;
        isDetected = true;
    }

    public void GoHome()
    {
        transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
        isDetected = false;
    }

}
