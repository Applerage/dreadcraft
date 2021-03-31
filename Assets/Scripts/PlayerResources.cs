using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    private float currentHealth;
    public float maxHealth;
    public float level;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
