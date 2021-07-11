using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DorOpener : MonoBehaviour
{
    private const string _animatorTriggerName = "OpenDor";
    [SerializeField] private Animator _animator;
    [SerializeField] private StorageBox _storageBox;

    private void OnEnable()
    {
        _storageBox.Opening += OpenDor;
    }

    private void OnDisable()
    {
        _storageBox.Opening -= OpenDor;
    }

    private void OpenDor()
    {
        _animator.SetTrigger(_animatorTriggerName);
    }
}
