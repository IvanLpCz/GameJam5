using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadProgres : MonoBehaviour
{
    public int saveUnlock2, saveUnlock3;
    public int collecteables1, collecteables2, collecteables3;

    private void Update()
    {
        saveUnlock2 = PlayerPrefs.GetInt("unlokedLvl2", 0);
        saveUnlock3 = PlayerPrefs.GetInt("unlokedLvl3", 0);
        collecteables1 = PlayerPrefs.GetInt("collecteablesLvl1", 0);
        collecteables2 = PlayerPrefs.GetInt("collecteablesLvl2", 0);
        collecteables3 = PlayerPrefs.GetInt("collecteablesLvl3", 0);
    }
}
