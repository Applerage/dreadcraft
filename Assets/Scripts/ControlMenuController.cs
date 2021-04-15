using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMenuController : MonoBehaviour
{
    public Canvas controlMenu;
    void Start()
    {
        controlMenu.enabled = false;
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
