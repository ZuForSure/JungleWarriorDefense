using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAimEnemy : MyMonoBehaviour
{
    public Transform enemyTarget;
    [SerializeField] protected float shootRange = 7f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected bool isEnemyComeIn = false;
    [SerializeField] protected Vector2 lookAtEnemy;
    public bool IsEnemyComeIn => isEnemyComeIn;
    public Vector2 LookAtEnemy => lookAtEnemy;

    protected override void Update()
    {
        base.Update();
        this.CheckEnemyComeIn();
    }

    protected virtual bool CheckEnemyComeIn()
    {
        this.distance = Vector2.Distance(transform.parent.position, this.enemyTarget.position);

        if(this.distance > this.shootRange)
        {
            this.isEnemyComeIn = false;
            return this.isEnemyComeIn;
        }

        this.isEnemyComeIn = true;
        this.AimEnemy();
        return this.isEnemyComeIn;
    }

    protected virtual void AimEnemy()
    {
        this.lookAtEnemy = this.enemyTarget.position - transform.parent.position;
        this.lookAtEnemy.Normalize();
    }
}
