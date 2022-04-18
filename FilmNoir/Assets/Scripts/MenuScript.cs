using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.Find("MiniMenu");
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            menu.SetActive(!menu.activeInHierarchy);
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Panttilainaamo");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TitleReturn()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
