using System;
using ActivityLevel;
using DefaultNamespace.Stickman;
using Effects;
using LevelSystem;
using Stickmans.StateMachine;
using Stickmans.Weapons;
using UnityEngine;
using Zenject;

namespace Stickmans
{
    public class StickmanInjection : MonoBehaviour
    {
        [SerializeField] private ShootParticle _shootParticle;
        [SerializeField] private StateMachineCreator _stateMachineCreator;
        [SerializeField] private Transform _shootPosition;
        [SerializeField] private StickmanFacade _stickmanFacade;
        [SerializeField] private StickmanMover _stickmanMover;
        [SerializeField] private Animator _animator;
        [SerializeField] private StickmanStatsSO _stickmanStatsSo;
        [SerializeField] private StickmanLimb[] _stickmanLimbs;
        [SerializeField] private StickmanPhysicsEffect _stickmanPhysicsEffect;
        [SerializeField] private MoveSpeed _flySpeed;
        [SerializeField] private UpdateHandler _updateHandler;
        [SerializeField] private StickmanWeapon _stickmanWeapon;
        [SerializeField] private float _shootOffcet;
        [SerializeField] private Target _target;
        private StickmanBulletPool _stickmanBulletPool;
        private StickmanAnimator _stickmanAnimator;
        private StickmanStats _stickmanStats;
        private PlayerFacade _playerFacade;
        private StateMachineBase _stateMachineBase;
        private StickmanDieLisener _stickmanDieLisener;
        private FirstInputLisener _firstInputLisener;


        public void Construct(PlayerFacade playerFacade, StickmanBulletPool stickmanBulletPool, FirstInputLisener firstInputLisener)
        {
            _firstInputLisener = firstInputLisener;
            _stickmanBulletPool = stickmanBulletPool;
            _playerFacade = playerFacade;
        }

        private void Start()
        {
            _stickmanStats = _stickmanStatsSo.GetStats();
            _stickmanAnimator = new StickmanAnimator(_animator, _stickmanStats);
            InitLimbs();

            DisablePhysics();
            CreateStateMachine();
            CreateStickmanDieLisener();
            _stickmanFacade.Init(_stickmanStats, _stickmanPhysicsEffect);
            _stateMachineBase.Start();
        }

        private void InitLimbs()
        {
            _stickmanPhysicsEffect.Init(_flySpeed, _stickmanLimbs, _stickmanAnimator, _stickmanStats);
            foreach (var stickmanLimb in _stickmanLimbs)
            {
                stickmanLimb.Init(_flySpeed, _stickmanPhysicsEffect, _stickmanFacade, _stickmanAnimator);
            }
        }

        private void OnDestroy()
        {
            _stickmanDieLisener.Clear();
            _stickmanAnimator.Clear();
            _stateMachineBase.Clear();
            _stateMachineBase = null;
        }

        private void CreateStickmanDieLisener()
        {
            _stickmanDieLisener = new StickmanDieLisener(_stickmanPhysicsEffect, _stickmanLimbs, _stickmanFacade,
                _stickmanAnimator, _stateMachineBase, _stickmanMover, _stickmanWeapon, _target);
        }

        private void CreateStateMachine()
        {
            StickmanShootHandler stickmanShootHandler = new StickmanShootHandler(_stickmanBulletPool.GetBulletPool(), _shootPosition, _stickmanStats.Damage, _shootOffcet);
            
            _stateMachineBase = _stateMachineCreator.CreateStateMachine(_stickmanStats, _updateHandler, _stickmanAnimator, _playerFacade,
                _stickmanFacade, _stickmanMover, stickmanShootHandler, _shootParticle, _firstInputLisener, _target);
        }

        private void DisablePhysics()
        {
            for (int i = 0; i < _stickmanLimbs.Length; i++)
            {
                _stickmanLimbs[i].Init(_flySpeed, _stickmanPhysicsEffect, _stickmanFacade, _stickmanAnimator);
                _stickmanLimbs[i].EnableKinematic();
            }

            _stickmanPhysicsEffect.EnableKinematic();
        }
    }
}