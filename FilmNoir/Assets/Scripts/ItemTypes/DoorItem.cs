using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorItem : Interactable
{

    public string levelToLoad;
    public bool doesGameStateChange = false;

    public GameState newGameState;

    public override void Interact() 
    {
        base.Interact();
        if (doesGameStateChange && newGameState != null)
        {
            GameManager.manager.SetGameState(newGameState);
        }
        SceneManager.LoadScene(levelToLoad);
    }
}
