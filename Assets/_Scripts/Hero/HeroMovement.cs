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
    [SerializeField] protected float jumpForce = 250f;
    [SerializeField] protected float plusJumpForce = 1.2f;
    [SerializeField] protected bool pressJump = false;
    [SerializeField] protected bool canDoubleJump = false;
    [SerializeField] protected bool isGoingDown;
    protected bool isJumping = false;
    protected Vector3 offset = new (0, -0.8f, 0);
    protected Transform myGround;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = this.heroCtrl.HeroSO.moveSpeed;
    }

    protected override void Update()
    {
        base.Update();
        if (!this.CheckIsCurrentHero()) return;

        this.GetInput();
        this.GoingDown();
        this.Jumping();
        
        this.Flip();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (!this.CheckIsCurrentHero()) return;
        if (this.heroCtrl.heroHitBox.isTrigger) return;

        this.Walking();
    }

    protected virtual void GetInput()
    {
        this.horizontal = InputManager.Instance.HorizontalInput;
        this.pressJump = InputManager.Instance.JumpInput;
        this.isGoingDown = InputManager.Instance.VerticalInput < 0;
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
        if(this.GetRayCast().collider == null) return false;
        return true;
    }

    protected virtual void GoingDown()
    {
        if (!this.IsGrounded()) return;

        Ground ground = this.GetRayCast().transform.GetComponent<Ground>();
        if (ground == null) return;

        if (!this.isGoingDown) return;
        this.heroCtrl.heroHitBox.isTrigger = true;
    }

    protected virtual RaycastHit2D GetRayCast()
    {
        float extraHeight = 0.1f;
        Vector3 pos = transform.position + this.offset;
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.down, extraHeight);
        
        return hit;
    }

    protected virtual void Flip()
    {
        //float horizontal = InputManager.Instance.HorizontalInput;
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
