using System.Collections;
using LevelSystem.GroundEffects;
using ShootedObjects;
using UnityEngine;

namespace DefaultNamespace.LevelSystem.Barrel
{
    public class Barrel : MonoBehaviour, IMainEffectProvider, IEffectProvider
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private float _flySpeed;
        [SerializeField] private Rigidbody _rigidbody;
        private GroundEffectPool _forcePool;
        private GroundEffectPool _damagePool;

        public void Init(GroundEffectPool forcePool, GroundEffectPool damagePool)
        {
            _forcePool = forcePool;
            _damagePool = damagePool;
        }

        public bool TryGetMainEffectProvider(out IMainEffectProvider mainEffectProvider)
        {
            mainEffectProvider = this;
            return true;
        }

        public void TakeDamage(float damage)
        {
            Explosive();
        }

        public void TakeDamageOverTime(float damage, float time)
        {
            Explosive();
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public bool TryGetPhysicsEffectProvider(out IPhysicsEffectProvider physicsEffectProvider)
        {
            physicsEffectProvider = null;
            return false;
        }

        private void Explosive()
        {
            _audioSource.Play();
            _damagePool.GetGroundEffect().Effect(transform.position);
            _forcePool.GetGroundEffect().Effect(transform.position);
            _rigidbody.AddForce(Vector3.up * _flySpeed, ForceMode.Impulse);
            StartCoroutine(DestroyAfterFly());
        }
    
        private IEnumerator DestroyAfterFly()
        {
            float time = 2;
            yield return new WaitForSeconds(time);
            Destroy(gameObject);
        }
    }
}