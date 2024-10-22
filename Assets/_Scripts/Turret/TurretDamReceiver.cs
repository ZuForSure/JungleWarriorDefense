using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDamReceiver : DamageReceiver
{
    [Header("Turret Dam Receiver")]
    [SerializeField] protected float turretHP = 1f;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.ResetTurretHP();
    }

    protected virtual void ResetTurretHP()
    {
        this.maxHp = this.turretHP;
        this.ReBorn();
    }

    protected override void OnDead()
    {
        this.DespawnTurret();
    }

    protected virtual void DespawnTurret()
    {
        TurretSpawner.Instance.DespawnToPool(transform.parent);
    }
}
