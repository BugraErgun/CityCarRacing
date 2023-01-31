using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [Header("All Menu")]
    public GameObject pauseMenu;
    public GameObject playerUI;
    public static bool GameIsStoppped = false;
    
    public void Resume()
    {
        pauseMenu.SetActive(false);
        playerUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsStoppped = false;

    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        playerUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsStoppped = true;
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;

    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

    }
    public void QuitGame()
    {
        Debug.Log("Quiting");
        Application.Quit();

    }
    
}
