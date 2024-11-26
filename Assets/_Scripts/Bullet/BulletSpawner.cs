using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    protected static BulletSpawner instance;
    public static BulletSpawner Instance => instance;

    public static string iceTurretBullet = "Ice Turret Bullet";
    public static string fireTurretBullet = "Fire Turret Bullet";
    public static string wizardBullet = "Wizard Bullet";
    public static string meleeAttack = "Melee Attack";

    public static string bossBullet = "Boss Bullet";
    public static string boomRain = "Boom Boss Bullet";

    protected override void Awake()
    {
        if (instance != null) Debug.LogWarning("Only 1 BulletSpawner");
        BulletSpawner.instance = this;  
    }
}
