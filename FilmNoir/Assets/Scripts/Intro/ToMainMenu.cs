using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainMenu : MonoBehaviour
{
    //Triggers when becomes active
    void OnEnable()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
