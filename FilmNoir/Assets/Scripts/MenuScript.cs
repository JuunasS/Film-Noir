using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    public GameObject menu;
    public GameObject settingsMenu;

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("MiniMenu") != null)
        {
            menu = GameObject.Find("MiniMenu");
            menu.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            menu.SetActive(!menu.activeInHierarchy);
            PlayerController.canMove = !PlayerController.canMove;
            if (settingsMenu.activeInHierarchy)
            {
                ToggleSettingsMenu();
            }
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Toimisto");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void SaveGame()
    {
        GameManager.manager.SavePrefs();
    }

    public void LoadGame()
    {
        if(GameManager.manager.CheckSave())
        {
            GameManager.manager.LoadPrefs();
            GameManager.manager.LoadScene(GameManager.manager.currentSceneName);
        }
        else
        {
            Debug.Log("No GameSaves exist");
        }

    }

    public void TitleReturn()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ToggleSettingsMenu()
    {
        settingsMenu.SetActive(!settingsMenu.activeInHierarchy);
    }

}
