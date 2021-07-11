using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMover : LimbMover
{
    protected override void SetTargetPosition()
    {
        Vector3 newTargetPosition = Camera.main.ScreenToWorldPoint(new Vector3(RectTransform.position.x, RectTransform.position.y, Distance));
        TargetPoint.SetNewPosition(newTargetPosition);
    }
}
