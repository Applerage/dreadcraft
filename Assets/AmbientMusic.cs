using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientMusic : MonoBehaviour
{
    public SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        soundManager.ambientSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
