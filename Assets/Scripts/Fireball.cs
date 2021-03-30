using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public bool gainSpell = false;

    public float cooldownTime = 1f;
    private float nextFireTime = 0f;

    public float castTime = 0.8f;

    public GameObject spell;
    public Transform firePoint;
    public float bulletSpeed = 50;
    public GameObject player;

    Vector2 lookDirection;
    float lookAngle;
    
    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(player.transform.position.x, player.transform.position.y);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        if(gainSpell == true)
        {
            if (Time.time > nextFireTime)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    GameObject bulletClone = Instantiate(spell);
                    bulletClone.transform.position = firePoint.position;
                    bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

                    bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
                    nextFireTime = Time.time + cooldownTime;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TutorialWizzard")
        {
            gainSpell = true;
            Debug.Log(gainSpell);
        }
    }
}
