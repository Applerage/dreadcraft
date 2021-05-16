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
    private FireBlast fireBlast;
    private Conflagarate conflagarate;

    public Text ttpErrors;
    private float textTimer;
    private float textTimerDuration = 2f;
    private bool textTimerBool = false;

    public bool TT1IsUnlocked = false;
    public bool TT2IsUnlocked = false;
    public bool TT3IsUnlocked = false;
    public bool TT4IsUnlocked = false;
    public bool TT5IsUnlocked = false;
    public bool TT6IsUnlocked = false;
    public bool TT7IsUnlocked = false;
    public bool TT11IsUnlocked = false;
    public bool TT21IsUnlocked = false;
    public bool TT31IsUnlocked = false;
    public bool TT41IsUnlocked = false;
    public bool TT51IsUnlocked = false;
    public bool TT61IsUnlocked = false;
    public bool TT71IsUnlocked = false;
    public bool TT111IsUnlocked = false;
    public bool TT211IsUnlocked = false;
    public bool TT311IsUnlocked = false;
    public bool TT411IsUnlocked = false;
    public bool TT511IsUnlocked = false;
    public bool TT611IsUnlocked = false;
    public bool TT711IsUnlocked = false;
    void Start()
    {
        pr = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerResources>();
        sg = GameObject.FindGameObjectWithTag("Player").GetComponent<SpellGain>();
        meteor = GameObject.FindGameObjectWithTag("Player").GetComponent<Meteor>();
        incinerate = GameObject.FindGameObjectWithTag("Player").GetComponent<Incinerate>();
        fireBlast = GameObject.FindGameObjectWithTag("Player").GetComponent<FireBlast>();
        conflagarate = GameObject.FindGameObjectWithTag("Player").GetComponent<Conflagarate>();
        ttpErrors = GameObject.FindGameObjectWithTag("ErrorTalentText").GetComponent<Text>();
        textTimer = textTimerDuration;
    }

    public void UnlockTTHealth1()
    {
        if (TT1IsUnlocked == false && pr.currentTalentPoints > 0)
        {
            pr.maxHealth += 100;
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
            pr.maxHealth += 150;
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
    
    public void UnlockTTHealth3()
    {
        if (!TT11IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Learn the Tier 2 first!";
        }
        if (TT111IsUnlocked == false && pr.currentTalentPoints > 2 && TT11IsUnlocked)
        {
            pr.maxHealth += 400;
            pr.currentHealth = pr.maxHealth;
            TT11IsUnlocked = true;
            pr.currentTalentPoints -= 3;
        }
        else if (pr.currentTalentPoints <= 2 && !TT111IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Not enough talent points!";
        }
        else if (TT111IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Already Learned!";
        }
    }
    public void UnlockTTDamage1()
    {
        if (TT2IsUnlocked == false && pr.currentTalentPoints > 0)
        {
            pr.intellect += 25;
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
            pr.intellect += 50;
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
    
    public void UnlockTTDamage3()
    {
        if (!TT21IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Learn the Tier 1 first!";
        }
        if (TT211IsUnlocked == false && pr.currentTalentPoints > 2 && TT21IsUnlocked)
        {
            pr.intellect += 150;
            TT211IsUnlocked = true;
            pr.currentTalentPoints -= 3;
        }
        else if (pr.currentTalentPoints <= 2 && !TT211IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Not enough talent points!";
        }
        else if (TT211IsUnlocked)
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
        if (TT31IsUnlocked == false && pr.currentTalentPoints > 1 && TT3IsUnlocked && !meteor.isOnCd)
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
    
    public void UnlockTTCooldown3()
    {
        if (!TT31IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Learn the Tier 2 first!";
        }
        if (TT311IsUnlocked == false && pr.currentTalentPoints > 2 && TT31IsUnlocked && !meteor.isOnCd)
        {
            meteor.cooldownTime -= 5;
            TT311IsUnlocked = true;
            pr.currentTalentPoints -= 3;
        }
        else if (pr.currentTalentPoints <= 2 && !TT311IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Not enough talent points!";
        }
        else if (TT311IsUnlocked)
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
            pr.maxLevel++;
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
        if (TT41IsUnlocked == false && pr.currentTalentPoints > 2 && TT4IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "";
            pr.levelFromTalents = true;
            pr.currentXp += 1500;
            pr.maxLevel++;
            TT41IsUnlocked = true;
            pr.currentTalentPoints -= 3;
        }
        else if (pr.currentTalentPoints <= 2 && !TT41IsUnlocked)
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
    
    public void UnlockTTExperience3()
    {
        if (!TT41IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Learn the Tier 2 first!";
        }
        if (TT411IsUnlocked == false && pr.currentTalentPoints > 2 && TT41IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "";
            pr.levelFromTalents = true;
            pr.currentXp += 1500;
            pr.maxLevel++;
            TT411IsUnlocked = true;
            pr.currentTalentPoints -= 3;
        }
        else if (pr.currentTalentPoints <= 2 && !TT411IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Not enough talent points!";
        }
        else if (TT411IsUnlocked)
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
            sg.spellIncinerateIcon.enabled = true;
            sg.spellBookIncinerate.enabled = true;
            sg.spellBookIncinerateBorder.enabled = true;
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
    
    public void UnlockTTSpell3()
    {
        if (!TT51IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Learn the Tier 2 first!";
        }
        if (TT511IsUnlocked == false && pr.currentTalentPoints > 2 && TT51IsUnlocked)
        {
            incinerate.cooldownTime -= 15;
            TT511IsUnlocked = true;
            pr.currentTalentPoints -= 3;
        }
        else if (pr.currentTalentPoints <= 2 && !TT511IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Not enough talent points!";
        }
        else if (TT511IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Already Learned!";
        }
    }
    public void UnlockTTFireBlast1()
    {
        if (TT6IsUnlocked == false && pr.currentTalentPoints > 0)
        {
            sg.gainFireBlast = true;
            sg.spellFireBlastIcon.enabled = true;
            sg.spellBookFireBlastBorder.enabled = true;
            sg.spellBookFireBlast.enabled = true;
            TT6IsUnlocked = true;
            pr.currentTalentPoints--;
        }
        else if (pr.currentTalentPoints <= 0 && !TT6IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Not enough talent points!";
        }
        else if (TT6IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Already Learned!";
        }
    }
    
    public void UnlockTTFireBlast2()
    {
        if (!TT6IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Learn the Tier 1 first!";
        }
        if (TT61IsUnlocked == false && pr.currentTalentPoints > 1 && TT6IsUnlocked)
        {
            fireBlast.damage *= 2;
            TT61IsUnlocked = true;
            pr.currentTalentPoints -= 2;
        }
        else if (pr.currentTalentPoints <= 1 && !TT61IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Not enough talent points!";
        }
        else if (TT61IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Already Learned!";
        }
    }
    
    public void UnlockTTFireBlast3()
    {
        if (!TT61IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Learn the Tier 2 first!";
        }
        if (TT611IsUnlocked == false && pr.currentTalentPoints > 1 && TT61IsUnlocked)
        {
            fireBlast.cooldownTime -= 4;
            TT611IsUnlocked = true;
            pr.currentTalentPoints -= 3;
        }
        else if (pr.currentTalentPoints <= 1 && !TT611IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Not enough talent points!";
        }
        else if (TT611IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Already Learned!";
        }
    }
    
    public void UnlockTTConf1()
    {
        if (TT7IsUnlocked == false && pr.currentTalentPoints > 0)
        {
            sg.gainConflagarate = true;
            sg.spellConfIcon.enabled = true;
            sg.spellBookConf.enabled = true;
            sg.spellBookConfBorder.enabled = true;
            TT7IsUnlocked = true;
            pr.currentTalentPoints--;
        }
        else if (pr.currentTalentPoints <= 0 && !TT7IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Not enough talent points!";
        }
        else if (TT7IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Already Learned!";
        }
    }
    
    public void UnlockTTConf2()
    {
        if (!TT7IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Learn the Tier 1 first!";
        }
        if (TT71IsUnlocked == false && pr.currentTalentPoints > 1 && TT7IsUnlocked)
        {
            conflagarate.cooldownTime -= 5;
            TT71IsUnlocked = true;
            pr.currentTalentPoints -= 2;
        }
        else if (pr.currentTalentPoints <= 1 && !TT71IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Not enough talent points!";
        }
        else if (TT61IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Already Learned!";
        }
    }
    
    public void UnlockTTConf3()
    {
        if (!TT71IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Learn the Tier 2 first!";
        }
        if (TT711IsUnlocked == false && pr.currentTalentPoints > 1 && TT71IsUnlocked)
        {
            conflagarate.cooldownTime = 1;
            TT711IsUnlocked = true;
            pr.currentTalentPoints -= 3;
        }
        else if (pr.currentTalentPoints <= 1 && !TT711IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Not enough talent points!";
        }
        else if (TT711IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Already Learned!";
        }
    }
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
