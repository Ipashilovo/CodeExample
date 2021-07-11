using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeLooker : MonoBehaviour
{
    [SerializeField] private int _maxLife;
    [SerializeField] private Animator _cameraAnimation;
    private int _currentLife;

    public event Action LifeEnded;

    private void Start()
    {
        _currentLife = _maxLife;
    }

    public void TakeDamage()
    {
        _currentLife -= 1;
        _cameraAnimation.Play("Camera");
        if (_currentLife <= 0)
        {
            LifeEnded?.Invoke();
        }
    }
    
    
}
