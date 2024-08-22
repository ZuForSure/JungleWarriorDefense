using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MyMonoBehaviour
{
    [SerializeField] protected TurretAimEnemy turretAimEne;
    public TurretAimEnemy TurretAimEne => turretAimEne;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTurretAimEnemy();
    }

    protected virtual void LoadTurretAimEnemy()
    {
        if (this.turretAimEne != null) return;
        this.turretAimEne = transform.GetComponentInChildren<TurretAimEnemy>();
        Debug.Log(transform.name + ": LoadTurretAimEnemy", gameObject);
    }
}
