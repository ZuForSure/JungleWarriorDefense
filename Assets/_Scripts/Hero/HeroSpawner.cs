using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpawner : Spawner
{
    [SerializeField] protected Transform spawnPos;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPos();
    }

    protected virtual void LoadSpawnPos()
    {
        if (this.spawnPos != null) return;
        this.spawnPos = GameObject.Find("Hero Buy Point").transform;
        Debug.Log(transform.name + ": LoadSpawnPos", gameObject);
    }

    public virtual GameObject GetHero(int heroLevel)
    {
        GameObject heroObj = this.prefabList[heroLevel - 1].gameObject;
        GameObject hero = this.SpawnPrefab(heroObj.transform, this.spawnPos.position, transform.rotation).gameObject;

        HeroManager.Instance.Heros.Add(hero.transform);

        return hero;
    }
}
