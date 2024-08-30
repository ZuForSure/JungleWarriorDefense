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

    protected virtual void ResetHP()
    {
        this.maxHp = 5f;
        this.ReBorn();
    }

    protected override void OnDead()
    {
        Destroy(transform.parent.gameObject);
    }
}
