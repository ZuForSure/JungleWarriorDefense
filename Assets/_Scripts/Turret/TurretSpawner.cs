using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawner : Spawner
{
    protected static TurretSpawner instance;
    public static TurretSpawner Instance => instance;
    public List<Transform> PrefabsList => prefabList;

    public static string iceTurret = "Ice Turret_1";
    public static string fireTurret = "Fire Turret_1";
    protected string[] turretName = { iceTurret, fireTurret };

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 TurretSpawner");
        TurretSpawner.instance = this;
    }

    public virtual string GetRandomTurretName()
    {
        int rand = this.turretName.Length;
        string randomName = this.turretName[Random.Range(0, rand)];
        return randomName;
    }
}
