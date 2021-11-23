using System;
using DG.Tweening;
using ShootedObjects;
using Stickmans;
using UnityEngine;

namespace DefaultNamespace.Stickman
{
    public class StickmanLimb : MonoBehaviour, IEffectProvider, IPhysicsEffectProvider, IDamageTakerObserver
    {
        [SerializeField] private LimbType _limbType;
        [SerializeField] private float _damageMultiplicate = 1;
        private StickmanFacade _stickmanFacade;
        private MoveSpeed _moveSpeed;
        private Rigidbody _rigidbody;
        private StickmanPhysicsEffect _stickmanPhysicsEffect;
        private StickmanAnimator _stickmanAnimator;
        
        public event Action Taked;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Init(MoveSpeed moveSpeed, StickmanPhysicsEffect stickmanPhysicsEffect, StickmanFacade stickmanFacade, StickmanAnimator stickmanAnimator)
        {
            _stickmanFacade = stickmanFacade;
            _stickmanPhysicsEffect = stickmanPhysicsEffect;
            _moveSpeed = moveSpeed;
            _stickmanAnimator = stickmanAnimator;
        }

        public bool TryGetMainEffectProvider(out IMainEffectProvider mainEffectProvider)
        {
            mainEffectProvider = _stickmanFacade;
            return true;
        }

        public void TakeDamage(float damage)
        {
            if (_stickmanFacade.IsDead) return;
            
            Taked?.Invoke();
            _stickmanAnimator.PlayDamageAnimation(_limbType);
            _stickmanFacade.TakeDamage(damage * _damageMultiplicate);
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public bool TryGetPhysicsEffectProvider(out IPhysicsEffectProvider physicsEffectProvider)
        {
            physicsEffectProvider = this;
            return true;
        }

        public void Burn()
        {
            _stickmanPhysicsEffect.Burn();
        }

        public void SetMagnite(Transform point)
        {
            if (ChekMagniteOpportunity())
            {
                JointCreator jointCreator = new JointCreator();
                jointCreator.CreateJoint(_rigidbody, point, _moveSpeed.Speed);
                AddNewJoint(jointCreator);
            }
        }

        public void SetMagnite(RaycastHit hit)
        {
            if (ChekMagniteOpportunity())
            {
                JointCreator jointCreator = new JointCreator();
                jointCreator.CreateJoint(_rigidbody, hit, _moveSpeed.Speed);
                AddNewJoint(jointCreator);
            }
        }

        private bool ChekMagniteOpportunity()
        {
            return _stickmanFacade.IsDead && _stickmanFacade.JointCoint < _stickmanFacade.MaxJointCount &&
                   !_stickmanFacade.IsMovingToJoint;
        }

        private void AddNewJoint(JointCreator jointCreator)
        {
            _stickmanFacade.JointCoint++;
            _stickmanFacade.SetJoinCooldown(jointCreator.Time);
        }

        public void AddForce(Vector3 force)
        {
            _rigidbody.AddForce(force, ForceMode.Impulse);
        }

        public void Freeze(float freezeValue)
        {
            _stickmanPhysicsEffect.Freeze(freezeValue);
        }

        public void AddForce(Vector3 force, ForceMode forceMode)
        {
            _rigidbody.AddForce(force, forceMode);
        }

        public void EnableKinematic()
        {
            _rigidbody.isKinematic = true;
            _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        }

        public void DisableKinematic()
        {
            _rigidbody.isKinematic = false;
            _rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }
    }
}