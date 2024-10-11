using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void Start()
    {
        //for override
    }

    protected virtual void Update()
    {
        //for override
    }

    protected virtual void OnEnable()
    {
        //for override
    }

    protected virtual void FixedUpdate()
    {
        //for override
    }

    protected virtual void LoadComponents()
    {
        //for override
    }

    protected virtual void ResetValue()
    {
        //for override
    }
}
