using System.Collections;
using UnityEngine;

public class SwingWpAbility : BossAbilityAbstract
{
    [Header("Swing Weapon Ability")]
    [SerializeField] protected Transform hitBoxSwing;
    [SerializeField] protected float lineOfsite = 4f;
    [SerializeField] protected float timeBtwSwing = 2f;
    [SerializeField] protected bool isSwinged = true;
    [SerializeField] protected bool isPlayAnimation = false;
    public bool IsSwinged => isSwinged;
    public bool IsPlayAnimation => isPlayAnimation;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHitBoxSwing();
    }

    protected override void Update()
    {
        base.Update();
        if (!this.isSwinged) return;

        this.Swinging();
    }

    protected virtual void LoadHitBoxSwing()
    {
        if (this.hitBoxSwing != null) return;
        this.hitBoxSwing = transform.GetChild(0);
        Debug.Log(transform.name + ": LoadHitBoxSwing", gameObject);
    }

    protected virtual void Swinging()
    {
        if (this.bossAbilityCtrl.ShootAbility.player == null) return;
        float dist = Vector3.Distance(transform.position, this.bossAbilityCtrl.ShootAbility.player.transform.position);
        if (dist > this.lineOfsite) return;

        StartCoroutine(this.SwingWeaponDelay());
    }

    protected IEnumerator SwingWeaponDelay()
    {
        this.isSwinged = false;
        yield return new WaitForSeconds(this.timeBtwSwing);

        StartCoroutine(this.ActiveHitBox());

        this.isSwinged = true;
    }

    protected IEnumerator ActiveHitBox()
    {
        this.isPlayAnimation = true;
        this.hitBoxSwing.gameObject.SetActive(isPlayAnimation);
        this.SpawnSound();

        yield return new WaitForSeconds(0.02f);
        this.isPlayAnimation = false;
        this.hitBoxSwing.gameObject.SetActive(isPlayAnimation);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, this.lineOfsite);
    }

    protected virtual void SpawnSound()
    {
        AudioManager.Instance.PlaySFX("Melee Attack Hero");
    }
}
