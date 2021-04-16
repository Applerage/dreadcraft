using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossDoorLock : MonoBehaviour
{
    public GameObject finalBossDoor;

    private EnemyHp ehp;
    private PlayerResources pr;
    public Text notification;
    private float notificationTimer = 5f;
    private bool notificationActive;
    void Start()
    {
        notificationActive = false;
        finalBossDoor.SetActive(true);
        ehp = GetComponent<EnemyHp>();
        pr = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerResources>();
    }
    private void Update()
    {
        if (pr.currentLevel >= 8)
        {
            finalBossDoor.SetActive(false);
        }
        if (ehp.currentHp < ehp.maxHp)
        {
            finalBossDoor.SetActive(true);
        }

        if (pr.currentLevel >= 10)
        {
            notificationActive = true;
        }
        if (notificationActive)
        {
            notification.text = "I feel like I am ready to fight The Unsatisfactory... or am I??";
            notificationTimer -= Time.deltaTime;
            if (notificationTimer <= 0)
            {
                notificationActive = false;
                notification.text = "";
            }
        }
    }
}
