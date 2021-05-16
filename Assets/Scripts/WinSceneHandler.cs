using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinSceneHandler : MonoBehaviour
{
    private EnemyHp ehp;
    public Text winText;
    void Start()
    {
        Time.timeScale = 1f;
        ehp = GetComponent<EnemyHp>();
    }
    void Update()
    {
        if (ehp.isDead)
        {
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
        winText.text = "The proficiency is achieved!";
        Time.timeScale = 0.2f;
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("Level3");
    }
}
