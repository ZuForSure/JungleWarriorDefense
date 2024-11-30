using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]

public abstract class DamageReceiver : MyMonoBehaviour
{
    [Header("Damage Receiver")]
    [SerializeField] protected Collider2D colli;
    [SerializeField] protected float hp = 10f;
    [SerializeField] protected float maxHp = 10f;
    [SerializeField] protected bool isDead = false;
    public float HP => hp;  
    public float MaxHP => maxHp;  

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider2D();
    }

    protected virtual void LoadCollider2D()
    {
        if (this.colli != null) return;
        this.colli = transform.GetComponent<Collider2D>();
        Debug.Log(transform.name + ": LoadCollider2D", gameObject);
    }

    public virtual void DeductHp(float deduct)
    {
        if (this.IsDead()) return;

        this.hp -= deduct;
        if(this.hp <= 0) this.hp = 0;

        this.CheckIsDead();
    }

    protected virtual void ReBorn()
    {
        this.hp = this.maxHp;
        this.isDead = false;
    }

    protected virtual bool IsDead()
    {
        return this.hp <= 0;
    }

    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    protected abstract void OnDead();
}
