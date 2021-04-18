using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMusic : MonoBehaviour
{
    public SoundManager soundManager;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            soundManager.ambientSound.Stop();
            soundManager.dungeon2.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            soundManager.ambientSound.Play();
            soundManager.dungeon2.Stop();
        }
    }

    
    // Update is called once per frame
    void Update()
    {

    }
}
