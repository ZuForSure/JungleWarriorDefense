using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimation : HeroAbstract
{
    [Header("Hero Animation")]
    [SerializeField] protected Animator animator;
    [SerializeField] protected bool isWalking;
    [SerializeField] protected bool isJumping;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
    }

    protected override void Update()
    {
        base.Update();
        if (!this.CheckIsCurrentHero()) return;

        this.WalkAnimation();
        this.JumpAnimation();
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    protected virtual void WalkAnimation()
    {
        this.isWalking = InputManager.Instance.HorizontalInput != 0;
        this.animator.SetBool("IsWalking", this.isWalking);
    }

    protected virtual void JumpAnimation()
    {
        this.isJumping = InputManager.Instance.JumpInput;
        this.animator.SetBool("IsJumping", this.isJumping);
    }
}
