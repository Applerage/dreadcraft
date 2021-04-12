using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMenuController : MonoBehaviour
{
    public Canvas controlMenu;
    // Start is called before the first frame update
    void Start()
    {
        controlMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenControlMenu()
    {
        controlMenu.enabled = true;
    }

    public void goBackToMainMenu()
    {
        controlMenu.enabled = false;
    }
}
