using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MyMonoBehaviour
{
    [SerializeField] protected float flySpeed = 5f;
    [SerializeField] protected Vector3 flyDirection = Vector3.down;
    [SerializeField] protected Rigidbody2D rb2D;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigiBody2D();
    }

    protected override void Update()
    {
        this.Flying();
    }


    protected virtual void LoadRigiBody2D() 
    {
        if (this.rb2D != null) return;
        this.rb2D = GetComponentInParent<Rigidbody2D>();
        this.rb2D.gravityScale = 0;
        Debug.Log(transform.name + ": LoadRigiBody2D", gameObject);
    }

    protected virtual void Flying()
    {
        this.rb2D.AddForce(this.flyDirection * this.flySpeed);
    }
}
