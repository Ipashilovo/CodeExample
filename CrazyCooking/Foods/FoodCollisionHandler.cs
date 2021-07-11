using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DestroingObject))]
public class FoodCollisionHandler : MonoBehaviour
{
    [SerializeField] private Food _food;

    public event Action<Collision> ColisionEnter;
    public event Action<Collision> CollisionExit; 
    public Food Food => _food;
    public event Action Slising;
    public event Action Destroing;

    private void OnCollisionEnter(Collision other)
    {
        ColisionEnter?.Invoke(other);
    }

    private void OnCollisionExit(Collision other)
    {
        CollisionExit?.Invoke(other);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Knife knife))
        {
            Slising?.Invoke();
        }
    }

    private void OnDestroy()
    {
        Destroing?.Invoke();
    }

    public void Init(Food food)
    {
        if (_food != null)
        {
            throw new AggregateException();
        }

        _food = food;
    }
}
