using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAimEnemy : MyMonoBehaviour
{
    [SerializeField] protected Transform enemyTarget;
    [SerializeField] protected float shootRange = 5f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected bool isFindEnemy = false;
    [SerializeField] protected Vector3 lookAtEnemy;
    public bool IsFindEnemy => isFindEnemy;
    public Vector3 LookAtEnemy => lookAtEnemy;

    protected override void Update()
    {
        base.Update();
        this.IsEnemyComeIn();
    }

    protected virtual bool IsEnemyComeIn()
    {
        this.distance = Vector2.Distance(transform.parent.position, this.enemyTarget.position);

        if(this.distance > this.shootRange)
        {
            this.isFindEnemy = false;
            return this.isFindEnemy;
        }

        this.isFindEnemy = true;
        this.AimEnemy();

        return this.isFindEnemy;
    }

    protected virtual void AimEnemy() 
    {
        this.lookAtEnemy = this.enemyTarget.position - transform.parent.position;
        this.lookAtEnemy.z = 0f;
    }
}
