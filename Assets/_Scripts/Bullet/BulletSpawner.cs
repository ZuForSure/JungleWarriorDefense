using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    protected static BulletSpawner instance;
    public static BulletSpawner Instance => instance;

    public static string bullet = "Normal Bullet";
    public static string blueBullet = "Blue Bullet";
    public static string meleeAttack = "Melee Attack";

    protected override void Awake()
    {
        if (instance != null) Debug.LogWarning("Only 1 BullerSpawner");
        BulletSpawner.instance = this;  
    }
}
