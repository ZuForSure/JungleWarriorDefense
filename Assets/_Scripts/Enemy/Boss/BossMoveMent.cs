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

    protected virtual void SetNullTarget()
    {
        this.target = null;
    }

    protected virtual void StopShakeWhenBossAppeared()
    {
        if (this.target == null) return;
        if (this.target.position.x < transform.parent.position.x) return;
        
        CameraShake.Instance.canShake = false;
        this.SetNullTarget();
    }
}
