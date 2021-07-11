using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegTargetPoint : TargetPoint
{
    [SerializeField] private float _distanceY;
    
    public override void SetNewPosition(Vector3 position)
    {
        position += new Vector3(0, _distanceY, 0);
        position.z = transform.position.z;
        transform.position = position;
    }
}
