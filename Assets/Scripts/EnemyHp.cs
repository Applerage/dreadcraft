using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    private BossDoorLock bossDoorLock;
    public float maxHp = 100;
    public float currentHp;
    private DoorAppear da;
    private float animationTimer = 1f;
    public bool isDead = false;
    public Animator animator;
    private float healthPercentage;
    public float xpPoints;
    public GameObject player;
    public Text damageText;
    private float damageTimer;
    public float damageDuration;
    private bool tookDamage = false;

    private Incinerate incinerate;
    private EnemyAIRanged ai;
    
    public Image healthBar;
    public Image healthBarBorder;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        da = GameObject.FindGameObjectWithTag("Door").GetComponent<DoorAppear>();
        incinerate = GameObject.FindGameObjectWithTag("Player").GetComponent<Incinerate>();
        bossDoorLock = GetComponent<BossDoorLock>();
        if (maxHp >= 100)
        {
            animationTimer = 1.2f;
        }
        healthPercentage = Mathf.RoundToInt(currentHp / maxHp * 100);
        damageTimer = damageDuration;
        ai = GetComponent<EnemyAIRanged>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            animationTimer -= Time.deltaTime;

        }

        if (animationTimer <= 0)
        {
            Destroy(gameObject);
        }
        
        if (tookDamage)
        {
            damageTimer -= Time.deltaTime;
            if (damageTimer <= 0)
            {
                damageText.text = "";
                tookDamage = false;
                damageTimer = damageDuration;
            }
            bossDoorLock.finalBossDoor.SetActive(true);
        }

        if (ai.isHome)
        {
            currentHp = maxHp;
            healthBar.fillAmount = 1;
        }
    }

    public void takeDamage(float amount)
    {
        if (incinerate.duration)
        {
            amount = amount * 2;
        }
        tookDamage = true;
        currentHp -= amount;
        animator.Play("TakeDamage");
        healthPercentage = Mathf.RoundToInt(currentHp / maxHp * 100);
        healthBar.fillAmount = healthPercentage / 100;
        damageText.text = $"-{Mathf.RoundToInt(amount)}";
        if (currentHp <= 0)
        {
            isDead = true;
            animator.Play("Die");
            currentHp = 0;
            healthPercentage = 0;
            player.GetComponent<PlayerResources>().currentXp += xpPoints;
            da.count++;
            da.openDoor();
            Destroy(healthBar);
            Destroy(healthBarBorder);
        }
    }
}
