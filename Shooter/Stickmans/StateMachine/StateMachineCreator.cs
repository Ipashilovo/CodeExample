using System.Collections.Generic;
using ActivityLevel;
using DefaultNamespace.Stickman;
using Effects;
using LevelSystem;
using Stickmans.StateMachine.States;
using Stickmans.StateMachine.Transitions;
using UnityEngine;

namespace Stickmans.StateMachine
{
    [CreateAssetMenu(fileName = "StateMachineCreator", menuName = "ScriptableObjects/Stickman/StateMachineCreator", order = 1)]
    public class StateMachineCreator : ScriptableObject
    {

        public StateMachineBase CreateStateMachine(StickmanStats stickmanStats, UpdateHandler updateHandler,
            StickmanAnimator stickmanAnimator, PlayerFacade playerFacade, StickmanFacade stickmanFacade,
            StickmanMover stickmanMover, StickmanShootHandler shootHandler, ShootParticle shootParticle,
            FirstInputLisener firstInputLisener, Target target)
        {
            List<State> states = new List<State>();
            FirstWaitState firstWaitState = new FirstWaitState(target);
            states.Add(firstWaitState);
            FireState fireState = new FireState(updateHandler, stickmanAnimator, playerFacade, stickmanStats,
                stickmanFacade, shootHandler, shootParticle);
            states.Add(fireState);
            MoveState moveState = new MoveState(stickmanAnimator, stickmanMover);
            states.Add(moveState);
            TakeDamageState takeDamageState = new TakeDamageState();
            states.Add(takeDamageState);

            List<Transition> transitions = new List<Transition>();
            FirstWaitToMove firstWaitToMove = new FirstWaitToMove(moveState, firstInputLisener);
            transitions.Add(firstWaitToMove);
            TakeDamageToMove takeDamageToMove = new TakeDamageToMove(moveState, stickmanAnimator, stickmanMover);
            transitions.Add(takeDamageToMove);
            TakeDamageToShoot takeDamageToShoot = new TakeDamageToShoot(fireState, stickmanAnimator, stickmanMover);
            transitions.Add(takeDamageToShoot);
            ToTakeDamage toTakeDamage = new ToTakeDamage(stickmanAnimator, takeDamageState);
            transitions.Add(toTakeDamage);
            MoveToShoot moveToShoot = new MoveToShoot(fireState, stickmanMover);
            transitions.Add(moveToShoot);
            
            firstWaitState.SetTransitions(new Transition[]
            {
                firstWaitToMove,
                toTakeDamage
            });
            
            fireState.SetTransitions(new Transition[]
            {
                toTakeDamage
            });
            
            moveState.SetTransitions(new Transition[]
            {
                toTakeDamage,
                moveToShoot
            });
            
            takeDamageState.SetTransitions(new Transition[]
            {
                takeDamageToMove,
                takeDamageToShoot
            });

            StateMachineBase stateMachineBase = new StateMachineBase(transitions.ToArray(), states.ToArray(), firstWaitState);
            
            return stateMachineBase;
        }
    }
}