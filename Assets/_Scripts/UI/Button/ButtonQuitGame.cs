using UnityEngine;

public class ButtonQuitGame : BaseButton
{
    protected override void OnClick()
    {
        Application.Quit();
    }
}
