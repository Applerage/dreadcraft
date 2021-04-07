using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInspect : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas inspectChar;
    bool isOpened = false;
    // Start is called before the first frame update
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

    // Update is called once per frame
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
