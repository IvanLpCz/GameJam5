using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class collecteablesAchive : MonoBehaviour
{
    public TextMeshProUGUI collecteables1, collecteables2, collecteables3;
    private int pickedlvl1, pickedlvl2, pickedlvl3;
    private collecteableOnManager collecteableManager;

    private void Start()
    {
        collecteableManager = GameObject.Find("GameManager").GetComponent<collecteableOnManager>();
        pickedlvl1 = collecteableManager.picked1;
        pickedlvl2 = collecteableManager.picked2;
        pickedlvl3 = collecteableManager.picked3;
    }
    private void Update()
    {
        collecteables1.text = "" + pickedlvl1;
        collecteables2.text = "" + pickedlvl2;
        collecteables3.text = "" + pickedlvl3;
    }
}
