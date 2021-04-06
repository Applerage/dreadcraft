using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class Incinerate : MonoBehaviour
{

    Fireball fireball;

    public float cooldownTime = 0.8f;
    private float nextFireTime = 0f;

    public bool duration = false;
    private float durationTime = 6f;
    public float incinerateDuration;
    private bool checkTalent = false;
    private TalentTreeUnlock ttu;

    public bool isOnCd = false;
    private float cooldownTimer;

    public Image incinerateLoading;
    public Text incinerateCd;
    public Image fireOverlay;
    public Image incinerateBuff;
    public Text incinerateBuffDuration;


    SpellGain pickUp;

    private void Start()
    {
        incinerateDuration = durationTime;
        fireball = GetComponent<Fireball>();
        pickUp = GetComponent<SpellGain>();
        cooldownTimer = cooldownTime;
        fireOverlay.enabled = false;
        incinerateBuff.enabled = false;
        incinerateBuffDuration.text = "";
        ttu = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TalentTreeUnlock>();
        Debug.Log(incinerateDuration);
    }

    void Update()
    {
        if (pickUp.gainIncinerate)
        {
            incinerateLoading.fillAmount = 0;
                if (incinerateDuration <= 0.0f)
                {
                    nextFireTime = Time.time + cooldownTime;
                    cooldownTimer = cooldownTime;
                    incinerateDuration = durationTime;
                    duration = false;
                    fireOverlay.enabled = false;
                    incinerateBuff.enabled = false;
                    incinerateBuffDuration.text = "";
                    Debug.Log(incinerateDuration);
                }
                if (Time.time > nextFireTime)
                {
                    if (duration)
                    {
                        incinerateDuration -= Time.deltaTime;
                        incinerateBuffDuration.text = $"{Mathf.RoundToInt(incinerateDuration)}";
                    }
                    if (Input.GetKeyDown(KeyCode.Alpha4))
                    {
                        duration = true;
                        fireOverlay.enabled = true;
                        incinerateBuff.enabled = true;
                    }
                    isOnCd = false;
                }
            if (Time.time <= nextFireTime)
            {
                isOnCd = true;

            }
            if (isOnCd)
            {
                
                cooldownTimer -= Time.deltaTime;
                incinerateLoading.fillAmount = cooldownTimer / cooldownTime;
                incinerateCd.text = (cooldownTimer % cooldownTime).ToString();
                if (incinerateLoading.fillAmount <= 0.03f)
                {
                    incinerateCd.text = "";
                }
            }

        }
        else
        {
            incinerateLoading.fillAmount = 1;
        }
    }
}
