using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Seasoning : MonoBehaviour
{
    [SerializeField] private CookingItemType _itemType;
    [SerializeField] private InterectionObj _interectionObj;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField, Range(0f,1f)] private float _valueBurst;
    [SerializeField] private SeasoningParticle _seasoningParticle;
    [SerializeField, Range(1f,4f)] private float _maxValue;
    private float _value;
    private bool _inHand;
    private Vector3 _previousPosition;

    public CookingItemType ItemType => _itemType;

    private void OnEnable()
    {
        _interectionObj.Taking += OnTake;
        _interectionObj.Droping += OnPut;
    }

    private void OnDisable()
    {
        _interectionObj.Taking -= OnTake;
        _interectionObj.Droping -= OnPut;
    }

    private void Start()
    {
        _previousPosition = transform.position;
    }

    private void Update()
    {
        if (_inHand == false) return;

        if (_previousPosition == transform.position) return;

        _previousPosition = transform.position;
        _seasoningParticle.Play();
        
        if (IsSeasoningAbovePot())
        {
            StopCoroutine(BreackValue());
            
            CalculateValue();
        }

        StartCoroutine(BreackValue());
    }

    private void OnTake()
    {
        StartCoroutine(TakeDelay());
    }

    private void OnPut()
    {
        _inHand = false;
        StartCoroutine(BreackValue());
    }

    private bool IsSeasoningAbovePot()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        float distance = 5f;
        if (Physics.Raycast(ray, out RaycastHit hit, distance, _layerMask))
        {
            return true;
        }

        return false;
    }
    private void CalculateValue()
    {
        _value += _valueBurst;
        if (_value > _maxValue)
        {
            ActionCommand command = new ActionCommand(CookingAction.Seasoning, ItemType);
            EventsLooker.ActionDone(command);
        }
    }

    private IEnumerator BreackValue()
    {
        float delay = 3f;
        yield return new WaitForSeconds(delay);
        _value = 0;
    }

    private IEnumerator TakeDelay()
    {
        float time = 1f;
        yield return new WaitForSeconds(time);
        _inHand = true;
    }
}
