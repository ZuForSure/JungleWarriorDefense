using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankerAnimation : HeroAnimation
{
    [Header("Tanker Animation")]
    [SerializeField] protected bool isAttacking;

    protected override void Update()
    {
        base.Update();
        this.AttackAnimation();
    }

    protected virtual void AttackAnimation()
    {
        this.isAttacking = this.heroCtrl.HeroShooting.IsAttacking;
        this.animator.SetBool("IsAttacking", this.isAttacking);
    }
}
