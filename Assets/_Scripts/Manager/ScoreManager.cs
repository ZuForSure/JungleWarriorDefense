using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MyMonoBehaviour
{
    protected static ScoreManager instance;
    public static ScoreManager Instance => instance;

    [SerializeField] protected int gold = 0;
    [SerializeField] protected int exp = 0;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 ScoreManager");
        ScoreManager.instance = this;
    }

    public virtual int GetGold()
    {
        return this.gold;
    }

    public virtual int GetExp()
    {
        return this.exp;
    }

    public virtual void AddGold(int amount)
    {
        this.gold += amount;
    }

    public virtual void AddExp(int amount)
    {
        this.exp += amount;
    }

    public virtual bool DeductGold(int amount)
    {
        if (!CanDeduct(this.gold, amount)) return false;
        this.gold -= amount;
        return true;
    }

    public virtual bool DeductExp(int amount)
    {
        if (!CanDeduct(this.exp, amount)) return false;
        this.exp -= amount;
        return true;
    }

    protected virtual bool CanDeduct(int scoreType, int amout)
    {
        if(amout > scoreType) return false; 
        if(scoreType <= 0) return false;
        return true;
    }
}
