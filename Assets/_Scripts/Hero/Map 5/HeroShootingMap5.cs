using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroShootingMap5 : HeroShooting
{
    [Header("Hero Shooting Map 5")]
    public int mana = 4;
    public int maxMana = 4;

    protected override void SpawnBullet()
    {
        if (this.mana <= 0) return;
        this.mana -= 1;

        base.SpawnBullet();
    }
}
