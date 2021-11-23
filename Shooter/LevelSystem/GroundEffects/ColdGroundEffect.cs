using System.Collections;
using LevelSystem.GroundEffects;
using ShootedObjects;
using UnityEngine;

namespace ActivityLevel.ShootHandlers.GroundEffects
{
    public class ColdGroundEffect : GroundEffect
    {
        private float _freezeValue;

        protected override void SpecialEffect(Vector3 position)
        {
            StartCoroutine(Freeze());
        }

        private IEnumerator Freeze()
        {
            yield return new WaitForSeconds(0.05f);
            foreach (var effectProvider in _effectProviders)
            {
                if (effectProvider.TryGetPhysicsEffectProvider(out IPhysicsEffectProvider physicsEffectProvider))
                {
                    physicsEffectProvider.Freeze(_freezeValue);
                }
            }
            End();
        }

        public override GroundEffect Copy()
        {
            var newForceEffect = Instantiate(this);
            newForceEffect.SetValue(_freezeValue);
            return newForceEffect;
        }

        public void SetValue(float coldValue)
        {
            _freezeValue = coldValue;
        }
    }
}