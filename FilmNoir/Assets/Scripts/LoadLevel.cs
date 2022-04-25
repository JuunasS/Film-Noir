using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string levelToLoad;
    public static bool isActive = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetLevelToLoad(string level)
    {
        levelToLoad = level;
        if(levelToLoad != "")
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void LoadTheLevel()
    {
        if (levelToLoad != "")
        {
            GameManager.manager.LoadScene(levelToLoad);
        }
        else
        {
            Debug.Log("Scene is not open in this GameState");
        }
    }
}
