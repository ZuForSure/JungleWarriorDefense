using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpin : BulletAbstract
{
    [Header("Bullet Spin")]
    [SerializeField] protected float spinSpeed = 500f;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.SpinTheBullet();
    }

    protected virtual void SpinTheBullet()
    {
        this.bulletCtrl.Model.Rotate(this.spinSpeed * Time.fixedDeltaTime * Vector3.forward);
    }
}
