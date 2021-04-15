using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    public int difficulty;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
