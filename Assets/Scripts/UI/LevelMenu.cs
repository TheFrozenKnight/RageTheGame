using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{

    int LevelsUnlocked;

    public Button[] buttons;

    void Start()
    {
        LevelsUnlocked = PlayerPrefs.GetInt("LevelsUnlocked", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < LevelsUnlocked; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void LoadLevel(int LevelIndex)
    {
        SceneManager.LoadScene(LevelIndex);
    }
    public void ResetProgression()
    {
        PlayerPrefs.DeleteKey("LevelsUnlocked");
        Start();
    }
    public void OnBackButtonClick()
    {
        SceneManager.LoadScene("StartMenu");
    }
}