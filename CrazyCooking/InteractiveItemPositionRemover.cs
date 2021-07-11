using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveItemPositionRemover : MonoBehaviour
{
    [SerializeField] private InterectionObj _interectionObj;
    private Vector3 _position;
    private Quaternion _rotation;
    private Coroutine _droping;

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

    private void Start()
    {
        _rotation = transform.rotation;
        _position = transform.position;
    }

    public void ReturnToStartPosition()
    {
        transform.position = _position;
        transform.rotation = _rotation;
    }

    private void OnDroping()
    {
        _droping = StartCoroutine(ReturnToStartPositionAfterDelay());
    }

    private void OnTaking()
    {
        if (_droping != null)
        {
            StopCoroutine(_droping);
            _droping = null;
        }
    }

    

    private IEnumerator ReturnToStartPositionAfterDelay()
    {
        float delay = 7f;
        yield return new WaitForSeconds(delay);
        ReturnToStartPosition();
    }
}
