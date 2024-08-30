using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MyMonoBehaviour
{
    [SerializeField] protected SpawnPoints spawnPoints;
    [SerializeField] protected EnemySpawner enemySpawner;
    public SpawnPoints SpawnPoints => spawnPoints;
    public EnemySpawner EnemySpawner => enemySpawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoints();
        this.LoadEnemySpawner();
    }

    protected virtual void LoadSpawnPoints()
    {
        if (this.spawnPoints != null) return;
        this.spawnPoints = transform.Find("Spawn Points").GetComponent<SpawnPoints>();
        Debug.Log(transform.name + ": LoadSpawnPoints", gameObject);
    }

    protected virtual void LoadEnemySpawner()
    {
        if (this.enemySpawner != null) return;
        this.enemySpawner = transform.GetComponent<EnemySpawner>();
        Debug.Log(transform.name + ": LoadEnemySpawner", gameObject);
    }
}
