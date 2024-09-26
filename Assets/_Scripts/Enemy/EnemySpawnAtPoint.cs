using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnAtPoint : MyMonoBehaviour
{
    [SerializeField] protected SpawnController spawnCtrl;
    [SerializeField] protected int maxEnemies = 5;
    [SerializeField] protected float startSpawn = 1f;
    [SerializeField] protected float delaySpawn = 3f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnController();
    }

    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(SpawningAtPoint), this.startSpawn, this.delaySpawn);
    }

    protected virtual void LoadSpawnController()
    {
        if (this.spawnCtrl != null) return;
        this.spawnCtrl = transform.GetComponent<SpawnController>();
        Debug.Log(transform.name + ": LoadSpawnController", gameObject);
    }

    protected virtual void SpawningAtPoint()
    {
        Transform randPoint = this.spawnCtrl.SpawnPoints.GetRandomPoint();
        Vector3 spawnPos = randPoint.position;
        Quaternion spawnRot = Quaternion.identity;

        Transform newEnemy = EnemySpawner.Instance.SpawnPrefab(EnemySpawner.Enemy, spawnPos, spawnRot);
        newEnemy.gameObject.SetActive(true);
    }
}
