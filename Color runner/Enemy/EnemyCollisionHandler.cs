using System;
using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _checkSpeedDelay;
    
    private float _currentTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Road road))
        {
            ResetSpeedIfNeedIt(road);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        _currentTime += Time.deltaTime;
        
        if (_currentTime < _checkSpeedDelay) return;
        
        _currentTime = 0;
        if(other.TryGetComponent(out Road road))
        {
            ResetSpeedIfNeedIt(road);
        }
    }

    private void ResetSpeedIfNeedIt(Road road)
    {
        if (_enemy.ObjectColor != road.ObjectColor)
        {
            _enemy.ReduceSpeed();
        }
        else
        {
            _enemy.ResetSpeed();
        }
    }
}
