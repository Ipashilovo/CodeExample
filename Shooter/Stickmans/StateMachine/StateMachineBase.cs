using Stickmans.StateMachine.States;
using Stickmans.StateMachine.Transitions;

namespace Stickmans.StateMachine
{
    public class StateMachineBase
    {
        private State[] _states;
        private Transition[] _transitions;
        private State _firstState;

        public StateMachineBase(Transition[] transitions, State[] states, State firstState)
        {
            _transitions = transitions;
            _states = states;
            _firstState = firstState;
        }

        public void Start()
        {
            _firstState.Enter();
        }

        public void Clear()
        {
            foreach (var transition in _transitions)
            {
                transition.Clear();
            }

            foreach (var state in _states)
            {
                state.Clear();
            }
        }
    }
}