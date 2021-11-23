using System;
using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class UiBounce : MonoBehaviour
    {
        [SerializeField] private Vector3 _punch;
        [SerializeField] private float _duration;
        [SerializeField] private int _vibrato;
        [SerializeField] private float _elasticity = 1;
        
        private void Start()
        {
            transform.DOPunchScale(_punch, _duration, _vibrato, _elasticity).OnComplete(StartBounce);
        }

        private void StartBounce()
        {
            transform.DOPunchScale(_punch, _duration, _vibrato, _elasticity).OnComplete(StartBounce);
        }
    }
}