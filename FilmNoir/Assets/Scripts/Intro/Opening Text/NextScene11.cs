using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene11 : MonoBehaviour
{
    //Triggers when becomes active
    void OnEnable()
    {
        SceneManager.LoadScene("KnockedOutCutscene");
    }
}
