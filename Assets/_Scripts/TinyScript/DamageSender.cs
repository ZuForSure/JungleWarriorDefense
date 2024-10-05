using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]

public abstract class DamageSender : MyMonoBehaviour
{
    [Header("Damage Sender")]
    [SerializeField] protected Collider2D colli;
    [SerializeField] protected float damage = 1f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }

    protected virtual void LoadCollider()
    {
        if (this.colli != null) return;
        this.colli = transform.GetComponent<Collider2D>();
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    protected virtual void SendDamageToObject(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponent<DamageReceiver>();
        if (damageReceiver == null) return;
        this.SendDamage(damageReceiver);
    }

    protected virtual void SendDamage(DamageReceiver damageReceiver)
    {
        damageReceiver.DeductHp(this.damage);
    }
}
