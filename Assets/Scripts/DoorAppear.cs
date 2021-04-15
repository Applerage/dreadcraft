using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAppear : MonoBehaviour
{
    public ParticleSystem particles;
    public int count;
    public bool isOpen = false;
    public void openDoor()
    {
        if(count >= 3)
        {
            particles.Play();
            isOpen = true;
        }
    }
}
