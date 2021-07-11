using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public abstract class UnitMovenent : MonoBehaviour
{
    [SerializeField] private float _startSpeed;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _reduceSpeedScale;
    private float _currentSpeed;


    private void Start()
    {
        _currentSpeed = _startSpeed;
        _animator.SetFloat("Speed", _currentSpeed);
    }

    private void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        transform.position += Vector3.forward * _currentSpeed * Time.deltaTime;

    }

    public void ReduceSpeed()
    {
        _currentSpeed = _startSpeed / _reduceSpeedScale;
        _animator.SetFloat("Speed", _currentSpeed);
    }

    public void ResetSpeed()
    {
        _currentSpeed = _startSpeed;
        _animator.SetFloat("Speed", _currentSpeed);
    }

    protected Animator GetAnimator()
    {
        return _animator;
    }
    protected IEnumerator Jump(float duration, float distanceX, float distanceY)
    {
        Vector3 startPosition = transform.position;
        float time = 0;
        float lerpValue;
        do
        {
            time += Time.deltaTime;
            lerpValue = CalculateCurve(time/duration);
            Vector3 endPosition = transform.position;
            endPosition.y = Mathf.Lerp(startPosition.y, startPosition.y + distanceY, lerpValue);
            endPosition.x = Mathf.Lerp(startPosition.x, startPosition.x + distanceX, time/duration);
            transform.position = endPosition;
            yield return null;
        } while (time <= duration);
    }
    
    private float CalculateCurve(float x)
    {
        float y = -4 * Mathf.Pow(x - 0.5f, 2) + 1;
        return y;
    }
}
