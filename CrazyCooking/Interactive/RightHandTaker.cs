using System.Collections;
using System.Collections.Generic;
using RootMotion.FinalIK;
using UnityEngine;

public class RightHandTaker : HandTakerBySide
{
    public override void InteractHand()
    {
        Poser.poseRoot = InterectObj.RightArmPosition;
    }

    public override void RemoveHandTargetForTime()
    {
        StartCoroutine(RemoveHandTarget());
    }

    private IEnumerator RemoveHandTarget()
    {
        float timeDelay = 1 / InteractionSpeed.Speed;
        Transform target = FullBodyIK.solver.rightHandEffector.target;
        FullBodyIK.solver.rightHandEffector.target = null;
        yield return new WaitForSeconds(timeDelay);
        FullBodyIK.solver.rightHandEffector.target = target;
    }
}
