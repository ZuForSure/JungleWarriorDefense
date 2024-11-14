using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : MyMonoBehaviour
{
    [Header("Base Button")]
    [SerializeField] protected Button button;
    [SerializeField] protected GameObject sceneLoading;
    [SerializeField] protected SliderLoading sliderLoading;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButton();
        this.LoadSceneLoading();
        this.LoadSliderLoading();
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

    protected virtual void LoadSceneLoading()
    {
        if (this.sceneLoading != null) return;
        this.sceneLoading = GameObject.Find("Scene Loading");
        Debug.Log(transform.name + ": LoadSceneLoading", gameObject);
    }

    protected virtual void LoadSliderLoading()
    {
        if (this.sliderLoading != null) return;
        this.sliderLoading = this.sceneLoading.GetComponentInChildren<SliderLoading>();
        Debug.Log(transform.name + ": LoadSliderLoading", gameObject);
    }

    protected virtual void AddOnClickEnvent()
    {
        this.button.onClick.AddListener(this.OnClick);
    }

    protected abstract void OnClick();
}
