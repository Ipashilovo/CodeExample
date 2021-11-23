using DefaultNamespace.Stickman;
using UnityEngine;

namespace Stickmans.StateMachine
{
    public class StickmanStateMachine : MonoBehaviour
    {
        [SerializeField] private StickmanFacade _stickmanFacade;
        [SerializeField] private StateMachineCreator _stateMachineCreator;
        [SerializeField] private StickmanAnimator _stickmanAnimator;
        [SerializeField] private StickmanMover _stickmanMover;
        private StateMachineBase _stateMachineBase;
    }
}