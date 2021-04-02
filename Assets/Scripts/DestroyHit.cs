using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHit : MonoBehaviour
{
    // Start is called before the first frame update
    public float destructionTimer = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        destructionTimer -= Time.deltaTime;
        if (destructionTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
