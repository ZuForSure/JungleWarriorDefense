using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    protected static FXSpawner instance;
    public static FXSpawner Instance => instance;

    public static string meleeAttack = "Melee Attack";

    protected override void Awake()
    {
        if (instance != null) Debug.LogWarning("Only 1 FXSpawner");
        FXSpawner.instance = this;
    }
}
