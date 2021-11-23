using System;
using System.Collections;
using ActivityLevel;
using ShootedObjects;
using Stickmans;
using UnityEngine;

namespace DefaultNamespace.Stickman
{
    public class StickmanPhysicsEffect : MonoBehaviour, IPhysicsEffectProvider, IEffectProvider, IDamageTakerObserver
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _burningAudio;
        [SerializeField] private float _burningAudioScale = 1;
        [SerializeField] private AudioClip _freezeAudio;
        [SerializeField] private float _freezeAudioScale = 1;
        [SerializeField] private ParticleFolder _particleFolder;
        [SerializeField] private StickmanFacade _stickmanFacade;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private LimbType _limbType;
        [SerializeField] private SkinnedMeshRenderer _meshRenderer;
        [SerializeField] private Color _freezeColor;
        public bool IsFreezing { get; private set; }
        private Color _startColor;
        private StickmanAnimator _stickmanAnimator;
        private StickmanStats _stickmanStats;

        private float _currentColdValue;

        private MoveSpeed _moveSpeed;
        private StickmanLimb[] _stickmanLimbs;

        public event Action Taked;
        public event Action Freezed;

        private void Awake()
        {
            _startColor = _meshRenderer.material.color;
            _rigidbody.useGravity = false;
        }

        public void Init(MoveSpeed moveSpeed, StickmanLimb[] stickmanLimbs, StickmanAnimator stickmanAnimator, StickmanStats stickmanStats)
        {
            _stickmanStats = stickmanStats;
            _stickmanAnimator = stickmanAnimator;
            _stickmanLimbs = stickmanLimbs;
            _moveSpeed = moveSpeed;
        }


        public void SetMagnite(RaycastHit hit)
        {
            if (_stickmanFacade.IsDead && _stickmanFacade.JointCoint < _stickmanFacade.MaxJointCount && !_stickmanFacade.IsMovingToJoint)
            {
                JointCreator jointCreator = new JointCreator();
                jointCreator.CreateJoint(_rigidbody, hit, _moveSpeed.Speed);
                _stickmanFacade.JointCoint++;
                _stickmanFacade.SetJoinCooldown(jointCreator.Time);
            }
        }

        public void Burn()
        {
            _audioSource.PlayOneShot(_burningAudio, _burningAudioScale);
            _stickmanAnimator.PlayBurning();
            _particleFolder.PlayFireParticle();
        }

        public void Freeze(float freezeValue)
        {
            IsFreezing = true;
            _audioSource.PlayOneShot(_freezeAudio, _freezeAudioScale);
            _currentColdValue += freezeValue;
            float value = Mathf.InverseLerp(0, _stickmanStats.ColdMaxValue, _currentColdValue);
            Color color = Color.Lerp(_startColor, _freezeColor, value);
            _meshRenderer.material.color = color;
            _particleFolder.PlayColdParticle();
            if (_currentColdValue >= _stickmanStats.ColdMaxValue)
            {
                Freezed?.Invoke();
                _stickmanAnimator.PlayFreeze();
            }
        }

        public void SetMagnite(Transform point)
        {
            if (_stickmanFacade.IsDead && _stickmanFacade.JointCoint < _stickmanFacade.MaxJointCount && !_stickmanFacade.IsMovingToJoint)
            {
                JointCreator jointCreator = new JointCreator();
                jointCreator.CreateJoint(_rigidbody, point, _moveSpeed.Speed);
                _stickmanFacade.JointCoint++;
                _stickmanFacade.SetJoinCooldown(jointCreator.Time);
            }
        }

        public void DisableKinematic()
        {
            _rigidbody.isKinematic = false;
            _rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }

        public void EnableKinematic()
        {
            _rigidbody.isKinematic = true;
            _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        }

        public void AddForce(Vector3 force)
        {
            if (!_stickmanFacade.IsDead) return;
            
            foreach (var stickmanLimb in _stickmanLimbs)
            {
                stickmanLimb.AddForce(force, ForceMode.Impulse);
            }
            _rigidbody.AddForce(force, ForceMode.Impulse);
        }

        public bool TryGetMainEffectProvider(out IMainEffectProvider mainEffectProvider)
        {
            mainEffectProvider = _stickmanFacade;
            return true;
        }

        public void TakeDamage(float damage)
        {
            Taked?.Invoke();
            _stickmanFacade.TakeDamage(damage);
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public bool TryGetPhysicsEffectProvider(out IPhysicsEffectProvider physicsEffectProvider)
        {
            physicsEffectProvider =  this;
            return true;
        }
    }
}