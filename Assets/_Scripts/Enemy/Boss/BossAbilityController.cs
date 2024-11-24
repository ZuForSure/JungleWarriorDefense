using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAbilityController : MyMonoBehaviour
{
    [SerializeField] protected BossMoveMent bossMove;
    [SerializeField] protected ShootAbility shootAbility;
    public BossMoveMent BossMoveMent => bossMove;
    public ShootAbility ShootAbility => shootAbility;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBossMovement();
        this.LoadShootingAbility();
    }

    protected virtual void LoadBossMovement()
    {
        if (this.bossMove != null) return;
        this.bossMove = transform.GetComponentInChildren<BossMoveMent>();
        Debug.Log(transform.name + ": LoadBossMovement", gameObject);
    }

    protected virtual void LoadShootingAbility()
    {
        if (this.shootAbility != null) return;
        this.shootAbility = transform.GetComponentInChildren<ShootAbility>();
        Debug.Log(transform.name + ": LoadShootingAbility", gameObject);
    }
}
