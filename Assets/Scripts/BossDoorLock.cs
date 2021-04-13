using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoorLock : MonoBehaviour
{
    public GameObject finalBossDoor;

    private EnemyHp ehp;
    // Start is called before the first frame update
    void Start()
    {
        finalBossDoor.SetActive(false);
        ehp = GetComponent<EnemyHp>();
    }

    private void Update()
    {
        if (ehp.tookDamage)
        {
            finalBossDoor.SetActive(true);
        }
    }
}
