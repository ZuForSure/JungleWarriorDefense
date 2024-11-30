using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankerAttack : HeroShooting
{
    [Header("Tanker Attack")]
    [SerializeField] protected Transform attackPoint;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAttackPoint();
    }

    protected virtual void LoadAttackPoint()
    {
        if (this.attackPoint != null) return;
        this.attackPoint = transform.Find("Attack Point");
        Debug.Log(transform.name + ": LoadAttackPoint", gameObject);
    }

    protected override void SpawnBullet()
    {
        this.isAttacking = true;

        Vector3 spawnPos = this.attackPoint.position;
        Quaternion spawnRot = transform.rotation;
        Transform meleeAttack = BulletSpawner.Instance.SpawnPrefab(BulletSpawner.meleeAttack, spawnPos, spawnRot);
        if (meleeAttack == null) return;

        this.SetBulletDamage(meleeAttack);
        meleeAttack.gameObject.SetActive(true);

        this.SpawnSoundTanker();
    }

    protected virtual void SpawnSoundTanker()
    {
        AudioManager.Instance.PlaySFX("Melee Attack Hero");
    }
}
