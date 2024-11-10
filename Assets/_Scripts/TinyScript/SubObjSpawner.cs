using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubObjSpawner : Spawner
{
    protected static SubObjSpawner instance;
    public static SubObjSpawner Instance => instance;

    public static string fKey = "F Key";

    protected override void Awake()
    {
        if (instance != null) Debug.LogWarning("Only 1 SubObjSpawner");
        SubObjSpawner.instance = this;
    }
}
