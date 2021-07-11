using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class LimbMover : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private TargetPoint _targetPoint;
    private RectTransform _rectTransform;
    
    private bool _isDrag;
    private float _distance;

    protected TargetPoint TargetPoint => _targetPoint;
    protected RectTransform RectTransform => _rectTransform;
    protected float Distance => _distance;
    
    protected virtual void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _distance =  Vector3.Distance(_targetPoint.transform.position, Camera.main.transform.position);
    }
    
    private void Update()
    {
        if(_isDrag == false) return;
        
        _rectTransform.position = Input.mousePosition;
        
        SetTargetPosition();
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        _isDrag = true;
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        _isDrag = false;
    }

    protected abstract void SetTargetPosition();
}
