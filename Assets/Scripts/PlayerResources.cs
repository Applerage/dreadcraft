using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResources : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public bool isFullHealth;
    
    public float currentLevel;
    public float maxLevel;
    public ParticleSystem levelParticles;
    private float levelParticlesTimer = 1.5f;
    private bool particlesActive = false;
    private bool playParticles = false;

    public Image expBar;
    public Image hpBar;
    public Text levelText;

    public float currentXp;
    private float xpNeededToLevel;
    public int currentTalentPoints;

    public float stamina = 10;
    public float intellect = 10;
    
    /* Percentage (%) values */
    private float healthPercentage;
    private float xpPercentage;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentLevel = 1;
        maxLevel = 5;
        currentTalentPoints = 0;
        isFullHealth = true;
    }

    // Update is called once per frame
    void Update()
    {
        healthPercentage = Mathf.RoundToInt(currentHealth / maxHealth * 100);
        xpPercentage = Mathf.RoundToInt(currentXp / xpNeededToLevel * 100);


        if (healthPercentage == 100)
        {
            isFullHealth = true;
        }
        else if (healthPercentage != 100)
        {
            isFullHealth = false;
        }
        
        if (currentLevel >= maxLevel)
        {
            currentLevel = maxLevel;
        }
        switch(currentLevel) 
        {
            case 1:
                xpNeededToLevel = 500;
                break;
            case 2:
                xpNeededToLevel = 750;
                break;
            case 3:
                xpNeededToLevel = 1000;
                break;
            case 4:
                xpNeededToLevel = 1250;
                break;
            case 5:
                xpNeededToLevel = 1500;
                break;
        }
        OnLevelUp();
        OnLevelUpAnimation();
        expBar.fillAmount = xpPercentage / 100;
        hpBar.fillAmount = healthPercentage / 100;
        levelText.text = $"{currentLevel}";
        

        

        

        /* Test level up */
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("xp percentage " + xpPercentage);
            Debug.Log("current level " + currentLevel);
            Debug.Log("talent points "+ currentTalentPoints);
            Debug.Log("current health "+ currentHealth);
            Debug.Log("max health "+ maxHealth);
            Debug.Log("stamina " + stamina);
            Debug.Log("intellect " + intellect);
            Debug.Log("health %  " + healthPercentage);
        }
    }

    void OnLevelUp()
    {
        if (currentXp >= xpNeededToLevel)
        {
            currentXp = currentXp - xpNeededToLevel;
            currentLevel++;
            currentTalentPoints++;
            stamina += 0.5f * stamina;
            intellect += 0.5f * intellect;
            maxHealth = Mathf.RoundToInt(maxHealth + stamina / maxHealth * 200);
            currentHealth = maxHealth;
            particlesActive = true;
            playParticles = true;
        }

        if (currentLevel >= maxLevel)
        {
            currentXp = xpNeededToLevel - 1;
        }
    }

    void OnLevelUpAnimation()
    {
        if (particlesActive)
        {
            levelParticlesTimer -= Time.deltaTime;
            if (playParticles)
            {
                levelParticles.Play();
                playParticles = false;
            }
            Debug.Log(levelParticlesTimer);
            if (levelParticlesTimer <= 0)
            {
                levelParticles.Stop();
                particlesActive = false;
                levelParticlesTimer = 1.5f;
            }
        }
    }
    public void onItemCollection()
    {
        maxHealth = Mathf.RoundToInt(maxHealth + stamina / maxHealth * 200);
        if (isFullHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
