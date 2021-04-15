using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProceedNextRoom : MonoBehaviour
{
    private DoorAppear da;
    SpellGain spell;

    public int roomNumber;
    void Start()
    {
        da = GameObject.FindGameObjectWithTag("Door").GetComponent<DoorAppear>();
        spell = GetComponent<SpellGain>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (da.isOpen && collision.gameObject.CompareTag("Door"))
        {
            Debug.Log("Proceed to level 2");
            spell.gainMeteor = false;
            spell.gainFireBall = false;
            spell.gainIncinerate = false;
            SceneManager.LoadScene($"Level{roomNumber}");
        }
    }
}
