using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamSender : DamageSender
{
    [Header("Bullet Dam Sender")]
    [SerializeField] protected BulletController bulletCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletController();
    }

    protected virtual void LoadBulletController()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.GetComponentInParent<BulletController>();
        Debug.Log(transform.name + ": LoadBulletController", gameObject);
    }

    protected override void SendDamage(DamageReceiver damageReceiver)
    {
        base.SendDamage(damageReceiver);
        this.DespawnBullet();
        this.SpawnFX();
    }

    protected virtual void DespawnBullet()
    {
        this.bulletCtrl.BulletDespawn.DespawnObj();
    }

    protected virtual void SpawnFX()
    {
        Vector3 spawnPos = transform.position;
        Quaternion spawnRot = transform.rotation;
        Transform newFX = FXSpawner.Instance.SpawnPrefab(transform.parent.name + " FX", spawnPos, spawnRot);
        if (newFX == null) return;
        newFX.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.SendDamageToObject(collision.transform);
    }
}
