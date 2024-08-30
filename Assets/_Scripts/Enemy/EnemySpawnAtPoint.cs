using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnAtPoint : MyMonoBehaviour
{
    [SerializeField] protected SpawnController spawnCtrl;
    [SerializeField] protected int maxEnemies = 5;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnController();
    }

    protected override void Start()
    {
        base.Start();
        this.SpawningAtPoint();
    }

    protected virtual void LoadSpawnController()
    {
        if (this.spawnCtrl != null) return;
        this.spawnCtrl = transform.GetComponent<SpawnController>();
        Debug.Log(transform.name + ": LoadSpawnController", gameObject);
    }

    protected virtual void SpawningAtPoint()
    {
        Vector3 spawnPos = this.spawnCtrl.SpawnPoints.Poitns[0].position;
        Quaternion spawnRot = Quaternion.identity;
        Transform newEnemy = EnemySpawner.Instance.SpawnPrefab(EnemySpawner.Enemy, spawnPos, spawnRot);
        newEnemy.gameObject.SetActive(true);
    }

    
}
