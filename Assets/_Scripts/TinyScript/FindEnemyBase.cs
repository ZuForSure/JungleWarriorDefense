using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FindEnemyBase : MyMonoBehaviour
{
    [Header("Find Enemy Base")]
    public bool isDrawRaycast = false;
    private readonly int heroLayer = 8, turretLayer = 9, bulletLayer = 10, boundLayer = 11;
    [SerializeField] protected float shootingRange = 1f;
    [SerializeField] protected Vector3 raycastDirection = Vector3.right;
    [SerializeField] protected bool isFindEnemy = false;
    public bool IsFindEnemy => isFindEnemy;

    protected override void Update()
    {
        base.Update();
        this.EnemyFinding();
    }

    protected virtual void EnemyFinding()
    {
        int bitMaskNotHitted = ~((1 << this.heroLayer) | (1 << this.turretLayer) | (1 << this.bulletLayer) | (1 << this.boundLayer));
        Vector3 pos = transform.position;
        RaycastHit2D hitEnemy = Physics2D.Raycast(pos, this.raycastDirection, this.shootingRange, bitMaskNotHitted);

        if (hitEnemy.collider == null)
        {
            this.isFindEnemy = false;
            return;
        }
        this.isFindEnemy = true;

        if (!this.isDrawRaycast) return;
        Debug.DrawLine(pos, new Vector3(pos.x + this.shootingRange, pos.y, 0f), Color.green);
    }
}
