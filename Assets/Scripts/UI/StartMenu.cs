using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StartMenu : MonoBehaviour
{

    public GameObject optionsMenuPanel, creditsPanel;
    public GameObject optionsFirstButton, optionsClosedButton, creditsFirstButton, creditsClosedButton;

    public void onPlayButtonClick()
    {
        SceneManager.LoadScene("lvl1");
    }
    public void onLevelsButtonClick()
    {
        SceneManager.LoadScene("lvlMenu");
    }
    public void onOptionsButtonClick()
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
    public void onOptionsBackButtonClick()
    {
        optionsMenuPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsClosedButton);
    }

    public void onCreditsButtonClick()
    {
        creditsPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(creditsFirstButton);
    }
    public void onCreditsBackButtonClick()
    {
        creditsPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(creditsClosedButton);
    }
    public void onExitButtonClick()
    {
        Application.Quit();
    }
}
