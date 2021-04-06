using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellBookOpen : MonoBehaviour
{
    public Canvas spellBookCanvas;
    bool isOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        spellBookCanvas.enabled = false;
    }

    public void OpenSpellBook()
    {
        spellBookCanvas.enabled = true;
    }
    public void CloseSpellBook()
    {
        spellBookCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isOpened)
            {
                spellBookCanvas.enabled = false;
                isOpened = false;
            }
            else
            {
                spellBookCanvas.enabled = true;
                isOpened = true;
            }
        }
    }
}
