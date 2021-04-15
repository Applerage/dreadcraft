using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInspect : MonoBehaviour
{
    public Canvas inspectChar;
    bool isOpened = false;
    void Start()
    {
        inspectChar.enabled = false;
    }
    public void ShowCharInspect()
    {
        inspectChar.enabled = true;
    }
    public void HideCharInspect()
    {
        inspectChar.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(isOpened == false)
            {
                inspectChar.enabled = true;
                isOpened = true;
            }
            else
            {
                inspectChar.enabled = false;
                isOpened = false;
            }
        }
    }
}
