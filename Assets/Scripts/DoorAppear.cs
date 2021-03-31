using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAppear : MonoBehaviour
{
    public ParticleSystem particles;
    public int count;
    public bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openDoor()
    {
        if(count >= 3)
        {
            particles.Play();
            isOpen = true;
        }
    }
}
