using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamReceiver : DamageReceiver
{
    [Header("Enemy Damge Receiver")]
    [SerializeField] protected EnemyController enemyCtrl;
    [SerializeField] protected int gold, exp;
    public EnemyController EnemyController => enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.ResetHP();
        this.ResetGoldnExp();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ReBorn();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.GetComponentInParent<EnemyController>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    protected virtual void ResetHP()
    {
        this.maxHp = this.enemyCtrl.EnemySO.hp;
        this.ReBorn();
    }

    protected virtual void ResetGoldnExp()
    {
        this.gold = enemyCtrl.EnemySO.gold;
        this.exp = enemyCtrl.EnemySO.exp;
    }

    protected override void OnDead()
    {
        this.DespawnEnemy();
        this.GetScore();
        this.SpawnFX();
        this.SpawnSound();
    }

    protected virtual void DespawnEnemy()
    {
        EnemySpawner.Instance.DespawnToPool(transform.parent);
        WaveManager.Instance.enemyCount--;
    }

    protected virtual void GetScore()
    {
        ScoreManager.Instance.AddGold(this.gold);
        ScoreManager.Instance.AddExp(this.exp);
    }

    protected virtual void SpawnFX()
    {
        Vector3 spawnPos = transform.parent.position;
        Quaternion spawnRot = transform.rotation;
        Transform newFX = FXSpawner.Instance.SpawnPrefab(FXSpawner.enemyDead, spawnPos, spawnRot);
        if (newFX == null) return;
        newFX.gameObject.SetActive(true);
    }

    protected virtual void SpawnSound()
    {
        AudioManager.Instance.PlaySFX("Enemy Die");
    }
}
