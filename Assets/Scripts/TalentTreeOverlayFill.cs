using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentTreeOverlayFill : MonoBehaviour
{
    private TalentTreeUnlock ttu;
    private PlayerResources pr;
    public Image unlockedOverlay1;
    public Image unlockedOverlay2;
    public Image unlockedOverlay3;
    public Image unlockedOverlay4;
    public Image unlockedOverlay5;
    public Image unlockedOverlay6;
    public Image unlockedOverlay7;
    public Image unlockedOverlay8;
    public Image unlockedOverlay9;
    public Image unlockedOverlay10;

    public Image explosion;
    // Start is called before the first frame update
    void Start()
    {
        pr = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerResources>();
        ttu = gameObject.GetComponent<TalentTreeUnlock>();
        unlockedOverlay1.fillAmount = 1;
        unlockedOverlay2.fillAmount = 1;
        unlockedOverlay3.fillAmount = 1;
        unlockedOverlay4.fillAmount = 1;
        unlockedOverlay5.fillAmount = 1;
        unlockedOverlay6.fillAmount = 1;
        unlockedOverlay7.fillAmount = 1;
        unlockedOverlay8.fillAmount = 1;
        unlockedOverlay9.fillAmount = 1;
        unlockedOverlay10.fillAmount = 1;
        explosion.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ttu.TT1IsUnlocked)
        {
            unlockedOverlay1.fillAmount = 0;
        }
        if (ttu.TT11IsUnlocked)
        {
            unlockedOverlay2.fillAmount = 0;
        }
        if (ttu.TT2IsUnlocked)
        {
            unlockedOverlay3.fillAmount = 0;
        }
        if (ttu.TT21IsUnlocked)
        {
            unlockedOverlay4.fillAmount = 0;
        }
        if (ttu.TT3IsUnlocked)
        {
            unlockedOverlay5.fillAmount = 0;
        }
        if (ttu.TT31IsUnlocked)
        {
            unlockedOverlay6.fillAmount = 0;
        }
        if (ttu.TT4IsUnlocked)
        {
            unlockedOverlay7.fillAmount = 0;
        }
        if (ttu.TT41IsUnlocked)
        {
            unlockedOverlay8.fillAmount = 0;
        }
        if (ttu.TT5IsUnlocked)
        {
            unlockedOverlay9.fillAmount = 0;
        }
        if (ttu.TT51IsUnlocked)
        {
            unlockedOverlay10.fillAmount = 0;
        }

        if (pr.currentTalentPoints > 0)
        {
            explosion.enabled = true;
        }
        else
        {
            explosion.enabled = false;
        }
    }
}
