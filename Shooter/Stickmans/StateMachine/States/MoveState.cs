using DefaultNamespace.Stickman;
using Stickmans.StateMachine.Transitions;

namespace Stickmans.StateMachine.States
{
    public class MoveState : State
    {
        private StickmanAnimator _stickmanAnimator;
        private StickmanMover _stickmanMover;

        public MoveState(StickmanAnimator stickmanAnimator, StickmanMover stickmanMover)
        {
            _stickmanAnimator = stickmanAnimator;
            _stickmanMover = stickmanMover;
        }

        public override void Clear()
        {
            
        }

        protected override void SpecialEnter()
        {
            _stickmanAnimator.StartMoving();
            _stickmanMover.StartMoving();
        }

        protected override void SpecialExit()
        {
            _stickmanAnimator.StopMoving();
            _stickmanMover.StopMoving();
        }
    }
}