using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLocalScale : TurnDirection
{
    protected override void GetHeroDitection()
    {
        if (InputManager.Instance.HorizontalInput == 0) return;
        if (InputManager.Instance.HorizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            return;
        }

        transform.localScale = Vector3.one;
    }
}
