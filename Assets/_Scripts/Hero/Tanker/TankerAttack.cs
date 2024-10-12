using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankerAttack : HeroAttack
{
    [Header("Tanker Attack")]
    [SerializeField] protected Transform attackPoint;
    [SerializeField] protected float tankerDelay = 1f;
    [SerializeField] protected float tankerAutoDelay = 1.5f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAttackPoint();
    }

    protected override void ResetValue()
    {
        this.autoAttackDelay = this.tankerAutoDelay;
        this.attackDelay = this.tankerDelay;
    }

    protected virtual void LoadAttackPoint()
    {
        if (this.attackPoint != null) return;
        this.attackPoint = transform.Find("Attack Point");
        Debug.Log(transform.name + ": LoadAttackPoint", gameObject);
    }

    protected override void SpawnBullet()
    {
        this.isAttacking = true;

        Vector3 spawnPos = this.attackPoint.position;
        Quaternion spawnRot = transform.rotation;
        Transform bullet = FXSpawner.Instance.SpawnPrefab(FXSpawner.meleeAttack, spawnPos, spawnRot);
        if (bullet == null) return;
        bullet.gameObject.SetActive(true);
    }
}
