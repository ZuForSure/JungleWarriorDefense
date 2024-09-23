using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamReceiver : DamageReceiver
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.ResetHP();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ReBorn();
    }

    protected virtual void ResetHP()
    {
        this.maxHp = 5f;
        this.ReBorn();
    }

    protected override void OnDead()
    {
        this.DespawnEnemy();
    }

    protected virtual void DespawnEnemy()
    {
        EnemySpawner.Instance.DespawnToPool(transform.parent);
    }
}
