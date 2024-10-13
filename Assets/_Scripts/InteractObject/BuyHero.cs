using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyHero : PlayerInteract
{
    [Header("Buy")]
    [SerializeField] protected int exp2Buy = 50;

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
        HeroSpawner heroType = HeroManager.Instance.Heros[1];
        GameObject hero = heroType.GetHero(1);
        hero.SetActive(true);
    }
}
