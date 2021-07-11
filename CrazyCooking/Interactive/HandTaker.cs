using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;
using  RootMotion.Demos;

[RequireComponent(typeof(Collider))]
public class HandTaker : MonoBehaviour
{
    [SerializeField] private InterectionHandColor _interectionHandColor;
    [SerializeField] private FullBodyBipedEffector _fullBodyBipedEffector;
    [SerializeField] private InteractionSystem _interactionSystem;
    [SerializeField] private HandPoser _handPoser;
    [SerializeField] private FullBodyBipedIK _fullBodyBipedIK;
    [SerializeField] private HandTakerBySide _handTakerBySide;

    private bool _haveObjectInHand;

    private InterectionObj _interectionObj;
    private Transform _objInHand = null;
    
    private void OnEnable()
    {
        _interectionHandColor.MouseUp += OnMouseUp;
    }

    private void OnDisable()
    {
        _interectionHandColor.MouseUp -= OnMouseUp;
    }
    
    private void Start()
    {
        _handTakerBySide.Init(_handPoser, _fullBodyBipedIK);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_haveObjectInHand) return;
        
        if (other.TryGetComponent(out InterectionObj interect))
        {
            if (_interectionObj == null && interect.IsUse == false)
            {
                _interectionObj = interect;
                if (_interectionHandColor.IsActiv)
                {
                    Take();
                }
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (_haveObjectInHand) return;
        
        if (other.TryGetComponent(out InterectionObj interect) && interect == _interectionObj)
        {
            _interectionObj = null;
        }
    }

    private void OnMouseUp()
    {
        if (_haveObjectInHand)
        {
            Remove();
        }
    }

    private void Take()
    {
        _interectionObj.PrepereToTake();
        _handTakerBySide.SetInteractionObj(_interectionObj);
        _handTakerBySide.RemoveHandTargetForTime();
        InteractionObject _interactionObject = _interectionObj.InteractionObject;
        _interactionSystem.StartInteraction(_fullBodyBipedEffector, _interactionObject, true);
        _handTakerBySide.InteractHand();
        _interectionObj.Take();
        _haveObjectInHand = true;
    }

    private void Remove()
    {
        _haveObjectInHand = false;
        _interactionSystem.StopInteraction(_fullBodyBipedEffector);
        _interectionObj.Remove();
        _interectionObj = null;
        _handPoser.poseRoot = null;
    }
}
