using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDamReceiver : DamageReceiver
{
    [Header("Turret Dam Receiver")]
    [SerializeField] protected TurretController turretCtrl;
    [SerializeField] protected float turretHP = 1f;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.ResetTurretHP();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTurretCtrl();
    }

    protected virtual void ResetTurretHP()
    {
        this.turretHP = this.turretCtrl.TurretSO.turretMaxHP;
        this.maxHp = this.turretHP;
        this.ReBorn();
    }

    protected virtual void LoadTurretCtrl()
    {
        if(this.turretCtrl != null) return;
        this.turretCtrl = transform.GetComponentInParent<TurretController>();
        Debug.Log(transform.name + ": LoadTurretCtrl", gameObject);
    }

    protected override void OnDead()
    {
        this.DespawnTurret();
        this.SpawnTurretPoint();
    }

    protected virtual void DespawnTurret()
    {
        TurretSpawner.Instance.DespawnToPool(transform.parent);
    }

    protected virtual void SpawnTurretPoint()
    {
        Vector3 spawnPos = transform.position;
        Quaternion spawnRot = transform.rotation;
        Transform newPoint = PointTurretSpawner.Instance.SpawnPrefab(PointTurretSpawner.pointTurret, spawnPos, spawnRot);
        if (newPoint == null) return;
        newPoint.gameObject.SetActive(true);
    }
}
