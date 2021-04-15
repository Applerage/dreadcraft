using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentTreePoints : MonoBehaviour
{
    private PlayerResources pr;

    public Text talentPoints;
    void Start()
    {
        pr = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerResources>();
    }
    void Update()
    {
        talentPoints.text = $"Talent Points: {pr.currentTalentPoints}";
    }
}
