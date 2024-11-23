using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeroFindEnemy : FindEnemyBase
{
    [Header("Hero Find Enemy")]
    [SerializeField] protected HeroController heroCtrl;
    [SerializeField] protected float heroShootRange = 10f;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.shootingRange = this.heroShootRange;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHeroContrl();
    }

    protected override void Update()
    {
        this.CheckAutoAttack2TurnDirectionRaycast();
        this.EnemyFinding();
    }

    protected virtual void LoadHeroContrl()
    {
        if (this.heroCtrl != null) return;
        this.heroCtrl = transform.GetComponentInParent<HeroController>();
        Debug.Log(transform.name + ": LoadHeroContrl", gameObject);
    }

    protected virtual void CheckAutoAttack2TurnDirectionRaycast()
    {
        if (!this.heroCtrl.HeroShooting.IsAutoAttack) return;
        if (this.heroCtrl.HeroAnimation.transform.localScale.x > 0) return;
        this.raycastDirection = Vector3.left;
    }
}
