using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CheckPlayerComing : MyMonoBehaviour
{
    [SerializeField] protected BossMoveMent bossMove;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBossMoveMent();
    }

    protected virtual void LoadBossMoveMent()
    {
        if (this.bossMove != null) return;
        this.bossMove = GameObject.Find("Boss").GetComponentInChildren<BossMoveMent>();
        Debug.Log(transform.name + ": LoadBossMoveMent", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerManager.Instance.HeroLayer) return;

        this.bossMove.target = GameObject.Find("Target Points").transform;
        CameraShake.Instance.canShake = true;

        Destroy(transform.parent.gameObject);
    }
}
