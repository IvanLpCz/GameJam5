using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class inGame : MonoBehaviour
{
    public Button resume, restart, exit;
    private Scene actualScene;
    public GameObject inGameHUD, pauseMenu;

    public void Start()
    {
        actualScene = SceneManager.GetActiveScene();
    }
    public void ContinueButton()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        inGameHUD.SetActive(true);
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(actualScene.name);
        Time.timeScale = 1;
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
