using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTurret : PlayerInteract
{
    [Header("Build")]
    [SerializeField] protected int gold2Build = 10;

    public override void OnPlayerInteract()
    {
        if (!this.IsEnoughGold()) return;
        this.SpawnTurret();
    }

    protected virtual bool IsEnoughGold()
    {
        if (!ScoreManager.Instance.DeductGold(this.gold2Build))
        {
            Debug.Log("NOT ENOUGH GOLD");
            return false;
        }

        return true;
    }

    protected virtual void SpawnTurret()
    {
        Vector3 spawnPos = transform.position;
        Quaternion spawnRot = transform.rotation;
        Transform newTurret = TurretSpawner.Instance.SpawnPrefab(TurretSpawner.turret, spawnPos, spawnRot);
        if (newTurret == null) return;
        newTurret.gameObject.SetActive(true);

        transform.parent.gameObject.SetActive(false);
    }
}
