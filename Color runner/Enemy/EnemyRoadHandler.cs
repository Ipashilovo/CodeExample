using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyRoadHandler : MonoBehaviour
{
    [SerializeField] private List<Road> _roads;
    [SerializeField] private int _startRoadIndex;
    private int _roadIndex;

    private void Awake()
    {
        _roadIndex = _startRoadIndex;
    }

    public Road FindRoadByCurrentColor(ObjectColor color, out int distanceBetweenRoad)
    {
        Road newRoad = _roads.First(road => road.ObjectColor == color);
        int index = _roads.IndexOf(newRoad);
        distanceBetweenRoad = Mathf.Abs(_roadIndex - index);
        _roadIndex = index;
        return newRoad;
    }
}
