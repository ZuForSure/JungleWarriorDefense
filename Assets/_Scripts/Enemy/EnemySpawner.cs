using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    protected static EnemySpawner instance;
    public static EnemySpawner Instance => instance;

    protected override void Awake()
    {
        if (instance != null) Debug.LogWarning("Only 1 EnemySpawner");
        EnemySpawner.instance = this;  
    }
}
