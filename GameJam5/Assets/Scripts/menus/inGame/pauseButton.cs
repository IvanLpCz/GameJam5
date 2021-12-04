using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseButton : MonoBehaviour
{
    public Button pause;
    public GameObject pauseMenu;
    public GameObject playerHud;
    public void PauseMenuButton()
    {
        Time.timeScale = 0;
        playerHud.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
