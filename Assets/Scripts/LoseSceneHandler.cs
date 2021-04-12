using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseSceneHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PlayAgain()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
