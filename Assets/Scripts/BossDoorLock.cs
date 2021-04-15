using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoorLock : MonoBehaviour
{
    public GameObject finalBossDoor;

    private EnemyHp ehp;
    private PlayerResources pr;
    void Start()
    {
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
        if (ehp.tookDamage)
        {
            finalBossDoor.SetActive(true);
        }
    }
}
