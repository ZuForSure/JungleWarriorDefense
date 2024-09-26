using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeroMovement : HeroAbstract
{
    [Header("Hero Movement")]
    private bool isFacingRight = true;

    [Header("Walk")]
    [SerializeField] protected float moveSpeed = 2.5f;
    [SerializeField] protected float horizontal;
    [SerializeField] protected Vector3 moveDirection;

    [Header("Jump")]
    [SerializeField] protected LayerMask groundLayer;
    [SerializeField] protected float jumpForce = 225f;
    [SerializeField] protected float plusJumpForce = 1.2f;
    [SerializeField] protected bool pressJump = false;
    [SerializeField] protected bool canDoubleJump = false;
    protected bool isJumping = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGroundLayer();
    }

    protected override void Update()
    {
        base.Update();
        this.GetInput();
        this.Jumping();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Walking();
        this.Flip();
    }

    protected virtual void LoadGroundLayer()
    {
        if (this.groundLayer.value != 0) return;
        this.groundLayer = LayerMask.GetMask("ground layer");
        Debug.Log(transform.name + ": LoadGroundLayer", gameObject);
    }

    protected virtual void GetInput()
    {
        this.horizontal = InputManager.Instance.HorizontalInput;
        this.pressJump = InputManager.Instance.JumpInput;
    }

    protected virtual void Walking()
    {
        this.moveDirection = new Vector3(this.horizontal * this.moveSpeed, this.heroCtrl.RB.velocity.y, 0);
        this.heroCtrl.RB.velocity = this.moveDirection;
    }

    protected virtual void Jumping()
    {
        if (!this.pressJump) return;

        if (this.IsGrounded())
        {
            this.heroCtrl.RB.AddForce(new Vector3(this.heroCtrl.RB.velocity.x, this.jumpForce, 0));
            this.canDoubleJump = true;
        }
        else if (this.canDoubleJump)
        {
            this.heroCtrl.RB.AddForce(new Vector3(this.heroCtrl.RB.velocity.x, this.jumpForce * this.plusJumpForce, 0));
            this.canDoubleJump = false;
        }
    }

    protected virtual bool IsGrounded()
    {
        float extraHeight = 0.8f;
        bool isRaycastHit = Physics.Raycast(transform.position, Vector3.down, extraHeight, this.groundLayer);
        Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - extraHeight, 0), Color.green);

        return isRaycastHit;
    }

    protected virtual void Flip()
    {
        if (this.horizontal == 0) return;

        if (this.horizontal > 0 && !this.isFacingRight) this.Fliped();
        if (this.horizontal < 0 && this.isFacingRight) this.Fliped();
    }

    protected virtual void Fliped()
    {
        Vector3 localScale = this.heroCtrl.HeroAnimation.transform.localScale;
        localScale.x *= -1;
        this.heroCtrl.HeroAnimation.transform.localScale = localScale;
        this.isFacingRight = !this.isFacingRight;
    }
}
