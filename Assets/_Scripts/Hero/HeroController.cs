using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MyMonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb2d;
    [SerializeField] protected HeroMovement heroMovement;
    [SerializeField] protected HeroAnimation heroAnimation;
    [SerializeField] protected HeroFindEnemy heroFindEne;
    public Rigidbody2D RB2d => rb2d;
    public HeroMovement HeroMovement => heroMovement;
    public HeroAnimation HeroAnimation => heroAnimation;
    public HeroFindEnemy HeroFindEnemy => heroFindEne;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigibody();
        this.LoadHeroMovement();
        this.LoadHeroFindEnemy();
        this.LoadHeroAnimation();
    }

    protected virtual void LoadRigibody()
    {
        if(this.rb2d != null) return;
        this.rb2d = GetComponent<Rigidbody2D>();
        this.rb2d.gravityScale = 1.25f;
        this.rb2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        this.rb2d.sleepMode = RigidbodySleepMode2D.NeverSleep;
        this.rb2d.interpolation = RigidbodyInterpolation2D.Interpolate;
        this.rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
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

    protected virtual void LoadHeroFindEnemy()
    {
        if (this.heroFindEne != null) return;
        this.heroFindEne = transform.GetComponentInChildren<HeroFindEnemy>();
        Debug.Log(transform.name + ": LoadHeroFindEnemy", gameObject);
    }
}
