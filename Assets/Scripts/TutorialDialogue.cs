using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialDialogue : MonoBehaviour
{
    public Text dialogue;

    public bool onStart = false;
    public float onStartTimer = 4;

    public bool onWizardCollision = false;
    public float onWizardTimer = 4;

    public bool onWizard1Collision = false;
    public float onWizard1Timer = 4;
    
    public bool onItemPickUp = false;
    public float onItemTimer = 4;
    
    // Start is called before the first frame update
    void Start()
    {
        onStart = true;
        dialogue.text =
            "Hello Bob! Welcome to GeFontyst trials! Please, talk to the purple festival magician for some more info";
    }

    // Update is called once per frame
    void Update()
    {
        if (onStart)
        {
            onStartTimer -= Time.deltaTime;
            if (onStartTimer <= 0)
            {
                dialogue.text = "";
                onStart = false;
            }
        }
        
        if (onWizardCollision)
        {
            onWizardTimer -= Time.deltaTime;
            if (onWizardTimer <= 0)
            {
                dialogue.text = "";
                onWizardCollision = false;
            }
        }
        
        if (onWizard1Collision)
        {
            onWizard1Timer -= Time.deltaTime;
            if (onWizard1Timer <= 0)
            {
                dialogue.text = "";
                onWizard1Collision = false;
            }
        }
        
        if (onItemPickUp)
        {
            onItemTimer -= Time.deltaTime;
            if (onItemTimer <= 0)
            {
                dialogue.text = "";
                onItemPickUp = false;
            }
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TutorialWizzard") && !onStart && !onWizard1Collision && !onItemPickUp)
        {
            onWizardCollision = true;
            dialogue.text =  
                "Greetings Bob! Hereby, I present to you the Fire Laser! It's a small, but powerful spell, use it wisely! Have you spoken with Carl The Green yet?";
        }
        if (collision.gameObject.CompareTag("TutorialWizzard1") && !onStart && !onWizardCollision && !onItemPickUp)
        {
            onWizard1Collision = true;
            dialogue.text =  
                "Hello there, are you new here? Hmm... I think Fireball is what you need in order to get the proficiency... Be careful though, it's a powerful spell!";
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TutorialItem") && !onStart && !onWizard1Collision && !onWizardCollision)
        {
            onItemPickUp = true;
            dialogue.text = 
                "Oh what is this... a staff? I can feel the power... My intellect and stamina are increased? Amazing! Is that... a new spell? Wonder what it does...";
        }
    }
}
