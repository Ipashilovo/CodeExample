using System;
using LevelSystem.GroundEffects;
using ShootedObjects;
using UnityEngine;

namespace ActivityLevel.ShootHandlers.GroundEffects
{
    public class FireGroundEffect : GroundEffect
    {
        [SerializeField] private float _time;
        private float _damageInSec = -1;

        public float DamageInSec => _damageInSec;

        public void Init(float damage)
        {
            if (_damageInSec != -1) return;
            
            _damageInSec = damage;
        }

        private void Update()
        {
            float damage = _damageInSec * Time.deltaTime;
            foreach (var effectProvider in _effectProviders)
            {
                if (effectProvider.TryGetMainEffectProvider(out IMainEffectProvider mainEffectProvider))
                {
                    mainEffectProvider.TakeDamage(damage);
                }
            }
        }

        protected override void SpecialEffect(Vector3 position)
        {
            _particleSystem.Play();
            StartCoroutine(DisableAfterDelay(_time));
        }

        protected override void SpecialTriggerEnter(IEffectProvider effectProvider)
        {
            if (effectProvider.TryGetPhysicsEffectProvider(out IPhysicsEffectProvider physicsEffectProvider))
            {
                physicsEffectProvider.Burn();
            }
        }

        public override GroundEffect Copy()
        {
            var newEffect = Instantiate(this);
            newEffect.Init(_damageInSec);
            return newEffect;
        }
    }
}