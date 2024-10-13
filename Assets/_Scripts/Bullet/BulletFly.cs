using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MyMonoBehaviour
{
    [SerializeField] protected float flySpeed = 10f;
    [SerializeField] protected Vector3 flyDirection = Vector3.right;

    protected override void Update()
    {
        base.Update();
        this.Flying();
    }

    protected virtual void Flying()
    {
        transform.parent.Translate(this.flyDirection * this.flySpeed * Time.deltaTime);
    }
}
