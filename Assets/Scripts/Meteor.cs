using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meteor : MonoBehaviour
{
    Fireball fireball;

    public float cooldownTime = 0.8f;
    private float nextFireTime = 0f;

    public bool casting = false;
    public float castTime;
    private float timerCastTime;

    public bool isOnCd = false;
    private float cooldownTimer;

    public Image meteorLoading;
    public Text meteorCd;
    public Image fireOverlay;

    [SerializeField] ParticleSystem castParticles;

    public GameObject spell;
    public Transform firePoint;
    public float spellSpeed = 50;
    public GameObject player;

    Vector2 lookDirection;
    float lookAngle;

    SpellGain pickUp;

    private void Start()
    {
        timerCastTime = castTime;
        fireball = GetComponent<Fireball>();
        pickUp = GetComponent<SpellGain>();
        cooldownTimer = cooldownTime;
        fireOverlay.enabled = false;
    }

    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(player.transform.position.x, player.transform.position.y);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);
        if (pickUp.gainMeteor == true)
        {
            meteorLoading.fillAmount = 0;
            if (fireball.castingFireBall == false)
            {
                if (timerCastTime <= 0.0f)
                {
                    GameObject spellClone = Instantiate(spell);
                    spellClone.transform.position = firePoint.position;
                    spellClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

                    spellClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * spellSpeed;
                    nextFireTime = Time.time + cooldownTime;
                    cooldownTimer = cooldownTime;
                    timerCastTime = castTime;
                    casting = false;
                    fireOverlay.enabled = false;
                    castParticles.Stop();
                }
                if (Time.time > nextFireTime)
                {
                    if (casting == true)
                    {
                        timerCastTime -= Time.deltaTime;
                    }
                    if (Input.GetKeyDown(KeyCode.Alpha3))
                    {
                        casting = true;
                        fireOverlay.enabled = true;
                        castParticles.Play();
                    }
                    isOnCd = false;
                }
                
            }
            if (Time.time <= nextFireTime)
            {
                isOnCd = true;

            }
            if (isOnCd)
            {
                cooldownTimer -= Time.deltaTime;
                meteorLoading.fillAmount = cooldownTimer / cooldownTime;
                meteorCd.text = (cooldownTimer % cooldownTime).ToString();
                if (meteorLoading.fillAmount <= 0.03f)
                {
                    meteorCd.text = "";
                }
            }

        }
        else
        {
            meteorLoading.fillAmount = 1;
        }
    }
}
