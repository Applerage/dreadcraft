using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentTreeOpen : MonoBehaviour
{
    public Canvas TalentTree;
    bool isOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        TalentTree.enabled = false;
    }

    public void ShowTalentTree()
    {
        TalentTree.enabled = true;
    }

    public void HideTalentTree()
    {
        TalentTree.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if(isOpened == false)
            {
                TalentTree.enabled = true;
                isOpened = true;
            }
            else
            {
                TalentTree.enabled = false;
                isOpened = false;
            }
        }

                    
    }
}
