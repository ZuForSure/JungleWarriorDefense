using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class TurretShooting : TurretAbstract
{
    [Header("Turret Shooting")]
    [SerializeField] protected Transform bulletSpawnPoint;
    [SerializeField] protected bool canShoot = false;
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float delay = 1f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoint();
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Shooting();
    }

    protected virtual void LoadSpawnPoint()
    {
        if (this.bulletSpawnPoint != null) return;
        this.bulletSpawnPoint = transform.Find("Bullet Spawn Point");
        Debug.Log(transform.name + ": LoadSpawnPoint", gameObject);
    }

    protected virtual void Shooting()
    {
        if (!this.CheckCanShoot()) return;

        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delay) return;
        this.timer = 0f;

        Vector3 spawnPos = this.bulletSpawnPoint.transform.position;
        Transform newBullet = BulletSpawner.Instance.SpawnPrefab(BulletSpawner.turretBullet, spawnPos, Quaternion.identity);
        if (newBullet == null) return;
        newBullet.gameObject.SetActive(true);
    }

    protected virtual bool CheckCanShoot()
    {
        this.canShoot = this.turretCtrl.TurretFindEne.IsFindEnemy;
        return this.canShoot;
    }
}
