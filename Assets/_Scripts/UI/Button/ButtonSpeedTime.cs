using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpeedTime : BaseButton
{
    protected override void OnClick()
    {
        this.ToggleSpeedTime();
    }

    protected virtual void ToggleSpeedTime()
    {
        if (Time.timeScale == 0f) return;

        if(Time.timeScale == 1f)
        {
            Time.timeScale = 1.5f;
        } 
        else if(Time.timeScale == 1.5f)
        {
            Time.timeScale = 1f;
        }
    }
}
