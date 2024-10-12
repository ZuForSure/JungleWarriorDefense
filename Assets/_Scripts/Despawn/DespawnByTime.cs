using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    [Header("Despawn By Time")]
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float time2Despawn = 0.5f;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetTimer();
    }

    protected virtual void ResetTimer()
    {
        this.timer = 0f;
    }

    protected override bool CanDespawn()
    {
        this.timer += Time.fixedDeltaTime;
        if (this.timer >= this.time2Despawn) return true;
        return false;
    }
}
