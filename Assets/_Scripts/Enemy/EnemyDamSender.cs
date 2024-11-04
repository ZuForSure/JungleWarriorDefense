using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamSender : DamageSender
{
    [Header("Enemy Dam Sender")]
    [SerializeField] protected EnemyController eCtrl;
    [SerializeField] protected float time2SendDamge = 1f;
    [SerializeField] protected bool isDetectTurret = false;
    public float Time2SendDamge => time2SendDamge;
    public bool IsDetectTurret => isDetectTurret;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.damage = this.eCtrl.EnemySO.damage;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.eCtrl != null) return;
        this.eCtrl = transform.GetComponentInParent<EnemyController>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer != LayerManager.Instance.TurretLayer) return;
        
        this.isDetectTurret = true;
        this.eCtrl.EnemyAnimation.AttackAnimation();
        this.SendDamageToObject(collision.transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer != LayerManager.Instance.TurretLayer) return;
        this.isDetectTurret = false;
    }
}
