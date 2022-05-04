using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AisleGameState : MonoBehaviour
{
    public GameObject AisleDoor;
    public bool isItTheClosedDoor = false;

    // Start is called before the first frame update
    void Start()
    {
        if (isItTheClosedDoor)
        {
            AisleDoor.GetComponent<ClosedDoor>().levelToLoad = GameManager.manager.GameState.ApartmentSceneName;
        }
        else
            AisleDoor.GetComponent<DoorItem>().levelToLoad = GameManager.manager.GameState.ApartmentSceneName;
    }
}
