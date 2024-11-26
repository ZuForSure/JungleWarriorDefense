using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossAbilityController : MyMonoBehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected BossMoveMent bossMove;
    [SerializeField] protected ShootAbility shootAbility;
    [SerializeField] protected SwingWpAbility swingWpAbility;
    public Transform Model => model;
    public BossMoveMent BossMoveMent => bossMove;
    public ShootAbility ShootAbility => shootAbility;
    public SwingWpAbility SwingWpAbility => swingWpAbility;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadBossMovement();
        this.LoadShootingAbility();
        this.LoadSwingWpAbility();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.GetChild(0);
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadBossMovement()
    {
        if (this.bossMove != null) return;
        this.bossMove = transform.GetComponentInChildren<BossMoveMent>();
        Debug.Log(transform.name + ": LoadBossMovement", gameObject);
    }

    protected virtual void LoadShootingAbility()
    {
        if (this.shootAbility != null) return;
        this.shootAbility = transform.GetComponentInChildren<ShootAbility>();
        Debug.Log(transform.name + ": LoadShootingAbility", gameObject);
    }

    protected virtual void LoadSwingWpAbility()
    {
        if (this.swingWpAbility != null) return;
        this.swingWpAbility = transform.GetComponentInChildren<SwingWpAbility>();
        Debug.Log(transform.name + ": LoadSwingWpAbility", gameObject);

    }
}
