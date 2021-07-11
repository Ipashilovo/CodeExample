using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladle : MonoBehaviour
{
    [SerializeField] private CookingAction _cookingAction;
    [SerializeField] private InterectionObj _interectionObj;
    [SerializeField] private float _maxValue = 3;
    [SerializeField] private float _valueBurst = 1f;
    private float _value;
    private bool _isInHand;

    private void OnEnable()
    {
        _interectionObj.Taking += OnTaking;
        _interectionObj.Droping += OnDroping;
    }

    private void OnDisable()
    {
        _interectionObj.Taking -= OnTaking;
        _interectionObj.Droping -= OnDroping;
    }

    private void OnTaking()
    {
        _isInHand = true;
    }

    private void OnDroping()
    {
        _isInHand = false;
        DropValue();
    }

    private void DropValue()
    {
        _value = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isInHand == false)
        {
            return;
        }
        
        if (other.TryGetComponent(out Pot pot))
        {
            _value += _valueBurst * Time.deltaTime;
            CheckValue();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_isInHand == false)
        {
            return;
        }
        
        if (other.TryGetComponent(out Pot pot))
        {
            _value += _valueBurst * Time.deltaTime;
            CheckValue();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_isInHand == false)
        {
            return;
        }
        
        if (other.TryGetComponent(out Pot pot))
        {
            _value += _valueBurst * Time.deltaTime;
            CheckValue();
        }
    }

    private void CheckValue()
    {
        if (_value >= _maxValue)
        {
            ActionCommand command = new ActionCommand(_cookingAction, CookingItemType.Ladle);
            EventsLooker.ActionDone?.Invoke(command);
            DropValue();
        }
    }
}
