using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : MyMonoBehaviour
{
    [Header("Damage Sender")]
    [SerializeField] protected Collider2D colli2D;
    [SerializeField] protected float damage = 1f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider2D();
    }

    protected virtual void LoadCollider2D()
    {
        if (this.colli2D != null) return;
        this.colli2D = transform.GetComponent<Collider2D>();
        Debug.Log(transform.name + ": LoadCollider2D", gameObject);
    }

    protected virtual void SendDamageToObject(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.SendDamage(damageReceiver);
    }

    protected virtual void SendDamage(DamageReceiver damageReceiver)
    {
        damageReceiver.DeductHp(this.damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.SendDamageToObject(collision.transform);
    }
}
