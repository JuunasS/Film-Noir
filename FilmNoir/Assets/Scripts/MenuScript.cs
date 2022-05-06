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
        Debug.Log("MenuScript Start");
        if (GameManager.manager.GetMenuCanvas() != null)
        {
            //Debug.Log("Destroy MenuScript");
            Destroy(gameObject);
        }
        else
        {
            GameManager.manager.SetMenuCanvas(gameObject);
            DontDestroyOnLoad(gameObject);
        }

        if(GameObject.Find("MiniMenu") != null)
        {
            menu = GameObject.Find("MiniMenu");
            menu.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "MainMenu"){
            menu.SetActive(!menu.activeInHierarchy);
            if (!menu.activeInHierarchy)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
            PlayerController.canMove = !PlayerController.canMove;
            if (settingsMenu.activeInHierarchy)
            {
                ToggleSettingsMenu();
            }
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Intro");
    }

    public void QuitGame()
    {
        PlayerController.canMove = !PlayerController.canMove;
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
            PlayerController.canMove = !PlayerController.canMove;
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
        menu.SetActive(!menu.activeInHierarchy);
        if (settingsMenu.activeInHierarchy)
        {
            ToggleSettingsMenu();
        }
        SceneManager.LoadScene("MainMenu");
    }

    public void ToggleSettingsMenu()
    {
        settingsMenu.SetActive(!settingsMenu.activeInHierarchy);
    }

}
