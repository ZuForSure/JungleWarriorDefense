using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossAbilityAbstract : MyMonoBehaviour
{
    [Header("Boss Ability Abstract")]
    [SerializeField] protected BossAbilityController bossAbilityCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBossAbiController();
    }

    protected virtual void LoadBossAbiController()
    {
        if (this.bossAbilityCtrl != null) return;
        this.bossAbilityCtrl = transform.GetComponentInParent<BossAbilityController>();
        Debug.Log(transform.name + ": LoadBossAbiController", gameObject);
    }
}
