using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpawner : Spawner
{
    [SerializeField] protected Transform spawnPos;

    public virtual GameObject GetHero(int heroLevel)
    {
        GameObject heroObj = this.prefabList[heroLevel - 1].gameObject;
        GameObject hero = this.SpawnPrefab(heroObj.transform, this.spawnPos.position, transform.rotation).gameObject;

        HeroManager.Instance.Heros.Add(hero.transform);

        return hero;
    }
}
