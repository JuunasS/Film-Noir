using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game State", menuName = "Game State/New Game State")]
[System.Serializable]
public class GameState : ScriptableObject
{
    public string OfficeSceneName;
    public string ApartmentAisleSceneName;
    public string ApartmentSceneName;
    public string PawnshopSceneName;
    public string HairsaloonSceneName;
    public string ClubSceneName;
    public string ParkSceneName;
    public string BarSceneName;
}
