using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnDirection : HeroAbstract
{
    protected override void Update()
    {
        base.Update();
        if (!this.CheckIsCurrentHero()) return;

        this.GetHeroDitection();
    }

    protected virtual void GetHeroDitection()
    {
        if (InputManager.Instance.HorizontalInput == 0) return;
        if (InputManager.Instance.HorizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180f);
            return;
        }

        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
