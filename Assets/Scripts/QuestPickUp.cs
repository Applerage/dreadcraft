using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPickUp : MonoBehaviour
{
    public bool gainSpell = false;
    public GameObject questCompleted;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TutorialWizzard")
        {
            gainSpell = true;
            Destroy(questCompleted);
        }
    }
}
