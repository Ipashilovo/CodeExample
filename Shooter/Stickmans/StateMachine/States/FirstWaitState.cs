namespace Stickmans.StateMachine.States
{
    public class FirstWaitState : State
    {
        private Target _target;

        public FirstWaitState(Target target)
        {
            _target = target;
        }

        public override void Clear()
        {
        }

        protected override void SpecialEnter()
        {
        }

        protected override void SpecialExit()
        {
            _target.enabled = true;
        }
    }
}