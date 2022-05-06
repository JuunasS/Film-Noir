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
        GameManager.manager.LoadPrefs();
        GameManager.manager.LoadScene(GameManager.manager.currentSceneName);

    }

    public void ToggleSettingsMenu()
    {
        settingsMenu.SetActive(!settingsMenu.activeInHierarchy);
    }

}
