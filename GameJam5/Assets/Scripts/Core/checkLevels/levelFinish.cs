using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelFinish : MonoBehaviour
{
    public bool level2Unlocked, level3Unlocked;
    public bool onLevel1, onLevel2, onLevel3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (onLevel1)
        {
            level2Unlocked = true;
            PlayerPrefs.SetInt("unlokedLvl2", 1);
            SceneManager.LoadScene("MainMenu");
        }
        if (onLevel2)
        {
            level3Unlocked = true;
            PlayerPrefs.SetInt("unlokedLvl3", 1);
            SceneManager.LoadScene("MainMenu");
        }
        if (onLevel3)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
