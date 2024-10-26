using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MyMonoBehaviour
{
    [SerializeField] protected BulletDespawn bulletDespawn;
    [SerializeField] protected Rigidbody2D bulletRB;
    [SerializeField] protected Transform model;
    public BulletDespawn BulletDespawn => bulletDespawn;
    public Rigidbody2D BulletRB => bulletRB;
    public Transform Model => model;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletDespawn();
        this.LoadRigiBody2D();
        this.LoadModel();
    }

    protected virtual void LoadBulletDespawn()
    {
        if (this.bulletDespawn != null) return;
        this.bulletDespawn =  transform.GetComponentInChildren<BulletDespawn>();
        Debug.Log(transform.name + ": LoadBulletDespawn", gameObject);
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
}
