using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    protected static FXSpawner instance;
    public static FXSpawner Instance => instance;

    public static string turretAppear = "Turret Appear FX";
    public static string turretDisAppear = "Turret Dissappear FX";
    public static string enemyDead = "Enemy Dead FX";
    public static string meleeFX = "Melee Attack FX";
    public static string loseGameFX = "Lose Game FX";
    public static string boomRain = "Boom Boss Bullet FX";
    public static string frozen = "Frozen FX";

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

    public virtual void SpawnLoseFX(Vector3 spawnPos, Quaternion spawnRot)
    {
        Transform loseGame = this.SpawnPrefab(loseGameFX, spawnPos, spawnRot);
        if (loseGame == null) return;
        loseGame.gameObject.SetActive(true);
    }
}
