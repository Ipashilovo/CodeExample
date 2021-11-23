using ActivityLevel;
using Stickmans.StateMachine.States;

namespace Stickmans.StateMachine.Transitions
{
    public class FirstWaitToMove : Transition
    {
        private FirstInputLisener _firstInputLisener;
        public FirstWaitToMove(State nextState, FirstInputLisener firstInputLisener) : base(nextState)
        {
            _firstInputLisener = firstInputLisener;
        }

        public override void Clear()
        {
            _firstInputLisener.Clicked -= ChangeState;
        }

        protected override void SpecialEnable(State previousState)
        {
            _firstInputLisener.Clicked += ChangeState;
        }

        public override void Disable()
        {
            _firstInputLisener.Clicked -= ChangeState;
        }
    }
}