using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbstract : MyMonoBehaviour
{
    [Header("Bullet Abstract")]
    [SerializeField] protected BulletController bulletCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        if(this.bulletCtrl != null) return;
        this.bulletCtrl = transform.GetComponentInParent<BulletController>();
        Debug.Log(transform.name + ": LoadBulletCtrl", gameObject);
    }
}
