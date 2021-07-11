using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class Knife : MonoBehaviour
{
    [SerializeField] private InterectionObj _interectionObj;
    [SerializeField] private SphereCollider _sphereCollider;

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

    private void OnTake()
    {
        _sphereCollider.enabled = true;
    }

    private void OnPut()
    {
        _sphereCollider.enabled = false;
    }
}
