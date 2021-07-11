using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    [SerializeField] private EnemyMovement _enemyMovement;

    public override void SetMaterial(StickmanMaterial material)
    {
        base.SetMaterial(material);
        ReduceSpeed();
    }

    public void ResetSpeed()
    {
        _enemyMovement.ResetSpeed();
    }

    public void ReduceSpeed()
    {
        _enemyMovement.ReduceSpeed();
    }
}
