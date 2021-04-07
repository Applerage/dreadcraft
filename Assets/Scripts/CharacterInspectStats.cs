using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInspectStats : MonoBehaviour
{
    public Text stamina;
    public Text intellect;
    public Text level;
    private PlayerResources pr;
    public Text health;
    void Start()
    {
        pr = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerResources>();
        stamina.text = "";
        intellect.text = "";
        level.text = "";
        health.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        stamina.text = $"Stamina: {pr.stamina}";
        intellect.text = $"Intellect: {pr.intellect}";
        level.text = $"Level {pr.currentLevel} Magician";
        health.text = $"{pr.currentHealth} / {pr.maxHealth}";
    }
}
