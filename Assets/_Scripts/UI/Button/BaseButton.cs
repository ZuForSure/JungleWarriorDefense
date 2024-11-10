using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : MyMonoBehaviour
{
    [Header("Base Button")]
    [SerializeField] protected Button button;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButton();
    }

    protected override void Start()
    {
        base.Start();
        this.AddOnClickEnvent();
    }

    protected virtual void LoadButton()
    {
        if (this.button != null) return;
        this.button = GetComponent<Button>();
        Debug.Log(transform.name + ": LoadButton", gameObject);
    }

    protected virtual void AddOnClickEnvent()
    {
        this.button.onClick.AddListener(this.OnClick);
    }

    protected abstract void OnClick();
}
