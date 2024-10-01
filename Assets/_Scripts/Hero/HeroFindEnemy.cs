using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFindEnemy : FindEnemyBase
{
    [Header("Hero Find Enemy")]
    [SerializeField] protected float heroShootRange = 10f;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.shootingRange = this.heroShootRange;
    }

    protected override void Update()
    {
        base.Update();
        this.UpdateRaycastDirection();
    }

    protected virtual void UpdateRaycastDirection()
    {
        if (InputManager.Instance.HorizontalInput == 0) return;

        if(InputManager.Instance.HorizontalInput < 0)
        {
            this.raycastDirection = Vector3.left;
            return;
        }

        this.raycastDirection = Vector3.right;
    }
}
