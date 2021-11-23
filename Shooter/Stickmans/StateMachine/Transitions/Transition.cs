using Stickmans.StateMachine.States;

namespace Stickmans.StateMachine.Transitions
{
    public abstract class Transition
    {
        private State _nextState;
        protected State _previousState;

        protected Transition(State nextState)
        {
            _nextState = nextState;
        }

        public void Enable(State previousState)
        {
            _previousState = previousState;
            SpecialEnable(previousState);
        }

        public abstract void Clear();

        protected abstract void SpecialEnable(State previousState);
        public abstract void Disable();

        protected void ChangeState()
        {
            _previousState.Exit();
            _nextState.Enter();
        }
    }
}