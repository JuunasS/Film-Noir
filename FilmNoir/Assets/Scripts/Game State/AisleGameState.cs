using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AisleGameState : MonoBehaviour
{
    public GameObject AisleDoor;

    // Start is called before the first frame update
    void Start()
    {
        AisleDoor.GetComponent<DoorItem>().levelToLoad = GameManager.manager.GameState.ApartmentSceneName;
    }
}
