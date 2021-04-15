using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattleUI : MonoBehaviour
{
    public GameObject boss;

    private EnemyHp ehp;
    
    public Canvas bossUI;
    void Start()
    {
        bossUI.enabled = false;
        ehp = boss.GetComponent<EnemyHp>();
    }
    void Update()
    {
        if (ehp.tookDamage)
        {
            bossUI.enabled = true;
        }
    }
}
