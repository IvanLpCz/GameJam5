using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteProgres : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteAll();
    }
}
