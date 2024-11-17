using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretFindEnemy : FindEnemyBase
{
    [Header("Turret Find Enemy")]
    [SerializeField] protected Camera mainCam;
    [SerializeField] protected float turretShootingRange;

    protected override void ResetValue()
    {
        base.ResetValue();
        mainCam = Camera.main;
        this.ResetShootingRange();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetShootingRange();
    }

    protected virtual void ResetShootingRange()
    {
        Vector3 boundRightCam = mainCam.ViewportToWorldPoint(new Vector3(1, 1, this.mainCam.nearClipPlane));
        Vector3 boundRight = new(boundRightCam.x, transform.parent.position.y, 0);

        float disFromTurretToCamBound = Vector3.Distance(transform.parent.position, boundRight);
        this.turretShootingRange = disFromTurretToCamBound;

        this.shootingRange = this.turretShootingRange;
    }
}
