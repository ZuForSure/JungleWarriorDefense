using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderBossHP : BaseSlider
{
    [Header("Slider Boss HP")]
    [SerializeField] protected EnemyController enemyController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyController();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.UpdateBossHP();
    }

    protected virtual void LoadEnemyController()
    {
        if (this.enemyController != null) return;
        this.enemyController = GameObject.Find("Boss").GetComponent<EnemyController>();
        Debug.Log(transform.name + ": LoadEnemyController", gameObject);
    }

    protected virtual void UpdateBossHP()
    {
        float bossHP = this.enemyController.EnemyDamReceiver.HP;
        this.progress = bossHP / this.enemyController.EnemyDamReceiver.MaxHP;

        this.slider.value = this.progress;
    }

    protected override void OnChange(float newValue)
    {

    }
}
