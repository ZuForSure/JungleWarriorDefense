using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimation : EnemyAnimation
{
    //[Header("Boss Animation")]

    protected override void Update()
    {
        base.Update();
        this.SwingWeaponAnimation();
    }

    protected virtual void SwingWeaponAnimation()
    {
        if (!this.enemyCtrl.BossAbilityCtrl.SwingWpAbility.IsPlayAnimation) return;
        this.animator.SetTrigger("attack");
    }
}
