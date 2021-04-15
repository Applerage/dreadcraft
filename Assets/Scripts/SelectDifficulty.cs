using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectDifficulty : MonoBehaviour
{
    public Toggle toggleNormal;

    public Toggle toggleInsane;

    public Difficulty difficulty;
    void Start()
    {
        difficulty = GameObject.FindGameObjectWithTag("Difficulty").GetComponent<Difficulty>();
    }
    void Update()
    {
        if (toggleNormal.isOn)
        {
            difficulty.difficulty = 0;
        }
        else if (toggleInsane.isOn)
        {
            difficulty.difficulty = 1;
        }
    }
}
