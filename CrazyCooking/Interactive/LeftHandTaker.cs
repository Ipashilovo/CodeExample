using System.Collections;
using System.Collections.Generic;
using RootMotion.FinalIK;
using UnityEngine;

public class LeftHandTaker : HandTakerBySide
{

    public override void InteractHand()
    {
        Poser.poseRoot = InterectObj.LeftArmPosition;
    }
    
    public override void RemoveHandTargetForTime()
    {
        StartCoroutine(RemoveHandTarget());
    }
    
    private IEnumerator RemoveHandTarget()
    {
        float timeDelay = 1 / InteractionSpeed.Speed;
        Transform target = FullBodyIK.solver.leftHandEffector.target;
        FullBodyIK.solver.leftHandEffector.target = null;
        yield return new WaitForSeconds(timeDelay);
        FullBodyIK.solver.leftHandEffector.target = target;
    }
}
