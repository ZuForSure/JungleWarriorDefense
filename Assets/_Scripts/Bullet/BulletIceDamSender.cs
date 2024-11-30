using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletIceDamSender : BulletDamSender
{
    [Header("Bullet Ice Dam Sender")]
    [SerializeField] protected float slowPercent = 0.7f;
    [SerializeField] protected float slowSpeed;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        this.SlowingEnemy(collision);
    }

    protected virtual void SlowingEnemy(Collider2D collision)
    {
        EnemyDamReceiver eDamRecei = collision.GetComponent<EnemyDamReceiver>();
        if (eDamRecei == null) return;

        this.slowSpeed = eDamRecei.EnemyController.EnemyMovement.baseSpeed * this.slowPercent;
        eDamRecei.EnemyController.EnemyMovement.UpdateSpeed(this.slowSpeed);

        this.SpawnFrozenFX(eDamRecei.transform.position, eDamRecei.transform.rotation);
    }

    protected virtual void SpawnFrozenFX(Vector3 pos, Quaternion rot)
    {
        Transform frozen = FXSpawner.Instance.SpawnPrefab(FXSpawner.frozen, pos, rot);
        if (frozen == null) return;
        frozen.gameObject.SetActive(true);
    }
}
