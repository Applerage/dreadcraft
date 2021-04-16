using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueStart : MonoBehaviour
{
    public Text dialogueText;
    public Canvas bubble;
    private float textTimer = 5f;

    private bool firstTextActive;
    private bool secondTextActive;
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
        firstTextActive = true;
        secondTextActive = false;
        bubble.enabled = true;
    }
    void Update()
    {
        if (firstTextActive)
        {
            dialogueText.text = "Ahh... shit! They left me out in the wild again...";
            textTimer -= Time.deltaTime;
            if (textTimer <= 0)
            {
                firstTextActive = false;
                secondTextActive = true;
                textTimer = 5f;
            }
        }
        if (secondTextActive)
        {
            dialogueText.text = "Well, I guess I need to graduate after all...";
            textTimer -= Time.deltaTime;
            if (textTimer <= 0)
            {
                dialogueText.text = "";
                secondTextActive = false;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = true;
                bubble.enabled = false;
            }
        }
    }
}
