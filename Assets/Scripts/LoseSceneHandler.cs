using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseSceneHandler : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
