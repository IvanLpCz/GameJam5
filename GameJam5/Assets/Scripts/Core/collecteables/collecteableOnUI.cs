using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class collecteableOnUI : MonoBehaviour
{
    public TextMeshProUGUI amountOfCollecteables;
    public int pickedCollecteables;
    private void Update()
    {
        amountOfCollecteables.text = "" + pickedCollecteables;
    }
}
