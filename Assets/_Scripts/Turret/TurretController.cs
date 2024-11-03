using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MyMonoBehaviour
{
    [SerializeField] protected TurretFindEnemy turretFindEne;
    [SerializeField] protected TurretSO turetSO;
    public TurretFindEnemy TurretFindEne => turretFindEne;
    public TurretSO TurretSO => turetSO;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTurretFindEnemy();
    }

    protected virtual void LoadTurretFindEnemy()
    {
        if (this.turretFindEne != null) return;
        this.turretFindEne = transform.GetComponentInChildren<TurretFindEnemy>();
        Debug.Log(transform.name + ": LoadTurretAimEnemy", gameObject);
    }
}
