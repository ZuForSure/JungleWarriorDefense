using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttackMelee : HeroAbstract
{
    [Header("Hero Attack Melee")]
    [SerializeField] protected Transform hitBoxRange;
    [SerializeField] protected bool isAttack = false;
    public float atkDelay = 0f;
    public float startAtkDelay = 0.5f;
    public bool IsAttaking => isAttack;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHitBoxRange();
    }

    protected override void Update()
    {
        base.Update();
        this.Attacking();
    }

    protected virtual void LoadHitBoxRange()
    {
        if (this.hitBoxRange != null) return;
        this.hitBoxRange = transform.GetChild(0);
        Debug.Log(transform.name + ": LoadHitBoxRange", gameObject);
    }

    public virtual void Attacking()
    {
        if (this.atkDelay <= 0)
        {
            if (InputManager.Instance.RightClickInput <= 0) return;

            StartCoroutine(this.ActiveHitBox());
            this.SpawnSound();
            this.atkDelay = this.startAtkDelay;
        }
        else
        {
            this.atkDelay -= Time.deltaTime;
        }
    }

    protected IEnumerator ActiveHitBox()
    {
        this.isAttack = true;
        this.hitBoxRange.gameObject.SetActive(this.isAttack);

        yield return new WaitForSeconds(0.02f);

        this.isAttack = false;
        this.hitBoxRange.gameObject.SetActive(this.isAttack);
    }

    protected virtual void SpawnSound()
    {
        AudioManager.Instance.PlaySFX("Melee Attack Map 5");
    }
}
