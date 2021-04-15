using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientMusic : MonoBehaviour
{
    public SoundManager soundManager;
    void Start()
    {
        soundManager.ambientSound.Play();
    }

}
