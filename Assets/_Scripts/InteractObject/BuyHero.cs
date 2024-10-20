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
        if (this.IsMaxHero()) return;
        if (!this.IsEnoughExp(this.exp2Buy)) return;
        this.SpawnHero();
    }

    protected virtual bool IsMaxHero()
    {
        if (HeroManager.Instance.Heros.Count >= this.maxHeros)
        {
            transform.parent.gameObject.SetActive(false);
            return true;
        }
        return false;
    }

    protected virtual void SpawnHero()
    {
        HeroSpawner heroType = HeroManager.Instance.GetRandomHeroClass();
        GameObject hero = heroType.GetHero(1);
        hero.SetActive(true);
    }
}
