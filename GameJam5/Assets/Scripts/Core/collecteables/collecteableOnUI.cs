using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class collecteableOnUI : MonoBehaviour
{
    public TextMeshProUGUI amountOfCollecteables;
    public int pickedCollecteables;
    public bool lvl1, lvl2, lvl3;
    private void Update()
    {
        amountOfCollecteables.text = "" + pickedCollecteables;
        if (lvl1)
        {
            PlayerPrefs.SetInt("collecteablesLvl1", pickedCollecteables);
        }
        if (lvl2)
        {
            PlayerPrefs.SetInt("collecteablesLvl2", pickedCollecteables);
        }
        if (lvl3)
        {
            PlayerPrefs.SetInt("collecteablesLvl3", pickedCollecteables);
        }
    }
}
