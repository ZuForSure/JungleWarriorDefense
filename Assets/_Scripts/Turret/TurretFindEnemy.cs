using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFindEnemy : FindEnemyBase
{
    [Header("Turret Find Enemy")]
    [SerializeField] protected float turretShootingRange = 17f;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.shootingRange = this.turretShootingRange;
    }
}
