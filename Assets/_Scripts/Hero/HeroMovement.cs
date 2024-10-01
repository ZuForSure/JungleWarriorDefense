using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeroMovement : HeroAbstract
{
    [Header("Hero Movement")]

    [Header("Walk")]
    [SerializeField] protected float moveSpeed = 2.5f;
    [SerializeField] protected float horizontal;
    [SerializeField] protected Vector3 moveDirection;

    [Header("Jump")]
    [SerializeField] protected float jumpForce = 225f;
    [SerializeField] protected float plusJumpForce = 1.2f;
    [SerializeField] protected bool pressJump = false;
    [SerializeField] protected bool canDoubleJump = false;
    private readonly int groundLayer = 3, heroLayer = 8, ceilingLayer = 7;
    protected bool isJumping = false;
    protected Vector3 offset = new (0, -0.8f, 0);
    protected Transform myGround;

    protected override void Update()
    {
        base.Update();
        this.GetInput();
        this.Jumping();
        this.FindingGround();
        this.GoingDown();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Walking();
    }

    protected virtual void GetInput()
    {
        this.horizontal = InputManager.Instance.HorizontalInput;
        this.pressJump = InputManager.Instance.JumpInput;
    }

    protected virtual void Walking()
    {
        this.moveDirection = new Vector3(this.horizontal * this.moveSpeed, this.heroCtrl.RB2d.velocity.y, 0);
        this.heroCtrl.RB2d.velocity = this.moveDirection;
    }

    protected virtual void Jumping()
    {
        if (!this.pressJump) return;

        if (this.IsGrounded())
        {
            this.heroCtrl.RB2d.AddForce(new Vector3(this.heroCtrl.RB2d.velocity.x, this.jumpForce, 0));
            this.canDoubleJump = true;
        }
        else if (this.canDoubleJump)
        {
            this.heroCtrl.RB2d.AddForce(new Vector3(this.heroCtrl.RB2d.velocity.x, this.jumpForce * this.plusJumpForce, 0));
            this.canDoubleJump = false;
        }
    }

    protected virtual bool IsGrounded()
    {
        float extraHeight = 0.1f;
        Vector3 pos = transform.position + this.offset;
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.down, extraHeight);
        if(hit.collider == null) return false;

        return true /*hit.transform.gameObject.layer == this.groundLayer*/;
    }

    protected virtual void FindingGround()
    {
        int notHittedLayer = ~(1 << this.heroLayer);
        float extraHeight = 0.8f;
        Vector3 pos = transform.position + this.offset;

        RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.down, extraHeight, notHittedLayer);
        Debug.DrawLine(transform.position + this.offset, hit.point, Color.red);
        if (hit.collider == null) return;

        Ground ground = hit.transform.GetComponent<Ground>();
        if(ground == null) return;
        if (this.myGround == hit.transform) return;

        ground.ChangeLayer(this.groundLayer);
        this.myGround = hit.transform;
        Debug.Log(hit.transform.name);
    }

    protected virtual void GoingDown()
    {
        bool isGoingDown = InputManager.Instance.VerticalInput < 0;
        if(isGoingDown) this.ResetMyGround();
    }

    protected virtual void ResetMyGround()
    {
        if(this.myGround == null) return;
        this.myGround.GetComponent<Ground>().ChangeLayer(this.ceilingLayer);    
        this.myGround = null;
    }
}
