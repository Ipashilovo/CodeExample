using System;
using UnityEngine;

public class ArmIcon : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private InterectionObj _interectionObj;
    [SerializeField] private Vector3 _targetDelta;

    private Vector3 _previousTargetPosition;

    private bool _isShow;

    private void OnEnable()
    {
        _interectionObj.Droping += Show;
        _interectionObj.Taking += Hide;
    }

    private void OnDisable()
    {
        _interectionObj.Droping -= Show;
        _interectionObj.Taking -= Hide;
    }

    private void Start()
    {
        _isShow = true;
    }

    private void Update()
    {
        if (_isShow == false || _previousTargetPosition == _interectionObj.transform.position) return;

        Vector3 newPosition = _interectionObj.transform.position + _targetDelta;
        transform.position = newPosition;
        _previousTargetPosition = _interectionObj.transform.position;
    }

    private void Show()
    {
        _isShow = true;
        _spriteRenderer.enabled = true;
    }

    private void Hide()
    {
        _isShow = false;
        _spriteRenderer.enabled = false;
    }
}
