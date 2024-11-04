using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MyMonoBehaviour
{
    [SerializeField] protected Rigidbody2D e_rb;
    [SerializeField] protected EnemySO enemySO;
    [SerializeField] protected EnemyDamSender enemyDamSender;
    [SerializeField] protected EnemyAnimation eAnimation;
    public Rigidbody2D E_rb => e_rb;
    public EnemySO EnemySO => enemySO;  
    public EnemyDamSender EnemyDamSender => enemyDamSender;  
    public EnemyAnimation EnemyAnimation => eAnimation;  

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigi2D();
        this.LoadEnemyAnimator();
        this.LoadDamSender();
    }

    protected virtual void LoadRigi2D()
    {
        if (this.e_rb != null) return;
        this.e_rb = GetComponent<Rigidbody2D>();
        Debug.Log(transform.name + ": LoadRigi2D", gameObject);
    }

    protected virtual void LoadEnemyAnimator()
    {
        if (this.eAnimation != null) return;
        this.eAnimation = transform.GetComponentInChildren<EnemyAnimation>();
        Debug.Log(transform.name + ": LoadEnemyAnimator", gameObject);
    }

    protected virtual void LoadDamSender()
    {
        if (this.enemyDamSender != null) return;
        this.enemyDamSender = transform.GetComponentInChildren<EnemyDamSender>();
        Debug.Log(transform.name + ": LoadDamSender", gameObject);
    }
}
