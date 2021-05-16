using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerResources : MonoBehaviour
{
    public SoundManager soundManager;

    public float currentHealth;
    public float maxHealth;
    public bool isFullHealth;
    private float lives = 2;
    public Image lifeImage1;
    public Image lifeImage2;
    public GameObject blood;
    
    public float currentLevel;
    public float maxLevel;
    public ParticleSystem levelParticles;
    private float levelParticlesTimer = 2f;
    private bool particlesActive = false;
    private bool playParticles = false;

    public Image expBar;
    public Image hpBar;
    public Text levelText;
    public Text diedText;

    public float currentXp;
    private float xpNeededToLevel;
    public int currentTalentPoints;

    public float stamina = 10;
    public float intellect = 10;

    public bool levelFromTalents;
    
    private float healthPercentage;
    private float xpPercentage;
    void Start()
    {
        Time.timeScale = 1f;
        currentHealth = maxHealth;
        currentLevel = 1;
        maxLevel = 30;
        currentTalentPoints = 0;
        isFullHealth = true;
        levelFromTalents = false;
    }
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

        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
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
            case 6:
                xpNeededToLevel = 1500;
                break;
            default:
                xpNeededToLevel = 1500;
                break;
        }
        OnLevelUp();
        OnLevelUpAnimation();
        expBar.fillAmount = xpPercentage / 100;
        hpBar.fillAmount = healthPercentage / 100;
        levelText.text = $"{currentLevel}";
    }

    void OnLevelUp()
    {
        if (currentXp >= xpNeededToLevel && currentLevel < maxLevel)
        {
            soundManager.levelUp.Play();
            if (!levelFromTalents)
            {
                currentXp = currentXp - xpNeededToLevel;
                currentLevel++;
                currentTalentPoints++;
                stamina += 15;
                intellect += 15;
                maxHealth = Mathf.RoundToInt(maxHealth + stamina / maxHealth * 200);
                currentHealth = maxHealth;
                particlesActive = true;
                playParticles = true;
                GetComponent<FireBlast>().damage = GetComponent<FireBlast>().damage + 15;
            }
            else
            {
                currentXp = currentXp - xpNeededToLevel;
                currentLevel++;
                stamina += 15;
                intellect += 15;
                maxHealth = Mathf.RoundToInt(maxHealth + stamina / maxHealth * 200);
                currentHealth = maxHealth;
                particlesActive = true;
                playParticles = true;
                GetComponent<FireBlast>().damage = GetComponent<FireBlast>().damage + 4;
            }
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
    
    public void TakeDamage(float amount)
    {
        soundManager.takeDamage.Play();
        currentHealth -= amount;
        healthPercentage = Mathf.RoundToInt(currentHealth / maxHealth * 100);
        hpBar.fillAmount = healthPercentage / 100;
        if (currentHealth <= 0)
        {
            Instantiate(blood, gameObject.transform.position, Quaternion.identity);
            currentHealth = maxHealth;
            lives--;
            if (lives < 0)
            {
                currentHealth = 0;
                StartCoroutine(LoadScene());
            }
            else if (lives == 1)
            {
                Destroy(lifeImage1);
            }
            else if (lives == 0)
            {
                Destroy(lifeImage2);
            }
            
        }
    }
    IEnumerator LoadScene()
    {
        GetComponent<PlayerMovement>().enabled = false;
        diedText.text = "You died!";
        Time.timeScale = 0.2f;
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene("LoseScene");
    }
}
