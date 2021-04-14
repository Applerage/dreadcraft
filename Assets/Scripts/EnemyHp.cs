using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    public SoundManager soundManager;

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
    public bool tookDamage = false;

    private Incinerate incinerate;
    private EnemyAIRanged ai;
    private Difficulty difficulty;
    
    public Image healthBar;
    public Image healthBarBorder;

    // Start is called before the first frame update
    void Start()
    {
        difficulty = GameObject.FindGameObjectWithTag("Difficulty").GetComponent<Difficulty>();
        UpdateEnemyHpOnDifficulty();
        currentHp = maxHp;
        da = GameObject.FindGameObjectWithTag("Door").GetComponent<DoorAppear>();
        incinerate = GameObject.FindGameObjectWithTag("Player").GetComponent<Incinerate>();
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
        soundManager.enemyTakeDamage.Play();
        tookDamage = true;
        currentHp -= amount;
        animator.Play("TakeDamage");
        healthPercentage = Mathf.RoundToInt(currentHp / maxHp * 100);
        healthBar.fillAmount = healthPercentage / 100;
        damageText.text = $"-{Mathf.RoundToInt(amount)}";    
        if (currentHp <= 0)
        {
            soundManager.enemyDie.Play();
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
    void UpdateEnemyHpOnDifficulty()
    {
        if (difficulty.difficulty == 1)
        {
            maxHp *= 1.2f;
        }
    }
    
}
