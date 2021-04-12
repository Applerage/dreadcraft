using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoorLock : MonoBehaviour
{
    public GameObject finalBossDoor;
    // Start is called before the first frame update
    void Start()
    {
        finalBossDoor.SetActive(false);
    }
}
