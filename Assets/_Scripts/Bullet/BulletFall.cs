using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFall : BulletFly
{
    protected override void ResetValue()
    {
        base.ResetValue();

        this.flyDirection = Vector3.down;
        this.flySpeed = 5f;
    }
}
