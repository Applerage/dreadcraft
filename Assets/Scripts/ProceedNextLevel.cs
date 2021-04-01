using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProceedNextLevel : MonoBehaviour
{
    private DoorAppear da;
    SpellGain spell;

    public int levelNumber;
    // Start is called before the first frame update
    void Start()
    {
        da = GameObject.FindGameObjectWithTag("Door").GetComponent<DoorAppear>();
        spell = GetComponent<SpellGain>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (da.isOpen && collision.gameObject.CompareTag("Door"))
        {
            Debug.Log("Proceed to level 2");
            spell.gainMeteor = false;
            spell.gainFireBall = false;
            SceneManager.LoadScene($"Level{levelNumber}");
        }
    }
}
