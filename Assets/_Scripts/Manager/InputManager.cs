using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    protected static InputManager instance;
    public static InputManager Instance => instance;

    [SerializeField] protected float mouseInput;
    public float MouseInput => mouseInput;

    private void Awake()
    {
        if (instance != null) Debug.LogWarning("Only 1 InputManager");
        InputManager.instance = this;
    }

    private void Update()
    {
        this.GetMouseInput();
    }

    protected virtual void GetMouseInput()
    {
        this.mouseInput = Input.GetAxis("Fire1");
    }
}
