using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpawner : Spawner
{
    public virtual GameObject GetHero()
    {
        GameObject heroObj = this.prefabList[2].gameObject;
        GameObject hero = this.SpawnPrefab(heroObj.transform, Vector3.zero, transform.rotation).gameObject;
        return hero;
    }
}
