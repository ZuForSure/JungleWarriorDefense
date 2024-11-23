using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimationMap5 : HeroAnimation
{
    [Header("Hero Animation Map 5")]
    [SerializeField] protected HeroAttackMelee attackMap5;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAtkMap5();
    }

    protected override void Update()
    {
        base.Update();
        this.AtkAnimation();
    }

    protected virtual void LoadAtkMap5()
    {
        if (this.attackMap5 != null) return;
        this.attackMap5 = GameObject.Find("Attack Melee").GetComponent<HeroAttackMelee>();
        Debug.Log(transform.name + ": LoadAtkMap5", gameObject);
    }

    protected virtual void AtkAnimation()
    {
        if (!this.attackMap5.IsAttaking) return;
        this.animator.SetTrigger("attack");
    }
}
