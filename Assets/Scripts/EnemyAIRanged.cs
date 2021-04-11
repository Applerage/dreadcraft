using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIRanged : MonoBehaviour
{
    public Animator myAnim;
    private Transform target;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float maxRange;

    public float stoppingDistance;
    
    [SerializeField]
    private float minRange;

    public Vector3 startPosition;

    public bool isMoving;
    private float timeBtwShots;
    public float startTimeBtwShots;
    private float animationTimer = 0.8f;
    private float animationMaxTimer = 0.8f;
    public bool isHome;
    public GameObject rotationObject;
    public GameObject projectile;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        startPosition = transform.position;
        timeBtwShots = startTimeBtwShots;
        isMoving = false;
        animationTimer = 0.8f;
        isHome = true;
    }

    private void Update()
    {
        if (!gameObject.GetComponent<EnemyHp>().isDead)
        {
            if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange && Vector3.Distance(target.position, transform.position) >= stoppingDistance)
            {
                isMoving = true;
                isHome = false;
                FollowPlayer();
            }
            else if (Vector3.Distance(target.position, transform.position) > maxRange)
            {
                GoHome();
                isMoving = false;
                isHome = true;
            }
        }
        if (transform.position.x > target.position.x)
        {
            rotationObject.transform.rotation = Quaternion.Euler(0, -120, 0);
        }
        if (transform.position.x < target.position.x)
        {
            rotationObject.transform.rotation = Quaternion.Euler(0, 150, 0);
        }
        if (gameObject.GetComponent<EnemyHp>().isDead)
        {
            isMoving = false;
            transform.position = this.transform.position;
            myAnim.Play("Die");
        }

        if (isMoving)
        {
            if (timeBtwShots <= 0)
            {
                myAnim.Play("CastSpell");
                if (animationTimer <= 0)
                {
                    Instantiate(projectile, transform.position, Quaternion.identity);
                    timeBtwShots = startTimeBtwShots;
                    animationTimer = animationMaxTimer;

                }
                else
                {
                    animationTimer -= Time.deltaTime;
                }
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }

    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public void GoHome()
    {
        transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * 2 *  Time.deltaTime);
    }
}
