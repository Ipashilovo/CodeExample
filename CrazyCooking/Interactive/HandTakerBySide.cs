using System.Collections;
using System.Collections.Generic;
using RootMotion.FinalIK;
using UnityEngine;

public abstract class HandTakerBySide : MonoBehaviour
{
    [SerializeField] private InteractionSpeed _interactionSpeed;
    protected HandPoser Poser { get; private set; }

    protected InteractionSpeed InteractionSpeed => _interactionSpeed;
    protected InterectionObj InterectObj { get; private set; }
    
    protected FullBodyBipedIK FullBodyIK { get; private set; }

    public void Init(HandPoser handPoser, FullBodyBipedIK fullBodyBipedIK)
    {
        Poser = handPoser;
        FullBodyIK = fullBodyBipedIK;
    }

    public void SetInteractionObj(InterectionObj obj)
    {
        InterectObj = obj;
    }
    public abstract void InteractHand();
    public abstract void RemoveHandTargetForTime();
}
