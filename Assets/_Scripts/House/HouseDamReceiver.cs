using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseDamReceiver : DamageReceiver
{
    [Header("House Dam Receiver")]
    [SerializeField] protected float HouseHP = 5f;

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

    protected override void OnDead()
    {
        Debug.Log("LOSE");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerManager.Instance.EnemyLayer) return;
        
        EnemySpawner.Instance.DespawnToPool(collision.transform.parent);
    }
}
