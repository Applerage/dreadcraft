using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIMelee : MonoBehaviour
{
    public SoundManager soundManager;
    public Animator myAnim;
    private Transform target;
    [SerializeField]
    public float speed;
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
    private EnemyHp ehp;
    public bool isSlowed;
    public float isSlowedTimer = 3f;
    private float isSlowedTimerCd;
    public bool isMelee;
    private float actualSpeed;
    private void Start()
    {
        ehp = GetComponent<EnemyHp>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        startPosition = transform.position;
        timeBtwShots = startTimeBtwShots;
        isMoving = false;
        animationTimer = 0.8f;
        isHome = true;
        isSlowed = false;
        isSlowedTimerCd = isSlowedTimer;
        isMelee = true;
        actualSpeed = speed;
    }
    private void Update()
    {
        if (!isSlowed)
        {
            if (!gameObject.GetComponent<EnemyHp>().isDead)
        {
            if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange )
            {
                isHome = false;
                FollowPlayer();
            }

            if (Vector3.Distance(target.position, transform.position) >= minRange &&
                Vector3.Distance(target.position, transform.position) <= stoppingDistance)
            {
                isMoving = true;
            }
            else if (Vector3.Distance(target.position, transform.position) > stoppingDistance &&
                     Vector3.Distance(target.position, transform.position) <= maxRange)
            {
                isMoving = false;
            }
            else if (Vector3.Distance(target.position, transform.position) > maxRange)
            {
                GoHome();
                isMoving = false;
                isHome = true;
                ehp.currentHp = ehp.maxHp;
                ehp.healthBar.fillAmount = 1;
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
                    soundManager.enemyAttack.Play();
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
        if (isSlowed)
        {
            speed = 0;
            isSlowedTimerCd -= Time.deltaTime;
            if (isSlowedTimerCd <= 0)
            {
                isSlowed = false;
                isSlowedTimerCd = isSlowedTimer;
                speed = actualSpeed;
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
