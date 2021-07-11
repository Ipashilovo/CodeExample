using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColorLooker : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private EnemyRoadHandler _enemyRoadHandler;
    [SerializeField] private EnemyMovement _enemyMovement;

    private void OnEnable()
    {
        _enemy.MaterialChanged += OnMaterialChanged;
    }

    private void OnDisable()
    {
        _enemy.MaterialChanged -= OnMaterialChanged;
    }

    private void OnMaterialChanged()
    {
        StartCoroutine(ChangeColorDelay());
    }

    private void SwitchRoad()
    {
        Road road = _enemyRoadHandler.FindRoadByCurrentColor(_enemy.ObjectColor, out int jumps);
        _enemyMovement.SwitchRoad(road, jumps);
    }

    private IEnumerator ChangeColorDelay()
    {
        float delay = 0.7f;
        yield return new WaitForSeconds(delay);
        SwitchRoad();
    }
}
