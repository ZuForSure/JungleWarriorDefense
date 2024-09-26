using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MyMonoBehaviour
{
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected HeroMovement heroMovement;
    [SerializeField] protected HeroAnimation heroAnimation;
    public Rigidbody RB => rb;
    public HeroMovement HeroMovement => heroMovement;
    public HeroAnimation HeroAnimation => heroAnimation;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigibody();
        this.LoadHeroMovement();
        this.LoadHeroAnimation();
    }

    protected virtual void LoadRigibody()
    {
        if(this.rb != null) return;
        this.rb = GetComponent<Rigidbody>();
        Debug.Log(transform.name + ": LoadRigibody", gameObject);
    }

    protected virtual void LoadHeroMovement()
    {
        if (this.heroMovement != null) return;
        this.heroMovement = transform.GetComponentInChildren<HeroMovement>();
        Debug.Log(transform.name + ": LoadHeroMovement", gameObject);
    }

    protected virtual void LoadHeroAnimation()
    {
        if (this.heroAnimation != null) return;
        this.heroAnimation = transform.GetComponentInChildren<HeroAnimation>();
        Debug.Log(transform.name + ": LoadHeroMovement", gameObject);
    }
}
