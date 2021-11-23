using System.Collections;
using ActivityLevel.ShootHandlers.GroundEffects;
using ShootedObjects;
using UnityEngine;

namespace LevelSystem.GroundEffects
{
    public class ForceGroundEffect : GroundEffect
    {
        private float _power;
        
        protected override void SpecialEffect(Vector3 position)
        {
            StartCoroutine(Push());
        }

        private IEnumerator Push()
        {
            yield return new WaitForSeconds(0.05f);
            foreach (var effectProvider in _effectProviders)
            {
                if (effectProvider.TryGetPhysicsEffectProvider(out IPhysicsEffectProvider physicsEffectProvider))
                {
                    Vector3 direction = effectProvider.GetPosition() - transform.position;
                    direction = direction.normalized * _power;
                    physicsEffectProvider.AddForce(direction);
                }
            }
            End();
        }

        public void Init(float power)
        {
            _power = power;
        }

        public override GroundEffect Copy()
        {
            var newForceEffect = Instantiate(this);
            newForceEffect.Init(_power);
            return newForceEffect;
        }
    }
}