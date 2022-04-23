using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Game State", menuName = "Game State/New Game State")]
public class GameState : ScriptableObject
{
    public Scene[] UnlockedScenes;

    public GameState NextGameState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
