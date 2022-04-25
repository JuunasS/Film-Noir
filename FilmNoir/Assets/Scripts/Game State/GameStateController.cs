using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    public GameState CurrentGameState;

    public Button OfficeButton;
    public Button ApartmentButton;
    public Button PawnshopButton;
    public Button HairsaloonButton;
    public Button ClubButton;
    public Button ParkButton;
    public Button BarButton;

    // Start is called before the first frame update
    void Start()
    {
        CurrentGameState = GameManager.manager.GameState;
        UpdateGameState();
    }

    private void UpdateGameState()
    {
        // Change buttons to corresponding gamestate scenes.

        // Office Scene
        OfficeButton.GetComponent<LoadLevel>().SetLevelToLoad(CurrentGameState.OfficeSceneName);

        // Apartment Scene goes to aisle
        /*
        if (CurrentGameState.ApartmentSceneName != null)
        {
            ApartmentButton.GetComponent<LoadLevel>().levelToLoad = CurrentGameState.ApartmentSceneName;
        }
        */

        // Pawnshop Scene
        PawnshopButton.GetComponent<LoadLevel>().SetLevelToLoad(CurrentGameState.PawnshopSceneName);

        // HairSaloon Scene
        HairsaloonButton.GetComponent<LoadLevel>().SetLevelToLoad(CurrentGameState.HairsaloonSceneName);

        // Club Scene
        ClubButton.GetComponent<LoadLevel>().SetLevelToLoad(CurrentGameState.ClubSceneName);

        // Park Scene
        ParkButton.GetComponent<LoadLevel>().SetLevelToLoad(CurrentGameState.ParkSceneName);

        // Bar Scene
        BarButton.GetComponent<LoadLevel>().SetLevelToLoad(CurrentGameState.BarSceneName);


    }
}
