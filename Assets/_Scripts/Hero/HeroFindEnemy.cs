using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFindEnemy : FindEnemyBase
{
    [Header("Hero Find Enemy")]
    [SerializeField] protected float heroShootRange = 10f;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.shootingRange = this.heroShootRange;
    }
}
