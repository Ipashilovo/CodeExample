using DefaultNamespace.Stickman;
using Stickmans.StateMachine.States;

namespace Stickmans.StateMachine.Transitions
{
    public class TakeDamageToShoot : Transition
    {
        private StickmanAnimator _stickmanAnimator;
        private StickmanMover _stickmanMover;

        public TakeDamageToShoot(State nextState, StickmanAnimator stickmanAnimator, StickmanMover stickmanMover) :
            base(nextState)
        {
            _stickmanAnimator = stickmanAnimator;
            _stickmanMover = stickmanMover;
        }

        public override void Clear()
        {
            _stickmanAnimator.ShootedAnimationEnded -= ChangeState;
        }

        protected override void SpecialEnable(State previousState)
        {
            if (_stickmanMover.GetDistance() > 1)
            {
                Disable();
                return;
            }

            _stickmanAnimator.ShootedAnimationEnded += ChangeState;
        }

        public override void Disable()
        {
            _stickmanAnimator.ShootedAnimationEnded -= ChangeState;
        }
    }
}