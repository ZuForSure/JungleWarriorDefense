using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoveMent : EnemyMovement
{
    [Header("Boss Move")]
    [SerializeField] protected List<Transform> targets;

    protected override void Start()
    {
        base.Start();
        this.SetNullTarget();
    }

    protected override void Update()
    {
        base.Update();
        this.StopShakeWhenBossAppeared();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.LookAtTarget();
    }

    protected override void Moving()
    {
        if(!this.CheckCanMove()) return;

        base.Moving();
    }

    protected virtual bool CheckCanMove()
    {
        bool canMove = this.enemyCtrl.BossAbilityCtrl.SwingWpAbility.IsSwinged;
        return canMove;
    }

    protected virtual void SetNullTarget()
    {
        this.target = null;
    }

    protected virtual void StopShakeWhenBossAppeared()
    {
        if (this.target == null) return;
        if (this.target.position.x < transform.parent.position.x) return;
        
        CameraShake.Instance.canShake = false;
    }

    protected virtual void LookAtTarget()
    {
        if (this.target == null) return;

        if (this.target.position.x > transform.parent.position.x + 0.5)
        {
            this.enemyCtrl.BossAbilityCtrl.Model.transform.localScale = new Vector3(-2, 2, 2);
            this.enemyCtrl.BossAbilityCtrl.SwingWpAbility.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            this.enemyCtrl.BossAbilityCtrl.Model.transform.localScale = new Vector3(2, 2, 2);
            this.enemyCtrl.BossAbilityCtrl.SwingWpAbility.transform.localScale = Vector3.one;
        }
    }
}
