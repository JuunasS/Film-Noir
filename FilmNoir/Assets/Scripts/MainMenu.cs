using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject settingsMenu;

    public void NewGame()
    {
        SceneManager.LoadScene("Intro");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadGame()
    {
        if (GameManager.manager.CheckSave())
        {
            GameManager.manager.LoadPrefs();
            GameManager.manager.LoadScene(GameManager.manager.currentSceneName);
        }
        else
        {
            Debug.Log("No GameSaves exist");
        }
    }

    public void ToggleSettingsMenu()
    {
        settingsMenu.SetActive(!settingsMenu.activeInHierarchy);
    }

}
