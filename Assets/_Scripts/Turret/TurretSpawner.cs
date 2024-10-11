using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawner : Spawner
{
    protected static TurretSpawner instance;
    public static TurretSpawner Instance => instance;

    public static string turret = "Turret";

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 TurretSpawner");
        TurretSpawner.instance = this;
    }
}
