using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentTreeUnlock : MonoBehaviour
{
    private PlayerResources pr;
    private SpellGain sg;
    private Meteor meteor;
    private Incinerate incinerate;

    public Text ttpErrors;
    private float textTimer;
    private float textTimerDuration = 2f;
    private bool textTimerBool = false;

    public Image TTHealth1Image;
    public Image TTHealth2Image;
    public Image TTHealth3Image;
    public Image TTHealth4Image;
    public Image TTHealth5Image;
    public Image TTHealth11Image;
    public Image TTHealth21Image;
    public Image TTHealth31Image;
    public Image TTHealth41Image;
    public Image TTHealth51Image;

    public bool TT1IsUnlocked = false;
    public bool TT2IsUnlocked = false;
    public bool TT3IsUnlocked = false;
    public bool TT4IsUnlocked = false;
    public bool TT5IsUnlocked = false;
    public bool TT11IsUnlocked = false;
    public bool TT21IsUnlocked = false;
    public bool TT31IsUnlocked = false;
    public bool TT41IsUnlocked = false;
    public bool TT51IsUnlocked = false;
    // Start is called before the first frame update
    void Start()
    {
        pr = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerResources>();
        sg = GameObject.FindGameObjectWithTag("Player").GetComponent<SpellGain>();
        meteor = GameObject.FindGameObjectWithTag("Player").GetComponent<Meteor>();
        incinerate = GameObject.FindGameObjectWithTag("Player").GetComponent<Incinerate>();
        ttpErrors = GameObject.FindGameObjectWithTag("ErrorTalentText").GetComponent<Text>();
        textTimer = textTimerDuration;
    }

    public void UnlockTTHealth1()
    {
        if (TT1IsUnlocked == false && pr.currentTalentPoints > 0)
        {
            pr.maxHealth += 50;
            pr.currentHealth = pr.maxHealth;
            TT1IsUnlocked = true;
            pr.currentTalentPoints--;
        }     
        else if (pr.currentTalentPoints <= 0 && !TT1IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Not enough talent points!";
        }
        else if (TT1IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Already Learned!";
        }
    }
    public void UnlockTTHealth2()
    {
        if (!TT1IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Learn the Tier 1 first!";
        }
        if (TT11IsUnlocked == false && pr.currentTalentPoints > 1 && TT1IsUnlocked)
        {
            pr.maxHealth += 100;
            pr.currentHealth = pr.maxHealth;
            TT11IsUnlocked = true;
            pr.currentTalentPoints -= 2;
        }
        else if (pr.currentTalentPoints <= 1 && !TT11IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Not enough talent points!";
        }
        else if (TT11IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Already Learned!";
        }
    }
    public void UnlockTTDamage1()
    {
        if (TT2IsUnlocked == false && pr.currentTalentPoints > 0)
        {
            pr.intellect += 15;
            TT2IsUnlocked = true;
            pr.currentTalentPoints--;
        }
        else if (pr.currentTalentPoints <= 0 && !TT2IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Not enough talent points!";
        }
        else if (TT2IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Already Learned!";
        }
    }
    public void UnlockTTDamage2()
    {
        if (!TT2IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Learn the Tier 1 first!";
        }
        if (TT21IsUnlocked == false && pr.currentTalentPoints > 1 && TT2IsUnlocked)
        {
            pr.intellect += 25;
            TT21IsUnlocked = true;
            pr.currentTalentPoints -= 2;
        }
        else if (pr.currentTalentPoints <= 1 && !TT21IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Not enough talent points!";
        }
        else if (TT21IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Already Learned!";
        }
    }
    public void UnlockTTCooldown1()
    {
        if (meteor.isOnCd)
        {
            textTimerBool = true;
            ttpErrors.text = "Wait for Meteor CD!";
        }
        if (TT3IsUnlocked == false && pr.currentTalentPoints > 0 && meteor.cooldownTime >= 12 && !meteor.isOnCd)
        {
            meteor.cooldownTime -= 5;
            TT3IsUnlocked = true;
            pr.currentTalentPoints--;
        }
        else if (pr.currentTalentPoints <= 0 && !TT3IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Not enough talent points!";
        }
        else if (TT3IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Already Learned!";
        }
    }
    public void UnlockTTCooldown2()
    {
        if (!TT3IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Learn the Tier 1 first!";
        }
        if (TT31IsUnlocked == false && pr.currentTalentPoints > 1 && TT3IsUnlocked)
        {
            meteor.cooldownTime -= 7;
            TT31IsUnlocked = true;
            pr.currentTalentPoints -= 2;
        }
        else if (pr.currentTalentPoints <= 1 && !TT31IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Not enough talent points!";
        }
        else if (TT31IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Already Learned!";
        }
    }
    public void UnlockTTExperience1()
    {
        if (TT4IsUnlocked == false && pr.currentTalentPoints > 0)
        {
            textTimerBool = true;
            ttpErrors.text = "";
            pr.levelFromTalents = true;
            pr.currentXp += 1000;
            TT4IsUnlocked = true;
            pr.currentTalentPoints--;
        }
        else if (pr.currentTalentPoints <= 0 && !TT4IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Not enough talent points!";
        }
        else if (TT4IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Already Learned!";
        }
    }
    public void UnlockTTExperience2()
    {
        if (!TT4IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Learn the Tier 1 first!";
        }
        if (TT41IsUnlocked == false && pr.currentTalentPoints > 1 && TT4IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "";
            pr.levelFromTalents = true;
            pr.currentXp += 1500;
            TT41IsUnlocked = true;
            pr.currentTalentPoints -= 2;
        }
        else if (pr.currentTalentPoints <= 1 && !TT41IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Not enough talent points!";
        }
        else if (TT41IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Already Learned!";
        }
    }
    public void UnlockTTSpell1()
    {
        if (TT5IsUnlocked == false && pr.currentTalentPoints > 0)
        {
            sg.gainIncinerate = true;
            TT5IsUnlocked = true;
            pr.currentTalentPoints--;
        }
        else if (pr.currentTalentPoints <= 0 && !TT5IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Not enough talent points!";
        }
        else if (TT5IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Already Learned!";
        }
    }
    public void UnlockTTSpell2()
    {
        if (!TT5IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Learn the Tier 1 first!";
        }
        if (TT51IsUnlocked == false && pr.currentTalentPoints > 1 && TT5IsUnlocked)
        {
            incinerate.incinerateDuration += 3;
            TT51IsUnlocked = true;
            pr.currentTalentPoints -= 2;
        }
        else if (pr.currentTalentPoints <= 1 && !TT51IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Not enough talent points!";
        }
        else if (TT51IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Already Learned!";
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (textTimerBool)
        {
            textTimer -= Time.deltaTime;
            if (textTimer <= 0)
            {
                ttpErrors.text = "";
                textTimerBool = false;
                textTimer = textTimerDuration;
                pr.levelFromTalents = false;
            }
        }
    }
}
