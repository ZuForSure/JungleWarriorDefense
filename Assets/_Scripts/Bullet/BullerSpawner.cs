using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullerSpawner : Spawner
{
    protected static BullerSpawner instance;
    public static BullerSpawner Instance => instance;

    protected override void Awake()
    {
        if (instance != null) Debug.LogWarning("Only 1 BullerSpawner");
        BullerSpawner.instance = this;  
    }
}
