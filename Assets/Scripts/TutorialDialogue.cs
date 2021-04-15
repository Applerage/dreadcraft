using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialDialogue : MonoBehaviour
{
    public Text dialogue;
    private float dialogueTimer;
    public float dialogueDuration = 12;
    public bool onStart = false;
    public float onStartTimer = 4;

    public bool onWizardCollision = false;

    public bool onWizard1Collision = false;
    
    public bool onItemPickUp = false;
    private SpellGain sg;
    private bool isFinished;
    private bool isFinished1;
    
    // Start is called before the first frame update
    void Start()
    {
        isFinished = false;
        isFinished1 = false;
        sg = GetComponent<SpellGain>();
        onStart = true;
        dialogueTimer = dialogueDuration;
        dialogue.text =
            "Hello Bob! Welcome to GeFontyst trials! Please, talk to the purple festival magician for some more info";
    }

    // Update is called once per frame
    void Update()
    {
        if (onWizardCollision || onWizard1Collision || onItemPickUp || onStart)
        {
            dialogueTimer -= Time.deltaTime;
            if (dialogueTimer <= 0)
            {
                dialogue.text = "";
                onWizardCollision = false;
                onWizard1Collision = false;
                onItemPickUp = false;
                onStart = false;
            }
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TutorialWizzard") && !isFinished)
        {
            isFinished = true;
            onWizardCollision = true;
            dialogueTimer = dialogueDuration;
            dialogue.text =  
                "Greetings Bob! Hereby, I present to you the Fire Laser! It's a small, but powerful spell, use it wisely! Have you spoken with Carl The Green yet?";
        }
        if (collision.gameObject.CompareTag("TutorialWizzard1") && !isFinished1)
        {
            isFinished1 = true;
            onWizard1Collision = true;
            dialogueTimer = dialogueDuration;
            dialogue.text =  
                "Hello there, are you new here? Hmm... I think Fireball is what you need in order to get the proficiency... Be careful though, it's a powerful spell!";
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TutorialItem"))
        {
            onItemPickUp = true;
            dialogueTimer = dialogueDuration;
            dialogue.text = 
                "Oh what is this... a staff? I can feel the power... My intellect and stamina are increased? Amazing! Is that... a new spell? Wonder what it does...";
        }
    }
}
