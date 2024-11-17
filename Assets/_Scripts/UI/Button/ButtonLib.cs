using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLib : BaseButton
{
    [Header("Open Lib")]
    [SerializeField] protected GameObject libScene;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLibScene();
    }

    protected virtual void LoadLibScene()
    {
        if (this.libScene != null) return;
        this.libScene = GameObject.Find("Library Scene");
        this.libScene.SetActive(false);
        Debug.Log(transform.name + ": LoadLibScene", gameObject);
    }

    protected override void OnClick()
    {
        this.libScene?.SetActive(true);
    }
}
