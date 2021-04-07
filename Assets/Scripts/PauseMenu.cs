using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Canvas pauseMenu;
    bool isOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.enabled = false;
    }

    public void ShowpauseMenu()
    {
        pauseMenu.enabled = true;
    }

    public void HidepauseMenu()
    {
        pauseMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isOpened == false)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.enabled = false;
        isOpened = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.enabled = true;
        isOpened = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
