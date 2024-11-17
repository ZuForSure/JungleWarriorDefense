using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseDamReceiver : DamageReceiver
{
    [Header("House Dam Receiver")]
    [SerializeField] protected float houseHP = 5f;
    public float HouseHP => houseHP;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.ResetHouseHP();
    }

    protected virtual void ResetHouseHP()
    {
        this.maxHp = this.HouseHP;
        this.ReBorn();
    }

    protected override void Update()
    {
        base.Update();
        this.CheckIsVictory();
    }

    protected override void OnDead()
    {
        GameManager.Instance.GameOver();
    }

    protected virtual void CheckIsVictory()
    {
        if (WaveManager.Instance.WaveCount > WaveManager.Instance.FinalWave) 
        {
            if (WaveManager.Instance.enemyCount > 0) return;
            if (this.hp <= 0) return;

            GameManager.Instance.VictoryGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerManager.Instance.EnemyLayer) return;
        this.DeductHp(1);
        EnemySpawner.Instance.DespawnToPool(collision.transform.parent);
        WaveManager.Instance.enemyCount--;
    }
}
