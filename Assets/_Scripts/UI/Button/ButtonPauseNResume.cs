using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPauseNResume : BaseButton
{
    [Header("Button Pause N Resume")]
    [SerializeField] protected GameObject pauseText;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPauseText();
    }

    protected virtual void LoadPauseText()
    {
        if (this.pauseText != null) return;
        this.pauseText = GameObject.Find("Pause Text UI");
        this.pauseText.SetActive(false);
        Debug.Log(transform.name + ": LoadPauseText", gameObject);
    }

    protected override void OnClick()
    {
        this.ToggleState();
    }

    protected virtual void ToggleState()
    {
        if(Time.timeScale == 1f)
        {
            this.pauseText.SetActive(true);
            Time.timeScale = 0f;
        } 
        else if (Time.timeScale == 0f)
        {
            this.pauseText.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
