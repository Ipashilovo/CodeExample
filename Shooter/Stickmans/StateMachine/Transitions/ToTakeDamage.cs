using DefaultNamespace.Stickman;
using Stickmans.StateMachine.States;

namespace Stickmans.StateMachine.Transitions
{
    public class ToTakeDamage : Transition
    {
        private StickmanAnimator _stickmanAnimator;

        public ToTakeDamage(StickmanAnimator stickmanAnimator, State nextState) : base(nextState)
        {
            _stickmanAnimator = stickmanAnimator;
        }

        public override void Clear()
        {
            _stickmanAnimator.ShootedAnimationStarted -= ChangeState;
        }

        protected override void SpecialEnable(State previousState)
        {
            _stickmanAnimator.ShootedAnimationStarted += ChangeState;
        }

        public override void Disable()
        {
            _stickmanAnimator.ShootedAnimationStarted -= ChangeState;
        }
    }
}