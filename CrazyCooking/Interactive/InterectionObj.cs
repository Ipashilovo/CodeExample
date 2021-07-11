using System;
using System.Collections;
using System.Collections.Generic;
using RootMotion.FinalIK;
using UnityEngine;

public class InterectionObj : MonoBehaviour
{
    [SerializeField] private Transform _rightArmPosition;
    [SerializeField] private Transform _leftArmPosition;
    [SerializeField] private InteractionObject _interactionObject;
    [SerializeField] private InteractionObjectPhysicsActivator _interactionObjectPhysics;

    public bool IsUse { get; private set; }
    public Transform RightArmPosition => _rightArmPosition;
    public Transform LeftArmPosition => _leftArmPosition;
    public InteractionObject InteractionObject => _interactionObject;

    public Action Taking;
    public Action Droping;

    public void PrepereToTake()
    {
        _interactionObjectPhysics.Take();
    }
    
    public void Take()
    {
        IsUse = true;
        Taking?.Invoke();
    }

    public void Remove()
    {
        _interactionObjectPhysics.Drop();
        IsUse = false;
        Droping?.Invoke();
    }
}
