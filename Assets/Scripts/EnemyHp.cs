using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public float maxHp = 100;
    private float currentHp;
    private DoorAppear da;
    private float animationTimer = 1f;
    private bool isDead = false;
    public Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        da = GameObject.FindGameObjectWithTag("Door").GetComponent<DoorAppear>();
        if (maxHp >= 100)
        {
            animationTimer = 1.8f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            animationTimer -= Time.deltaTime;
        }

        if (animationTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void takeDamage(float amount)
    {
        currentHp -= amount;
        animator.Play("TakeDamage");
        Debug.Log(currentHp);
        if (currentHp <= 0)
        {
            isDead = true;
            animator.Play("Die");
            currentHp = 0;
            da.count++;
            da.openDoor();
        }
    }
}
