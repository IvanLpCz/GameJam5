using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class selectLevelMenu : MonoBehaviour
{
    public Button level1, level2, level3, back, toLevel2, toLevel3, backLevel2, backLevel1;
    public GameObject canvasLevels, canvasLevel1, canvasLevel2, canvasLevel3, canvasMain;
    public AudioClip block;
    public AudioSource source;
    public bool canLevel2, canLevel3;

    public void playLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void playLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void playLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void backToMain()
    {
        canvasLevels.SetActive(false);
        canvasMain.SetActive(true);
    }
    public void ToLevel2()
    {
        if (!canLevel2)
        {
            source.PlayOneShot(block, 0.7f);
        }
        if (canLevel2)
        {
            canvasLevel1.SetActive(false);
            canvasLevel2.SetActive(true);
        }
    }
    public void ToLevel3()
    {
        if (!canLevel3)
        {
            source.PlayOneShot(block, 0.7f);
        }
        if (canLevel3)
        {
            canvasLevel2.SetActive(false);
            canvasLevel3.SetActive(true);
        }
    }
    public void backToLevel1()
    {
        canvasLevel2.SetActive(false);
        canvasLevel1.SetActive(true);
    }
    public void backToLevel2()
    {
        canvasLevel3.SetActive(false);
        canvasLevel2.SetActive(true);
    }
}
