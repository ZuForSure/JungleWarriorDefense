using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbstract : MyMonoBehaviour
{
    [Header("Enemy Abstract")]
    [SerializeField] protected EnemyController enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyController();
    }

    protected virtual void LoadEnemyController()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.GetComponentInParent<EnemyController>();
        Debug.Log(transform.name + ": LoadEnemyController", gameObject);
    }
}
