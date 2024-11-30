using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CheckPlayerComing : MyMonoBehaviour
{
    [SerializeField] protected Transform UIRightClick;
    [SerializeField] protected BossMoveMent bossMove;
    [SerializeField] protected SliderBossHP sliderBossHp;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIRightClick();
        this.LoadBossMoveMent();
        this.LoadSliderBoss();
    }

    protected override void Start()
    {
        base.Start();
        this.sliderBossHp.transform.gameObject.SetActive(false);
        this.UIRightClick.transform.gameObject.SetActive(true);
    }

    protected virtual void LoadUIRightClick()
    {
        if (this.UIRightClick != null) return;
        this.UIRightClick = GameObject.Find("UI Right Click").transform;
        Debug.Log(transform.name + ": LoadUIRightClick", gameObject);
    }

    protected virtual void LoadBossMoveMent()
    {
        if (this.bossMove != null) return;
        this.bossMove = GameObject.Find("Boss").GetComponentInChildren<BossMoveMent>();
        Debug.Log(transform.name + ": LoadBossMoveMent", gameObject);
    }
    
    protected virtual void LoadSliderBoss()
    {
        if (this.sliderBossHp != null) return;
        this.sliderBossHp = GameObject.Find("Boss HP UI").GetComponent<SliderBossHP>();
        Debug.Log(transform.name + ": LoadSliderBoss", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerManager.Instance.HeroLayer) return;

        this.bossMove.target = GameObject.Find("Target Points").transform;

        this.sliderBossHp.transform.gameObject.SetActive(true);
        this.UIRightClick.transform.gameObject.SetActive(false);
        this.SpawnSound();

        CameraShake.Instance.canShake = true;
        Destroy(transform.parent.gameObject);
    }

    protected virtual void SpawnSound()
    {
        AudioManager.Instance.PlaySFX("earthquake");
    }
}
