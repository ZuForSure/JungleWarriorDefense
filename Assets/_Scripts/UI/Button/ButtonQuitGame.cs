using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonQuitGame : BaseButton
{
    protected override void OnClick()
    {
        Application.Quit();
    }
}
