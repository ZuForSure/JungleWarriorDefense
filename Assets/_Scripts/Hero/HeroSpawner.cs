using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpawner : Spawner
{
    public virtual GameObject GetHero(int heroLevel)
    {
        GameObject heroObj = this.prefabList[heroLevel - 1].gameObject;
        GameObject hero = this.SpawnPrefab(heroObj.transform, Vector3.zero, transform.rotation).gameObject;
        return hero;
    }
}
