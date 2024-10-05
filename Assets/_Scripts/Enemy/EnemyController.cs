using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MyMonoBehaviour
{
    [SerializeField] protected Rigidbody2D e_rb;
    [SerializeField] protected EnemySO enemySO;
    public Rigidbody2D E_rb => e_rb;
    public EnemySO EnemySO => enemySO;  

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigi2D();
    }

    protected virtual void LoadRigi2D()
    {
        if (this.e_rb != null) return;
        this.e_rb = GetComponent<Rigidbody2D>();
        Debug.Log(transform.name + ": LoadRigi2D", gameObject);
    }
}
