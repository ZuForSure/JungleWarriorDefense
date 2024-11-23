using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    protected static EnemySpawner instance;
    public static EnemySpawner Instance => instance;

    [Header("EnemySpawner")]
    [SerializeField] protected SpawnController spawnController;
    //[SerializeField] protected int spawnCount = 0;

    public static string Enemy = "FlyEnemy";

    protected override void Awake()
    {
        if (instance != null) Debug.LogWarning("Only 1 EnemySpawner");
        EnemySpawner.instance = this;  
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnCtrl();
    }

    protected virtual void LoadSpawnCtrl()
    {
        if (this.spawnController != null) return;
        this.spawnController = transform.GetComponent<SpawnController>();
        Debug.Log(transform.name + ": LoadSpawnController", gameObject);
    }

    public virtual void SpawnEnemyAtRandomPoint()
    {
        Transform randPoint = this.spawnController.SpawnPoints.GetRandomPoint();
        Vector3 spawnPos = randPoint.position;
        Quaternion spawnRot = Quaternion.identity;

        Transform newEnemy = this.SpawnPrefab(this.GetRandomEnemy(), spawnPos, spawnRot);
        newEnemy.gameObject.SetActive(true);
    }

    public virtual Transform GetRandomEnemy()
    {
        int rand = Random.Range(0, this.prefabList.Count);
        return this.prefabList[rand];
    }
}
