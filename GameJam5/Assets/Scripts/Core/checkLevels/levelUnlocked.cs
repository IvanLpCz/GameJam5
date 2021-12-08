using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelUnlocked : MonoBehaviour
{
    public static bool unlocked2, unlocked3;

    levelFinish levelend;
    loadProgres saveData;

    private void Start()
    {
        //if (SceneManager.GetActiveScene().name == "MainMenu")
        //{

        //}
        //else
        //{
        //    levelend = GameObject.Find("finishLevel").GetComponent<levelFinish>();
        //}
        saveData = GameObject.Find("SaveData").GetComponent<loadProgres>();
        if(saveData.saveUnlock2 == 1)
        {
            unlocked2 = true;
        }
        if (saveData.saveUnlock3 == 1)
        {
            unlocked3 = true;
        }
    }

    //private void Update()
    //{
    //    if (SceneManager.GetActiveScene().name == "Level1" && levelend.level2Unlocked)
    //    {
    //        unlocked2 = true;
    //    }
    //    if (SceneManager.GetActiveScene().name == "Level2" && levelend.level3Unlocked)
    //    {
    //        unlocked3 = true;
    //    }
    //}
}
