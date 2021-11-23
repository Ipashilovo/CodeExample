using System.Collections;
using UnityEngine;

namespace LevelSystem.GroundEffects
{
    public class DamageGroundEffect : GroundEffect
    {
        public float _damage;
        protected override void SpecialEffect(Vector3 position)
        {
            _particleSystem.Play();
            StartCoroutine(DoDamage());
        }

        public override GroundEffect Copy()
        {
            var damageGroundEffect = Instantiate(this); 
            damageGroundEffect.Init(_damage);
            return damageGroundEffect;
        }

        public void Init(float damage)
        {
            _damage = damage;
        }

        private IEnumerator DoDamage()
        {
            yield return new WaitForSeconds(0.05f);
            foreach (var effectProvider in _effectProviders)
            {
                effectProvider.TakeDamage(_damage);
            }

            yield return new WaitForSeconds(_particleSystem.main.duration);
            
            End();
        }
    }
}