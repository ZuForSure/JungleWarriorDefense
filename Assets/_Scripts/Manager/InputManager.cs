using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MyMonoBehaviour
{
    protected static InputManager instance;
    public static InputManager Instance => instance;

    [SerializeField] protected float mouseInput;
    [SerializeField] protected float horizotalInput;
    [SerializeField] protected bool jumpInput;
    public float MouseInput => mouseInput;
    public float HorizontalInput => horizotalInput;
    public bool JumpInput => jumpInput;

    protected override void Awake()
    {
        if (instance != null) Debug.LogWarning("Only 1 InputManager");
        InputManager.instance = this;
    }

    protected override void Update()
    {
        base.Update();
        this.GetMouseInput();
        this.GetHorizontalInput();
        this.GetJumpInput();
    }

    protected virtual void GetMouseInput()
    {
        this.mouseInput = Input.GetAxis("Fire1");
    }

    protected virtual void GetHorizontalInput()
    {
        this.horizotalInput = Input.GetAxisRaw("Horizontal");
    }

    protected virtual void GetJumpInput()
    {
        this.jumpInput = Input.GetButtonDown("Jump");
    }
}
