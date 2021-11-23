using Stickmans.StateMachine.Transitions;

namespace Stickmans.StateMachine.States
{
    public abstract class State
    {
        private Transition[] _transitions;

        public void SetTransitions(Transition[] transitions)
        {
            _transitions = transitions;
        }

        public void Enter()
        {
            SpecialEnter();
            foreach (var transition in _transitions)
            {
                transition.Enable(this);
            }
        }

        public abstract void Clear();

        public void Exit()
        {
            foreach (var transition in _transitions)
            {
                transition.Disable();
            }
            SpecialExit();
        }

        protected abstract void SpecialEnter();
        protected abstract void SpecialExit();
    }
}