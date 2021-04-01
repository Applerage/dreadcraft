using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public bool isFullHealth;
    
    public float currentLevel;
    public float maxLevel;

    public float currentXp;
    private float xpNeededToLevel;
    public int currentTalentPoints;

    public float stamina = 10;
    public float intellect = 10;
    
    /* Percentage (%) values */
    private int healthPercentage;
    private int xpPercentage;
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

        /* Test level up */
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("xp percentage " + xpPercentage);
            Debug.Log("current level " + currentLevel);
            Debug.Log("talent points "+ currentTalentPoints);
            Debug.Log("current health "+ currentHealth);
            Debug.Log("max health "+ maxHealth);
            Debug.Log("stamina " + stamina);
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
        }

        if (currentLevel >= maxLevel)
        {
            currentXp = xpNeededToLevel - 1;
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
