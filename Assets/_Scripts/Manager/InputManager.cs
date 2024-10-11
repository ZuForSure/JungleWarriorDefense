using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MyMonoBehaviour
{
    protected static InputManager instance;
    public static InputManager Instance => instance;

    [SerializeField] protected float mouseInput;
    [SerializeField] protected float horizotalInput;
    [SerializeField] protected float verticalInput;
    [SerializeField] protected bool jumpInput;
    public PlayerInteract playerInteract;
    public float MouseInput => mouseInput;
    public float HorizontalInput => horizotalInput;
    public float VerticalInput => verticalInput;
    public bool JumpInput => jumpInput;

    protected override void Awake()
    {
        if (instance != null) Debug.LogWarning("Only 1 InputManager");
        InputManager.instance = this;
    }

    protected override void Update()
    {
        this.GetMouseInput();
        this.GetMovementInput();
        this.GetJumpInput();
        this.GetInteractInput();
    }


    protected virtual void GetMouseInput()
    {
        this.mouseInput = Input.GetAxisRaw("Fire1");
    }

    protected virtual void GetMovementInput()
    {
        this.horizotalInput = Input.GetAxisRaw("Horizontal");
        this.verticalInput = Input.GetAxisRaw("Vertical");
    }

    protected virtual void GetJumpInput()
    {
        this.jumpInput = Input.GetButtonDown("Jump");
    }

    protected virtual void GetInteractInput()
    {
        if (this.playerInteract == null) return;
        if (Input.GetKeyDown(KeyCode.F)) this.playerInteract.OnPlayerInteract();
    }
}
