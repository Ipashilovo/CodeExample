using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    public event Action<Collider> ColliderFinded;
    public event Action<Collider> ColliderLoosed;

    private void OnTriggerEnter(Collider other)
    {
        ColliderFinded?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        ColliderLoosed?.Invoke(other);
    }
}
