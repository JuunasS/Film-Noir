using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string nextScene;
    //Triggers when becomes active
    void OnEnable()
    {
        SceneManager.LoadScene(nextScene);
    }
}
