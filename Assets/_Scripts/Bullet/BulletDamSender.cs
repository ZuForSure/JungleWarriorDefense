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
    }

    protected virtual void DespawnBullet()
    {
        this.bulletCtrl.BulletDespawn.DespawnObj();
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(transform.name + ": Collision with " + collision.transform.name);
    //    this.SendDamageToObject(collision.transform);
    //}

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(transform.name + ": Collision with " + other.transform.name);
        this.SendDamageToObject(other.transform);
    }
}
