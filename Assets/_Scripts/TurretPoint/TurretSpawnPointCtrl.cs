using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawnPointCtrl : MyMonoBehaviour
{
    [SerializeField] protected BuildAble buildAble;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBuildAble();
    }

    protected virtual void LoadBuildAble()
    {
        if (this.buildAble != null) return;
        this.buildAble = transform.GetComponentInChildren<BuildAble>();
        Debug.Log(transform.name + ": LoadBuildAble", gameObject);
    }
}
