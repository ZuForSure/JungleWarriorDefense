using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamageReceiver : EnemyDamReceiver
{
    protected override void OnDead()
    {
        GameManager.Instance.VictoryGame();
        base.OnDead();
    }
}
