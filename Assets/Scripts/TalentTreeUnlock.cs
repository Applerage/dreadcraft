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
    
    public ParticleSystem ps;
    private float particlesTimer;
    private float particlesTimerDuration = 1f;
    private bool particlesTimerBool = false;
    
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

    bool TT1IsUnlocked = false;
    bool TT2IsUnlocked = false;
    bool TT3IsUnlocked = false;
    bool TT4IsUnlocked = false;
    bool TT5IsUnlocked = false;
    bool TT11IsUnlocked = false;
    bool TT21IsUnlocked = false;
    bool TT31IsUnlocked = false;
    bool TT41IsUnlocked = false;
    public bool TT51IsUnlocked = false;
    // Start is called before the first frame update
    void Start()
    {
        pr = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerResources>();
        sg = GameObject.FindGameObjectWithTag("Player").GetComponent<SpellGain>();
        meteor = GameObject.FindGameObjectWithTag("Player").GetComponent<Meteor>();
        incinerate = GameObject.FindGameObjectWithTag("Player").GetComponent<Incinerate>();
        ttpErrors = GameObject.FindGameObjectWithTag("ErrorTalentText").GetComponent<Text>();
        ps = GameObject.FindGameObjectWithTag("LevelParticles").GetComponent<ParticleSystem>();
        textTimer = textTimerDuration;
    }

    public void UnlockTTHealth1()
    {
        if (TT1IsUnlocked == false && pr.currentTalentPoints > 0)
        {
            pr.stamina += 25;
            TT1IsUnlocked = true;
            pr.currentTalentPoints--;
        }     
        else if (pr.currentTalentPoints <= 0 && !TT1IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Not enough talent points!";
        }
        else if (pr.currentTalentPoints <= 0 && TT1IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Already Learned!";
        }
    }
    public void UnlockTTHealth2()
    {
        if (TT11IsUnlocked == false && pr.currentTalentPoints > 1 && TT1IsUnlocked)
        {
            pr.stamina += 30;
            TT11IsUnlocked = true;
            pr.currentTalentPoints -= 2;
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
        else if (pr.currentTalentPoints <= 0 && TT2IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Already Learned!";
        }
    }
    public void UnlockTTDamage2()
    {
        if (TT21IsUnlocked == false && pr.currentTalentPoints > 1 && TT2IsUnlocked)
        {
            pr.intellect += 25;
            TT21IsUnlocked = true;
            pr.currentTalentPoints -= 2;
            
        }
    }
    public void UnlockTTCooldown1()
    {
        if (TT3IsUnlocked == false && pr.currentTalentPoints > 0 && meteor.cooldownTime >= 12)
        {
            if (meteor.isOnCd)
            {
                textTimerBool = true;
                ttpErrors.text = "Wait for Meteor CD!";
            }
            meteor.cooldownTime -= 5;
            TT3IsUnlocked = true;
            pr.currentTalentPoints--;
        }
        else if (pr.currentTalentPoints <= 0 && !TT3IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Not enough talent points!";
        }
        else if (pr.currentTalentPoints <= 0 && TT3IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Already Learned!";
        }
    }
    public void UnlockTTCooldown2()
    {
        if (TT31IsUnlocked == false && pr.currentTalentPoints > 1 && TT3IsUnlocked)
        {
            meteor.cooldownTime -= 7;
            TT31IsUnlocked = true;
            pr.currentTalentPoints -= 2;
        }
    }
    public void UnlockTTExperience1()
    {
        if (TT4IsUnlocked == false && pr.currentTalentPoints > 0)
        {
            pr.currentLevel++;
            TT4IsUnlocked = true;
            pr.currentTalentPoints--;
            ps.Play();
            particlesTimerBool = true;
        }
        else if (pr.currentTalentPoints <= 0 && !TT4IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Not enough talent points!";
        }
        else if (pr.currentTalentPoints <= 0 && TT4IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Already Learned!";
        }
    }
    public void UnlockTTExperience2()
    {
        if (TT41IsUnlocked == false && pr.currentTalentPoints > 1 && TT4IsUnlocked)
        {
            pr.currentLevel++;
            TT41IsUnlocked = true;
            pr.currentTalentPoints -= 2;
            ps.Play();
            particlesTimerBool = true;
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
        else if (pr.currentTalentPoints <= 0 && TT5IsUnlocked)
        {
            textTimerBool = true;
            ttpErrors.text = "Already Learned!";
        }
    }
    public void UnlockTTSpell2()
    {
        if (TT51IsUnlocked == false && pr.currentTalentPoints > 1 && TT5IsUnlocked)
        {
            incinerate.incinerateDuration += 3;
            TT51IsUnlocked = true;
            pr.currentTalentPoints -= 2;
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
            }
        }
        if (particlesTimerBool)
        {
            textTimer -= Time.deltaTime;
            if (particlesTimer <= 0)
            {
                ps.Stop();
                particlesTimerBool = false;
                particlesTimer = particlesTimerDuration;
            }
        }
    }
}
