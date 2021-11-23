using System;
using DG.Tweening;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField] private float _punch = 0.1f;
    [SerializeField] private float _time = 0.5f;
    [SerializeField] private int _vibrato = 3;
    private Tween _tween;

    private void Start()
    {
        _tween = transform.DOPunchScale(new Vector3(_punch, _punch, _punch), _time, _vibrato, 1f).SetLoops(-1);
    }
}