using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HeroAbstract : MyMonoBehaviour
{
    [Header("Hero Abstract")]
    [SerializeField] protected HeroController heroCtrl;
    public bool isCurrentHero = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHeroController();
    }
 
    protected virtual void LoadHeroController()
    {
        if (this.heroCtrl != null) return;
        this.heroCtrl = transform.GetComponentInParent<HeroController>();
        Debug.Log(transform.name + ": LoadHeroController", gameObject);
    }

    protected virtual bool CheckIsCurrentHero()
    {
        HeroController currentHero = PlayerManager.Instance.CurrentHero;
        if (currentHero != this.heroCtrl) this.isCurrentHero = false;
        else this.isCurrentHero = true;

        return this.isCurrentHero;
    }
}
