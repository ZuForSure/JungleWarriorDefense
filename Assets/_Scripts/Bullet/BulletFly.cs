using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MyMonoBehaviour
{
    [SerializeField] protected TurretController turretCtrl;
    [SerializeField] protected Rigidbody2D rb2D;
    [SerializeField] protected float flySpeed = 5f;
    [SerializeField] protected Vector3 flyDirection;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTurretCtroller();
        this.LoadRigiBody2D();
    }

    protected override void Update()
    {
        base.Update();
        this.Flying();
    }

    protected virtual void LoadTurretCtroller()
    {
        if (this.turretCtrl != null) return;
        this.turretCtrl = GameObject.Find("Turret").GetComponent<TurretController>();
        Debug.Log(transform.name + ": LoadTurretCtroller", gameObject);
    }

    protected virtual void LoadRigiBody2D() 
    {
        if (this.rb2D != null) return;
        this.rb2D = transform.GetComponentInParent<Rigidbody2D>();
        this.rb2D.gravityScale = 0;
        Debug.Log(transform.name + ": LoadRigiBody2D", gameObject);
    }

    protected virtual void Flying()
    {
        this.flyDirection = this.turretCtrl.TurretAimEne.LookAtEnemy;
        this.rb2D.AddForce(this.flyDirection * this.flySpeed);
    }
}
