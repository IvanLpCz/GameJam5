using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collecteableOnManager : MonoBehaviour
{
    public static int pickedCollecteableslvl1, pickedCollecteableslvl2, pickedCollecteableslvl3;
    public int picked1, picked2, picked3;
    public bool lvl1, lvl2, lvl3;
    private collecteableOnUI collUI;
    loadProgres saveData;

    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {

        }
        else
        {
            collUI = GameObject.Find("collecteableManager").GetComponent<collecteableOnUI>();
        }
        saveData = GameObject.Find("SaveData").GetComponent<loadProgres>();


        picked1 = saveData.collecteables1;
        picked2 = saveData.collecteables2;
        picked3 = saveData.collecteables3;

    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            lvl1 = true;
            lvl2 = false;
            lvl3 = false;
        }
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            lvl1 = false;
            lvl2 = true;
            lvl3 = false;
        }
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            lvl1 = false;
            lvl2 = false;
            lvl3 = true;
        }
        if (lvl1 && SceneManager.GetActiveScene().name == "Level1")
        {
            pickedCollecteableslvl1 = collUI.pickedCollecteables;
            PlayerPrefs.GetInt("collecteablesLvl1", pickedCollecteableslvl1);
        }
        if (lvl2 && SceneManager.GetActiveScene().name == "Level2")
        {
            pickedCollecteableslvl2 = collUI.pickedCollecteables;
            PlayerPrefs.GetInt("collecteablesLvl2", pickedCollecteableslvl2);
        }
        if (lvl3 && SceneManager.GetActiveScene().name == "Level3")
        {
            pickedCollecteableslvl3 = collUI.pickedCollecteables;
            PlayerPrefs.GetInt("collecteablesLvl3", pickedCollecteableslvl3);
        }
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            picked1 = PlayerPrefs.GetInt("collecteablesLvl1");
            picked2 = PlayerPrefs.GetInt("collecteablesLvl2");
            picked3 = PlayerPrefs.GetInt("collecteablesLvl3");
        }
    }
}
