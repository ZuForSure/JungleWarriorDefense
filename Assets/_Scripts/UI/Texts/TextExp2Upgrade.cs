using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextExp2Upgrade : TextExp
{
    [Header("Text Exp 2 Upgrade")]
    [SerializeField] protected UpgradeHero upgradeHero; 

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUpgradeHero();
    }

    protected virtual void LoadUpgradeHero()
    {
        if(this.upgradeHero != null) return;
        this.upgradeHero = GameObject.Find("Hero Upgrade Point").GetComponentInChildren<UpgradeHero>();
        Debug.Log(transform.name + ": LoadUpgradeHero", gameObject);
    }

    protected override void UpdateExpText()
    {
        this.text.SetText(this.upgradeHero.Exp2Upgrade.ToString());
    }
}
