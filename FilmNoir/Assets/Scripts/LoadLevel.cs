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
        if (!isActive)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadTheLevel()
    {
        GameManager.manager.LoadScene(levelToLoad);
    }
}
