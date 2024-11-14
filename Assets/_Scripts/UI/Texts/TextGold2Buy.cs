using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextGold2Buy : TextGold
{
    [Header("Text Gold 2 Buy")]
    [SerializeField] protected BuildTurret buyHero;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBuyTurret();
    }

    protected virtual void LoadBuyTurret()
    {
        if (this.buyHero != null) return;
        this.buyHero = GameObject.Find("Turret Point").GetComponentInChildren<BuildTurret>();
        Debug.Log(transform.name + ": LoadBuyTurret", gameObject);
    }

    protected override void UpdateGoldText()
    {
        this.text.SetText(this.buyHero.Gold2Buy.ToString());
    }
}
