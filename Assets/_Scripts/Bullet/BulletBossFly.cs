using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBossFly : BulletFly
{
    [Header("Bullet Boss Fly")]
    [SerializeField] protected BossAbilityController bossAbilityCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootAbility();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.flySpeed = 5f;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.SetFlyDirection();
    }

    protected virtual void LoadShootAbility()
    {
        if (this.bossAbilityCtrl != null) return;
        this.bossAbilityCtrl = GameObject.Find("Boss").GetComponent<BossAbilityController>();
        Debug.Log(transform.name + ": LoadShootAbility", gameObject);
    }

    protected virtual void SetFlyDirection()
    {
        this.flyDirection = this.bossAbilityCtrl.ShootAbility.GetDirectionFromPlayer();
    }
}
