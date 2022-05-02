using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnockOutNextScene : MonoBehaviour
{
    public string nextScene;
    //Triggers when becomes active
    void OnEnable()
    {
        SceneManager.LoadScene(nextScene);
    }
}
