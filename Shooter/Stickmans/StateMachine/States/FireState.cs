using DefaultNamespace.Stickman;
using DG.Tweening;
using Effects;
using UnityEngine;
using PlayerFacade = LevelSystem.PlayerFacade;

namespace Stickmans.StateMachine.States
{
    public class FireState : State
    {
        private ShootParticle _particleSystem;
        private StickmanFacade _stickmanFacade;
        private PlayerFacade _playerFacade;
        private StickmanAnimator _stickmanAnimator;
        private StickmanStats _stats;
        private StickmanShootHandler _stickmanShootHandler;

        private UpdateHandler _updateHandler;
        
        private float _currentTime;

        public FireState(UpdateHandler updateHandler, StickmanAnimator stickmanAnimator, PlayerFacade playerFacade,
            StickmanStats stats, StickmanFacade stickmanFacade, StickmanShootHandler stickmanShootHandler, ShootParticle particleSystem)
        {
            _updateHandler = updateHandler;
            _stickmanAnimator = stickmanAnimator;
            _playerFacade = playerFacade;
            _stats = stats;
            _stickmanFacade = stickmanFacade;
            _stickmanShootHandler = stickmanShootHandler;
            _particleSystem = particleSystem;
        }


        public override void Clear()
        {
            _updateHandler.Updating -= OnUpdate;
        }

        protected override void SpecialEnter()
        {
            _updateHandler.Updating += OnUpdate;
            Shoot();
            _stickmanFacade.transform.DOLookAt(_playerFacade.GetPosition().position, 0.5f);
        }

        protected override void SpecialExit()
        {
            _updateHandler.Updating -= OnUpdate;
        }

        private void OnUpdate()
        {
            Vector3 position = _playerFacade.GetPosition().position;
            position.y = _stickmanFacade.transform.position.y;
            _stickmanFacade.transform.LookAt(position);
            Debug.DrawRay(_stickmanFacade.transform.position, _playerFacade.GetPosition().position, Color.red, 2f);
            _currentTime += Time.deltaTime;
            if (_currentTime >= _stats.RateOfFire)
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            _stickmanAnimator.PlayShoot();
            _currentTime = 0;
            _stickmanShootHandler.Shoot(_playerFacade);
            _particleSystem.Play();
        }
    }
}