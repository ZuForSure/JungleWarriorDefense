using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSlowEnemy : BulletAbstract
{
    [Header("Bullet Slow Enemy")]
    [SerializeField] protected float slowTime = 1f;
    [SerializeField] protected float slowedSpeed;

    protected override void Update()
    {
        base.Update();
        this.SlowingEnemy();
    }

    protected virtual void SlowingEnemy()
    {
        this.GetEnemySpeed();
    }

    protected virtual void GetEnemySpeed()
    {
        
    }
}
