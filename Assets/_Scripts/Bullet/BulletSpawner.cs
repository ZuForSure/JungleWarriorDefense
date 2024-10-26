using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    protected static BulletSpawner instance;
    public static BulletSpawner Instance => instance;

    public static string turretBullet = "Turret Bullet";
    public static string wizardBullet = "Wizard Bullet";

    protected override void Awake()
    {
        if (instance != null) Debug.LogWarning("Only 1 BulletSpawner");
        BulletSpawner.instance = this;  
    }
}
