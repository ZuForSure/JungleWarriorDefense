using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurretAbstract : MyMonoBehaviour
{
    [Header("Turret Abstract")]
    [SerializeField] protected TurretController turretCtrl;

    protected override void LoadComponents()
    {
        this.LoadTurretController();
    }

    protected virtual void LoadTurretController()
    {
        if (this.turretCtrl != null) return;
        this.turretCtrl = transform.GetComponentInParent<TurretController>();
        Debug.Log(transform.name + ": LoadTurretController", gameObject);
    }
}
