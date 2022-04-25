using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public GameState CurrentGameState;

    // Start is called before the first frame update
    void Start()
    {
        CurrentGameState = GameManager.manager.GameState;
        UpdateGameState();
    }

    private void UpdateGameState()
    {

    }
}
