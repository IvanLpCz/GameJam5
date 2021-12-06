using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class firstMenu : MonoBehaviour
{
    public Button play, exit;
    public GameObject playMenu, selectLevelMenu;

    public void SelectLevel()
    {
        playMenu.SetActive(false);
        selectLevelMenu.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
