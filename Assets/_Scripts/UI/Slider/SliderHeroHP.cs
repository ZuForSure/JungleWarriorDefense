using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHeroHP : BaseSlider
{
    [Header("Slider Hero HP")]
    [SerializeField] protected HeroDamgeReceiver heroDamgeReceiver;

    protected override void Update()
    {
        base.Update();
        this.LoadHeroDamRecei();
        this.UpdateHeroHP();
    }

    protected virtual void LoadHeroDamRecei()
    {
        if (this.heroDamgeReceiver != null) return;
        this.heroDamgeReceiver = GameObject.Find("Hit Box").GetComponent<HeroDamgeReceiver>();
        Debug.Log(transform.name + ": LoadHeroDamRecei", gameObject);
    }

    protected virtual void UpdateHeroHP()
    {
        float heroHP = this.heroDamgeReceiver.HP;
        this.progress = heroHP / this.heroDamgeReceiver.MaxHP;

        this.slider.value = this.progress;
    }

    protected override void OnChange(float newValue)
    {
        
    }
}
