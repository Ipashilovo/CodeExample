using System.Collections;
using UnityEngine;
using DG.Tweening;

public class EnemyMovement : UnitMovenent
{
    public void SwitchRoad(Road road, int jumpCount = 1)
    {
        Vector3 roadPosition = road.transform.position;

        float step = (roadPosition.x - transform.position.x) / jumpCount;

        StartCoroutine(JumpToPosition(step, jumpCount));
    }

    private IEnumerator JumpToPosition(float step, int count)
    {
        for (int i = 0; i < count; i++)
        {
            GetAnimator().Play("Jump");
            float duration = 1;
            StartCoroutine(Jump(duration, step, 1));
            yield return new WaitForSeconds(duration);
        }
    }
}
