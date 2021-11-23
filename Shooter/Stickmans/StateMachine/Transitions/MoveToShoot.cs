using DefaultNamespace.Stickman;
using Stickmans.StateMachine.States;

namespace Stickmans.StateMachine.Transitions
{
    public class MoveToShoot : Transition
    {
        private StickmanMover _stickmanMover;
        public MoveToShoot(State nextState, StickmanMover stickmanMover) : base(nextState)
        {
            _stickmanMover = stickmanMover;
        }

        public override void Clear()
        {
            _stickmanMover.ReachedPosition -= ChangeState;
        }

        protected override void SpecialEnable(State previousState)
        {
            _stickmanMover.ReachedPosition += ChangeState;
        }

        public override void Disable()
        {
            _stickmanMover.ReachedPosition -= ChangeState;
        }
    }
}