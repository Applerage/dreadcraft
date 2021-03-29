using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float cooldownTime = 1f;
    private float nextFireTime = 0f;

    public GameObject bullet;
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

        if (Time.time > nextFireTime)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                GameObject bulletClone = Instantiate(bullet);
                bulletClone.transform.position = firePoint.position;
                bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

                bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
                nextFireTime = Time.time + cooldownTime;
            }
        }
            
    }
}
