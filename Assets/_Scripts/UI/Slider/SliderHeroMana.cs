using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHeroMana : BaseSlider
{
    [Header("Slider Hero Mana")]
    [SerializeField] protected HeroShootingMap5 heroShootingM5;

    protected override void Update()
    {
        base.Update();
        this.LoadHeroShootingM5();
        this.UpdateHeroHP();
    }

    protected virtual void LoadHeroShootingM5()
    {
        if (this.heroShootingM5 != null) return;
        this.heroShootingM5 = GameObject.Find("Hero Shooting").GetComponent<HeroShootingMap5>();
        Debug.Log(transform.name + ": LoadHeroShootingM5", gameObject);
    }

    protected virtual void UpdateHeroHP()
    {
        float heroMana = (float)this.heroShootingM5.mana;
        this.progress = heroMana / (float)this.heroShootingM5.maxMana;

        this.slider.value = this.progress;
    }

    protected override void OnChange(float newValue)
    {
        
    }
}
