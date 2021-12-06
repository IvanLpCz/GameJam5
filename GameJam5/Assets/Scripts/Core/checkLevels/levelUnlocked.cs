using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelUnlocked : MonoBehaviour
{
    public static bool unlocked2, unlocked3;

    levelFinish levelend;

    private void Start()
    {
        levelend = GameObject.Find("finishLevel").GetComponent<levelFinish>();
    }

    private void Update()
    {
        if (levelend.level2Unlocked)
        {
            unlocked2 = true;
        }
    }
}
