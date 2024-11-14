using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextExp2Buy : TextExp
{
    [Header("Text Exp 2 Buy")]
    [SerializeField] protected BuyHero buyHero; 

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUpgradeHero();
    }

    protected virtual void LoadUpgradeHero()
    {
        if(this.buyHero != null) return;
        this.buyHero = GameObject.Find("Hero Buy Point").GetComponentInChildren<BuyHero>();
        Debug.Log(transform.name + ": LoadUpgradeHero", gameObject);
    }

    protected override void UpdateExpText()
    {
        this.text.SetText(this.buyHero.Exp2Buy.ToString());
    }
}
