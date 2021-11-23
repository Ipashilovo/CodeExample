using System;
using System.Collections;
using System.Linq;
using ActivityLevel;
using DG.Tweening;
using LevelSystem;
using ShootedObjects;
using Stickmans;
using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace.Stickman
{
    public class StickmanFacade : MonoBehaviour, IMainEffectProvider
    {
        [SerializeField] private StickmanMover _stickmanMover;
        [SerializeField] private StickmanInjection _stickmanInjection;
        [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
        [SerializeField] private Texture _deadTexture;
        private StickmanPhysicsEffect _stickmanPhysicsEffect;
        private StickmanStats _stats;
        private bool _isDead;

        private StickmanAnimator _stickmanAnimator;
        public event Action<StickmanFacade> Destroing;
        
        private int _jointCount;
        public bool IsMovingToJoint { get; private set; }

        public int JointCoint
        {
            get => _jointCount;
            set => _jointCount++;
        }

        public readonly int MaxJointCount = 1;

        public bool IsDead => _isDead;

        
        private void OnDestroy()
        {
            _stickmanAnimator?.Clear();
            if (_stickmanPhysicsEffect != null)
            {
                _stickmanPhysicsEffect.Freezed -= DieOnFreeze;
            }
        }
        
        public void Init(StickmanStats stickmanStats, StickmanPhysicsEffect stickmanPhysicsEffect)
        {
            _stats = stickmanStats;
            _stickmanPhysicsEffect = stickmanPhysicsEffect;
            stickmanPhysicsEffect.Freezed += DieOnFreeze;
        }

        public void SetOutSystems(PlayerFacade playerFacade, StickmanBulletPool stickmanBulletPool, FirstInputLisener firstInputLisener)
        {
            _stickmanInjection.Construct(playerFacade, stickmanBulletPool, firstInputLisener);
        }

        public void TakeDamage(float damage)
        {
            if (damage < 0)
            {
                throw new ArgumentException(name);
            }
            _stats.Health -= damage;
            if (_stats.Health <= 0)
            {
                Die();
            }
        }

        public void TakeDamageOverTime(float damage, float time)
        {
            StartCoroutine(TakingDamageOverTime(damage, time));
        }

        private void Die()
        {
            if (_isDead) return;
            
            if (_stickmanPhysicsEffect.IsFreezing)
            {
                DieOnFreeze();
            }
            else
            {
                _skinnedMeshRenderer.material.mainTexture = _deadTexture;
                Destroing?.Invoke(this);
                _isDead = true;
            }
        }

        private void DieOnFreeze()
        {
            if (_isDead) return;
            _isDead = true;
            Destroing?.Invoke(this);
            new StickmanVoronoiChanger().Change(this);
        }

        public void SetJoinCooldown(float time)
        {
            StartCoroutine(JointCooldown(time));
        }

        private IEnumerator JointCooldown(float time)
        {
            IsMovingToJoint = true;
            yield return new WaitForSeconds(time);
            IsMovingToJoint = false;
        }

        private IEnumerator TakingDamageOverTime(float damage, float time)
        {
            float currentTime = 0;
            float damagePerTick = damage / time;
            while (currentTime <= 1)
            {
                currentTime += Time.deltaTime / currentTime;
                TakeDamage(damagePerTick);
                yield return null;
            }
        }

        public void SetMovePoint(Transform endPosition)
        { 
            _stickmanMover.SetPoint(endPosition);
        }
    }
}