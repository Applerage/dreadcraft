using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentTreePoints : MonoBehaviour
{
    private PlayerResources pr;

    public Text talentPoints;
    // Start is called before the first frame update
    void Start()
    {
        pr = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerResources>();
    }

    // Update is called once per frame
    void Update()
    {
        talentPoints.text = $"Talent Points: {pr.currentTalentPoints}";
    }
}
