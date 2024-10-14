using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyHero : PlayerInteract
{
    [Header("Buy")]
    [SerializeField] protected int exp2Buy = 50;
    [SerializeField] protected int maxHeros = 3;

    public override void OnPlayerInteract()
    {
        if (!this.IsEnoughExp()) return;
        this.SpawnHero();
    }

    protected virtual bool IsEnoughExp()
    {
        if (!ScoreManager.Instance.DeductExp(this.exp2Buy))
        {
            Debug.Log("NOT ENOUGH EXP");
            return false;
        }

        return true;
    }

    protected virtual void SpawnHero()
    {
        if (this.IsMaxHero()) return;

        HeroSpawner heroType = HeroManager.Instance.HerosClasses[1];
        GameObject hero = heroType.GetHero(1);
        hero.SetActive(true);
    }

    protected virtual bool IsMaxHero()
    {
        if(HeroManager.Instance.Heros.Count >= this.maxHeros)
        {
            transform.parent.gameObject.SetActive(false);
            return true;
        }
        return false;
    }
}
