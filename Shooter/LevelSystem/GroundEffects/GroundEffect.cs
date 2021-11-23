using System;
using System.Collections;
using System.Collections.Generic;
using ShootedObjects;
using UnityEngine;

namespace LevelSystem.GroundEffects
{
    public abstract class GroundEffect : MonoBehaviour
    {
        [SerializeField] protected ParticleSystem _particleSystem;
        public event Action<GroundEffect> Ended;
        protected List<IEffectProvider> _effectProviders = new List<IEffectProvider>();

        private void Awake()
        {
            if (_particleSystem != null)
            {
                _particleSystem = Instantiate(_particleSystem, transform);
                _particleSystem.transform.localPosition = Vector3.zero;
            }
        }

        public void Effect(Vector3 position)
        {
            transform.position = position;
            gameObject.SetActive(true);
            SpecialEffect(position);
        }

        protected abstract void SpecialEffect(Vector3 position);
        

        protected IEnumerator DisableAfterDelay(float time)
        {
            yield return new WaitForSeconds(time);
            End();
        }

        protected void End()
        {
            _effectProviders.Clear();
            gameObject.SetActive(false);
            Ended?.Invoke(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IEffectProvider effectProvider))
            {
                _effectProviders.Add(effectProvider);
                SpecialTriggerEnter(effectProvider);
            }
        }

        protected virtual void SpecialTriggerEnter(IEffectProvider effectProvider)
        {
            
        }

        public abstract GroundEffect Copy();

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IEffectProvider effectProvider))
            {
                _effectProviders.Remove(effectProvider);
            }
        }
    }
}