using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MyMonoBehaviour
{
    [SerializeField] protected Rigidbody2D bullet_rb;
    [SerializeField] protected float flySpeed = 10f;
    [SerializeField] protected Vector3 flyDirection = Vector3.right;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigiBody();
    }

    protected override void Update()
    {
        base.Update();
        this.Flying();
    }

    protected virtual void LoadRigiBody() 
    {
        if (this.bullet_rb != null) return;
        this.bullet_rb = transform.GetComponentInParent<Rigidbody2D>();
        this.bullet_rb.gravityScale = 0;
        Debug.Log(transform.name + ": LoadRigiBody2D", gameObject);
    }

    protected virtual void Flying()
    {
        this.bullet_rb.velocity = this.flyDirection * this.flySpeed;
    }
}
