using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimation : HeroAbstract
{
    [Header("Hero Animation")]
    [SerializeField] protected Animator animator;
    [SerializeField] protected bool isWalking;
    [SerializeField] protected bool isJumping;
    private bool isFacingRight = true;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
    }

    protected override void Update()
    {
        base.Update();
        this.WalkAnimation();
        this.JumpAnimation();
        this.Flip();
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

    protected virtual void Flip()
    {
        float horizontal = InputManager.Instance.HorizontalInput;
        if (horizontal == 0) return;

        if (horizontal > 0 && !this.isFacingRight) this.Fliped();
        if (horizontal < 0 && this.isFacingRight) this.Fliped();
    }

    protected virtual void Fliped()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
        this.isFacingRight = !this.isFacingRight;
    }
}
