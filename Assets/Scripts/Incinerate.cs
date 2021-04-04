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
    public float durationTime;
    private float timerDuration;

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
        timerDuration = durationTime;
        fireball = GetComponent<Fireball>();
        pickUp = GetComponent<SpellGain>();
        cooldownTimer = cooldownTime;
        fireOverlay.enabled = false;
        incinerateBuff.enabled = false;
        incinerateBuffDuration.text = "";
    }

    void Update()
    {
        if (pickUp.gainIncinerate == true)
        {
            incinerateLoading.fillAmount = 0;
                if (timerDuration <= 0.0f)
                {
                    nextFireTime = Time.time + cooldownTime;
                    cooldownTimer = cooldownTime;
                    timerDuration = durationTime;
                    duration = false;
                    fireOverlay.enabled = false;
                    incinerateBuff.enabled = false;
                    incinerateBuffDuration.text = "";
                }
                if (Time.time > nextFireTime)
                {
                    if (duration)
                    {
                        timerDuration -= Time.deltaTime;
                        incinerateBuffDuration.text = $"{Mathf.RoundToInt(timerDuration)}";
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
