using ShootedObjects;
using UnityEngine;

namespace ActivityLevel.DestroibleItems
{
    public abstract class DestroybleItem : MonoBehaviour, IEffectProvider, IMainEffectProvider
    {
        [SerializeField] private float _life;
        [SerializeField] protected VoronoiPiece[] _voronoiPieces;
        [SerializeField] private Collider _collider;
        private bool _isDead;


        public bool TryGetMainEffectProvider(out IMainEffectProvider mainEffectProvider)
        {
            mainEffectProvider = this;
            return true;
        }

        void IEffectProvider.TakeDamage(float damage)
        {
            if (_isDead) return;
            _life -= damage;
            ExplosiveIfNeeded();
        }

        public void TakeDamageOverTime(float damage, float time) { }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public bool TryGetPhysicsEffectProvider(out IPhysicsEffectProvider physicsEffectProvider)
        {
            physicsEffectProvider = null;
            return false;
        }

        void IMainEffectProvider.TakeDamage(float damage)
        {
            if (_isDead) return;
            
            _life -= damage;
            ExplosiveIfNeeded();
        }

        private void ExplosiveIfNeeded()
        {
            if (_life <= 0)
            {
                _collider.enabled = false;
                Explosive();
            }
        }

        protected abstract void Explosive();
    }
}