using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamReceiver : DamageReceiver
{
    [Header("Enemy Damge Receiver")]
    [SerializeField] protected EnemyController enemyCtrl;
    [SerializeField] protected int gold, exp;

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
    }

    protected virtual void DespawnEnemy()
    {
        EnemySpawner.Instance.DespawnToPool(transform.parent);
    }

    protected virtual void GetScore()
    {
        ScoreManager.Instance.AddGold(this.gold);
        ScoreManager.Instance.AddExp(this.exp);
    }
}
