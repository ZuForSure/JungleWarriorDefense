using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTurret : PlayerInteract
{
    [Header("Build")]
    [SerializeField] protected int gold2Build = 10;

    public override void OnPlayerInteract()
    {
        if (!this.IsEnoughGold(this.gold2Build)) return;
        this.SpawnTurret();
    }

    protected virtual void SpawnTurret()
    {
        Vector3 spawnPos = transform.position;
        Quaternion spawnRot = transform.rotation;
        Transform newTurret = TurretSpawner.Instance.SpawnPrefab(TurretSpawner.Instance.GetRandomTurretName(), spawnPos, spawnRot);
        if (newTurret == null) return;
        newTurret.gameObject.SetActive(true);

        this.DespawnTurretPoint();
        this.SpawnFX();
    }

    protected virtual void DespawnTurretPoint()
    {
        PointTurretSpawner.Instance.DespawnToPool(transform.parent);
    }

    protected virtual void SpawnFX()
    {
        FXSpawner.Instance.SpawnTurretAppearFX(transform.position, transform.rotation);
    }
}
