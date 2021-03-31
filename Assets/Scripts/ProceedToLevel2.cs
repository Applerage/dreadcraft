using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceedToLevel2 : MonoBehaviour
{
    private DoorAppear da;
    public GameObject door;
    QuestPickUp spell;
    // Start is called before the first frame update
    void Start()
    {
        da = GameObject.FindGameObjectWithTag("Door").GetComponent<DoorAppear>();
        spell = GetComponent<QuestPickUp>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (da.isOpen == true && collision.gameObject.tag == "Door")
        {
            Debug.Log("Proceed to level 2");
            spell.gainMeteor = false;
            spell.gainFireBall = false;
        }
    }
}
