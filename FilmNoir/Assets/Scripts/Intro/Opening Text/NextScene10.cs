using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene10 : MonoBehaviour
{
    //Triggers when becomes active
    void OnEnable()
    {
        SceneManager.LoadScene("02Pawnshop");
    }
}