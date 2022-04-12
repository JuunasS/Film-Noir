using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorItem : Interactable
{

    public string levelToLoad;

    public override void Interact() 
    {
        base.Interact();
        SceneManager.LoadScene(levelToLoad);
    }
}
