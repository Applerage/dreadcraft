using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public float maxHp = 100;
    private float currentHp;
    public DoorAppear da;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        da = GameObject.FindGameObjectWithTag("Door").GetComponent<DoorAppear>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(float amount)
    {
        currentHp -= amount;
        Debug.Log(currentHp);
        if (currentHp <= 0)
        {
            currentHp = 0;
            Destroy(gameObject);
            da.count++;
            da.openDoor();
        }
    }
}
