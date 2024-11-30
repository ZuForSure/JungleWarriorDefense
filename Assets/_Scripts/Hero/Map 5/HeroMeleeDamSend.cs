using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMeleeDamSend : MeleeDamageSender
{
    [Header("Hero Melee Dam Sender")]
    [SerializeField] protected HeroShootingMap5 shootingMap5;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHeroShootingMap5();
    }

    protected virtual void LoadHeroShootingMap5()
    {
        if (this.shootingMap5 != null) return;
        this.shootingMap5 = transform.parent.parent.GetChild(2).GetComponent<HeroShootingMap5>();
        Debug.Log(transform.name + ": LoadHeroShootingMap5", gameObject);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        this.SpawnSound();

        if (collision.gameObject.layer != LayerManager.Instance.EnemyLayer) return;
        if (this.shootingMap5.mana >= this.shootingMap5.maxMana) return;

        this.shootingMap5.mana++;
    }

    protected virtual void SpawnSound()
    {
        AudioManager.Instance.PlaySFX("Melee Attack");
    }
}
