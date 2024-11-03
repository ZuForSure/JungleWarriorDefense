using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    protected static FXSpawner instance;
    public static FXSpawner Instance => instance;

    public static string turretAppear = "Turret Appear FX";

    protected override void Awake()
    {
        if (instance != null) Debug.LogWarning("Only 1 FXSpawner");
        FXSpawner.instance = this;
    }

    public virtual void SpawnTurretAppearFX(Vector3 spawnPos, Quaternion spawnRot)
    {
        Transform turretAppearFX = this.SpawnPrefab(turretAppear, spawnPos, spawnRot);
        if (turretAppearFX == null) return;
        turretAppearFX.gameObject.SetActive(true);
    }
}
