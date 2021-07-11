using UnityEngine;

public class Player : Unit
{
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private PlayerCurrentRoadHandler _currentRoadHandler;

    public PlayerMovement Movement => _movement;
    public PlayerCurrentRoadHandler RoadHandler => _currentRoadHandler;
    
}
