using UnityEngine;

public class PlayerCurrentRoadHandler : MonoBehaviour
{
    [SerializeField] private Road[] _roads;
    [SerializeField] private int _currentRoadIndex;

    private Road _currentRoad;

    private void Start()
    {
        SetCurrentRoad();
    }

    public Road GetCurrentRoad()
    {
        return _currentRoad;
    }

    public Road SetCurrentRoad(int indexModifier = 0)
    {
        int nextRoadIndex = _currentRoadIndex + indexModifier;

        if(nextRoadIndex >= 0 && nextRoadIndex < _roads.Length)
        {
            _currentRoadIndex = nextRoadIndex;
        }

        return _currentRoad = _roads[_currentRoadIndex];
    }
}
