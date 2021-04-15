using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattleUI : MonoBehaviour
{
    public GameObject boss;

    private EnemyHp ehp;

    public Canvas bossUI;
    // Start is called before the first frame update
    void Start()
    {
        bossUI.enabled = false;
        ehp = boss.GetComponent<EnemyHp>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ehp.tookDamage)
        {
            bossUI.enabled = true;
        }
    }
}
