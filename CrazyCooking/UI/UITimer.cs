using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    [SerializeField] private Image _timer;
    private float _step;
    
    private void Update()
    {
        _timer.fillAmount -= _step * Time.deltaTime;
    }
    
    public void SetTime(float time)
    {
        _timer.fillAmount = 1;
        _step = 1 / time;
        Color color = _timer.color;
        color.a = 1;
        _timer.color = color;
    }

    public void Hide()
    {
        Color color = _timer.color;
        color.a = 0;
        _timer.color = color;
    }
}
