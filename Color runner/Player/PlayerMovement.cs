using System.Collections;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : UnitMovenent
{
    public void SwitchRoad(Road road)
    {
        GetAnimator().Play("Jump");

        Vector3 endPosition = transform.position;
        float distanceX = road.transform.position.x - transform.position.x;
        StartCoroutine(Jump(1, distanceX, 1));
    }
}
