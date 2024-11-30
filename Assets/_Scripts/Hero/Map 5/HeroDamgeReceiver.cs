using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDamgeReceiver : DamageReceiver
{
    protected override void OnDead()
    {
        GameManager.Instance.GameOver();
    }
}
