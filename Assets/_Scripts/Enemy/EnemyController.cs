using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MyMonoBehaviour
{
    [SerializeField] protected Rigidbody e_rb;
    public Rigidbody E_rb => e_rb;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigi2D();
    }

    protected virtual void LoadRigi2D()
    {
        if (this.e_rb != null) return;
        this.e_rb = GetComponent<Rigidbody>();
        Debug.Log(transform.name + ": LoadRigi2D", gameObject);
    }
}
