using System;
using Stickmans;
using UnityEngine;

namespace DefaultNamespace.Stickman.SticknamHead
{
    public class SticknamHeadShootLisener : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour _iDamageTaker;
        [SerializeField] private AudioSource _audioSource;
        private IDamageTakerObserver _damageTakerObserver;
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_iDamageTaker is IDamageTakerObserver damageTaker)
            {
                _damageTakerObserver = damageTaker;
            }
            else
            {
                _iDamageTaker = null;
            }
        }
#endif

        private void Awake()
        {
            _damageTakerObserver = (IDamageTakerObserver) _iDamageTaker;
            _damageTakerObserver.Taked += OnDamageTake;
        }

        private void OnDestroy()
        {
            _damageTakerObserver.Taked -= OnDamageTake;
        }
        
        private void OnDamageTake()
        {
            _audioSource.Play();
            HeadShootLisenerMediator.Notify();
        }
    }
}