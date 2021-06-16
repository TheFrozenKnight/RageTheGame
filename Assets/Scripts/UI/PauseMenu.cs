using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsGamePaused = false;

    public GameObject pauseMenuPanel, optionsMenuPanel;
    public GameObject pauseFirstButton, optionsFirstButton, optionsClosedButton;

    public void Resume()
    {
        pauseMenuPanel.SetActive(false);
        optionsMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
    }
    public void Pause()
    {
        pauseMenuPanel.SetActive(true);
        optionsMenuPanel.SetActive(false);
        Time.timeScale = 0f;
        IsGamePaused = true;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        IsGamePaused = false;
        SceneManager.LoadScene("StartMenu");
    }
    public void OptionsMenu()
    {
        optionsMenuPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsFirstButton);
    }
    public void ToggleMusic()
    {
        
    }
    public void ToggleSFX()
    {
        
    }
    public void CloseOptionsMenu()
    {
        optionsMenuPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsClosedButton);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
