using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstInputLooker : MonoBehaviour
{
    [SerializeField] private ActivatorGameplayElements _activatorGameplayElements;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _activatorGameplayElements.Activate();
            gameObject.SetActive(false);
        }
    }
}
