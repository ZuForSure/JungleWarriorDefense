using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ShootAbility : BossAbilityAbstract
{
    [Header("Shoot Ability")]
    public Transform player;
    [SerializeField] protected CircleCollider2D circleCollider2D;
    [SerializeField] protected float lineOfsite = 10f;
    [SerializeField] protected float time2Charge = 2f;
    [SerializeField] protected float damage = 3f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCircleCollider2D();
    }

    protected virtual void LoadCircleCollider2D()
    {
        if (this.circleCollider2D != null) return;
        this.circleCollider2D = transform.GetComponent<CircleCollider2D>();
        this.circleCollider2D.radius = this.lineOfsite;
        this.circleCollider2D.isTrigger = true;
        Debug.Log(transform.name + " :LoadCircleCollider2D", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer != LayerManager.Instance.HeroLayer) return;
        this.player = collision.transform;

        this.GetDirectionFromPlayer();
        this.SetTargetPlayer();

        StartCoroutine(this.Shooting());
    }

    public virtual Vector3 GetDirectionFromPlayer()
    {
        Vector3 direc = (this.player.position - transform.position);
        direc = direc.normalized;
        return direc;
    }

    protected virtual void SetTargetPlayer()
    {
        this.bossAbilityCtrl.BossMoveMent.target = this.player;
    }

    protected IEnumerator Shooting()
    {
        yield return new WaitForSeconds(this.time2Charge);

        Transform newBullet = BulletSpawner.Instance.SpawnPrefab(BulletSpawner.bossBullet, transform.position, transform.rotation);
        if (newBullet == null) yield return null;

        BulletController bulletCtrl = newBullet.GetComponent<BulletController>();
        bulletCtrl.bulletDamSender.bulletDamage = this.damage;
        bulletCtrl.SetShooter(transform.parent);

        newBullet.gameObject.SetActive(true);

        this.SpawnSound();
    }

    protected virtual void SpawnSound()
    {
        AudioManager.Instance.PlaySFX("Boss Shooting");
    }
}
