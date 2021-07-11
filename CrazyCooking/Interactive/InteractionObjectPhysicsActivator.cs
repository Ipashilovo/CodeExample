using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObjectPhysicsActivator : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Collider _collider;
    
    public void Take()
    {
        _rigidbody.useGravity = false;
        _rigidbody.isKinematic = true;
        _collider.isTrigger = true;
    }

    public void Drop()
    {
        transform.parent = null;
        _collider.isTrigger = false;
        _rigidbody.isKinematic = false;
        _rigidbody.useGravity = true;
    }
}
