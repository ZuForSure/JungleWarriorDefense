using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTurretSpawner : Spawner
{
    protected static PointTurretSpawner instance;
    public static PointTurretSpawner Instance => instance;

    public static string pointTurret = "Turret Point";

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 PointTurretSpawner");
        PointTurretSpawner.instance = this;
    }
}
