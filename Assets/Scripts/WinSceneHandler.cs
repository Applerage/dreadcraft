using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneHandler : MonoBehaviour
{
    private EnemyHp ehp;
    void Start()
    {
        ehp = GetComponent<EnemyHp>();
    }

    void Update()
    {
        if (ehp.isDead)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
