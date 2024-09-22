using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MyMonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb2D;
    public Rigidbody2D Rb2D => rb2D;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigi2D();
    }

    protected virtual void LoadRigi2D()
    {
        if (this.rb2D != null) return;
        this.rb2D = GetComponent<Rigidbody2D>();
        Debug.Log(transform.name + ": LoadRigi2D", gameObject);
    }
}
