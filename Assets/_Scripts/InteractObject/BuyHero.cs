using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyHero : PlayerInteract
{
    [Header("Buy")]
    [SerializeField] protected int exp2Buy = 100;
    [SerializeField] protected int maxHeros = 3;
    [SerializeField] protected GameObject close, open;
    public int Exp2Buy => exp2Buy;  

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGameObj();
    }

    protected virtual void LoadGameObj()
    {
        if (this.close != null) return;
        this.close = GameObject.Find("Close");
        this.open = GameObject.Find("Open");
        this.open.SetActive(false);    
        Debug.Log(transform.name + ": LoadGameObj", gameObject);
    }

    public override void OnPlayerInteract()
    {
        if (this.IsMaxHero()) return;
        if (!this.IsEnoughExp(this.exp2Buy)) return;
        this.SpawnHero();
        this.SpawnSound();
    }

    protected virtual bool IsMaxHero()
    {
        if (HeroManager.Instance.Heros.Count >= this.maxHeros)
        {
            //transform.parent.gameObject.SetActive(false);
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

    protected virtual void SpawnSound()
    {
        AudioManager.Instance.PlaySFX("buy new things");
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.layer != LayerManager.Instance.HeroLayer) return;

        this.open.SetActive(true);
        this.close.SetActive(false);
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
        if (collision.gameObject.layer != LayerManager.Instance.HeroLayer) return;

        this.open.SetActive(false);
        this.close.SetActive(true);    
    }
}
