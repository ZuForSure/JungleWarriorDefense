using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MyMonoBehaviour
{
    protected static ScoreManager instance;
    public static ScoreManager Instance => instance;

    public int gold = 0;
    public int exp = 0;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 ScoreManager");
        ScoreManager.instance = this;
    }

    public virtual void AddGold(int amount)
    {
        this.gold += amount;
    }

    public virtual void AddExp(int amount)
    {
        this.exp += amount;
    }
}
