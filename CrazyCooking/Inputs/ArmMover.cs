using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class ArmMover : LimbMover
{
    [SerializeField, Range(0.5f, 2)] private float _moveScale;
    private Vector3 _startRectTransform;
    private Vector3 _previousPosition;

    protected override void Start()
    {
        base.Start();
        _startRectTransform = RectTransform.position;
        SetDefultPreviousPosition();
    }
    
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        ReturnToStartPostition();
    }

    private void ReturnToStartPostition()
    {
        RectTransform.position = _startRectTransform;
        SetDefultPreviousPosition();
    }

    private void SetDefultPreviousPosition()
    {
        _previousPosition = Camera.main.ScreenToWorldPoint(new Vector3(RectTransform.position.x, RectTransform.position.y, Distance));
    }

    protected override void SetTargetPosition()
    {
        Vector3 newTargetPosition = Camera.main.ScreenToWorldPoint(new Vector3(RectTransform.position.x, RectTransform.position.y, Distance));
        Vector3 way = newTargetPosition - _previousPosition;
        way = way * _moveScale;
        TargetPoint.SetNewPosition(way);
        _previousPosition = newTargetPosition;
    }
}
