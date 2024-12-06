using UnityEngine;

public class HeroController : MyMonoBehaviour
{
    public Collider2D heroHitBox;
    [SerializeField] protected Rigidbody2D rb2d;
    [SerializeField] protected HeroSO heroSO;
    [SerializeField] protected HeroMovement heroMovement;
    [SerializeField] protected HeroAnimation heroAnimation;
    [SerializeField] protected HeroFindEnemy heroFindEne;
    [SerializeField] protected HeroShooting heroShooting;
    public Rigidbody2D RB2d => rb2d;
    public HeroSO HeroSO => heroSO;
    public HeroAnimation HeroAnimation => heroAnimation;
    public HeroFindEnemy HeroFindEnemy => heroFindEne;
    public HeroShooting HeroShooting => heroShooting;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHeroMovement();
        this.LoadHeroFindEnemy();
        this.LoadHeroAnimation();
        this.LoadHeroAttack();
        this.LoadRigibody();
        this.LoadHitBox();
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

    protected virtual void LoadHeroAttack()
    {
        if (this.heroShooting != null) return;
        this.heroShooting = transform.GetComponentInChildren<HeroShooting>();
        Debug.Log(transform.name + ": LoadHeroAttack", gameObject);
    }

    protected virtual void LoadHitBox()
    {
        if (this.heroHitBox != null) return;
        this.heroHitBox = transform.Find("Hit Box").GetComponent<Collider2D>();
        Debug.Log(transform.name + ": LoadHitBox", gameObject);
    }
}
