using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmTargetPoint : TargetPoint
{
    public override void SetNewPosition(Vector3 position)
    {
        transform.position += position;
    }
}
