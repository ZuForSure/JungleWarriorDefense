using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : TurretAbstract
{
    [Header("Turret Shooting")]
    [SerializeField] protected bool canShoot = false;    
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float delay = 1f;

    private void FixedUpdate()
    {
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        if (!this.CheckCanShoot()) return;

        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delay) return;
        this.timer = 0f;

        Vector3 spawnPos = transform.position;
        Transform newBullet = BulletSpawner.Instance.SpawnPrefab(BulletSpawner.bullet, spawnPos, Quaternion.identity);
        if (newBullet == null) return;
        newBullet.gameObject.SetActive(true);
    }

    protected virtual bool CheckCanShoot()
    {
        this.canShoot = this.turretCtrl.TurretAimEne.IsEnemyComeIn;
        return this.canShoot;
    }
}
