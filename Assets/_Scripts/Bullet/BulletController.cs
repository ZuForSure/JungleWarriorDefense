using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MyMonoBehaviour
{
    [SerializeField] protected Rigidbody2D bulletRB;
    [SerializeField] protected BulletDespawn bulletDespawn;
    [SerializeField] protected Transform model;
    [SerializeField] protected Transform shooter;
    public BulletDamSender bulletDamSender;
    public BulletDespawn BulletDespawn => bulletDespawn;
    public Transform Model => model;
    public Transform Shooter => shooter;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletDespawn();
        this.LoadBulletDamSender();
        this.LoadRigiBody2D();
        this.LoadModel();
    }

    protected virtual void LoadBulletDespawn()
    {
        if (this.bulletDespawn != null) return;
        this.bulletDespawn =  transform.GetComponentInChildren<BulletDespawn>();
        //Debug.Log(transform.name + ": LoadBulletDespawn", gameObject);
    }

    protected virtual void LoadBulletDamSender()
    {
        if (this.bulletDamSender != null) return;
        this.bulletDamSender = transform.GetComponentInChildren<BulletDamSender>();
        Debug.Log(transform.name + ": LoadBulletDamSender", gameObject);
    }

    protected virtual void LoadRigiBody2D()
    {
        if (this.bulletRB != null) return;
        this.bulletRB = transform.GetComponent<Rigidbody2D>();
        Debug.Log(transform.name + ": LoadRigiBody2D", gameObject);
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    public virtual void SetShooter(Transform shooter)
    {
        this.shooter = shooter;
    }
}
