using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankerFindEnemy : HeroFindEnemy
{
    [Header("Tanker Find Enemy")]
    [SerializeField] protected float tankerRange = 1.6f;

    protected override void ResetValue()
    {
        this.shootingRange = this.tankerRange;
    }
}
