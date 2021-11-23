using DefaultNamespace.Stickman;
using Stickmans.StateMachine;
using Stickmans.Weapons;

namespace Stickmans
{
    public class StickmanDieLisener
    {
        private StickmanFacade _stickmanFacade;
        private StickmanLimb[] _stickmanLimbs;
        private StickmanPhysicsEffect _stickmanPhysicsEffect;
        private StickmanAnimator _stickmanAnimator;
        private StickmanMover _stickmanMover;
        private StateMachineBase _stateMachineBase;
        private StickmanWeapon _stickmanWeapon;
        private Target _target;

        public StickmanDieLisener(StickmanPhysicsEffect stickmanPhysicsEffect, StickmanLimb[] stickmanLimbs,
            StickmanFacade stickmanFacade, StickmanAnimator stickmanAnimator,
            StateMachineBase stateMachineBase, StickmanMover stickmanMover, StickmanWeapon stickmanWeapon, Target target)
        {
            _stickmanPhysicsEffect = stickmanPhysicsEffect;
            _stickmanLimbs = stickmanLimbs;
            _stickmanFacade = stickmanFacade;
            _stickmanAnimator = stickmanAnimator;
            _stateMachineBase = stateMachineBase;
            _stickmanMover = stickmanMover;
            _stickmanWeapon = stickmanWeapon;
            _target = target;
            _stickmanFacade.Destroing += OnStickmanDestroy;
        }

        private void OnStickmanDestroy(StickmanFacade obj)
        {
            _target.enabled = false;
            _stickmanWeapon.Drop();
            _stateMachineBase.Clear();
            _stateMachineBase = null;
            _stickmanFacade.Destroing -= OnStickmanDestroy;
            _stickmanAnimator.Destroy();
            _stickmanMover.DestroyThis();
            _stickmanPhysicsEffect.DisableKinematic();
            for (int i = 0; i < _stickmanLimbs.Length; i++)
            {
                _stickmanLimbs[i].DisableKinematic();
            }
        }

        public void Clear()
        {
            _stickmanFacade.Destroing -= OnStickmanDestroy;
        }
    }
}