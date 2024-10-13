using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManager : MyMonoBehaviour
{
    protected static HeroManager instance;
    public static HeroManager Instance => instance;

    [SerializeField] protected List<HeroSpawner> heros;
    public List<HeroSpawner> Heros => heros;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 HeroSpawner");
        HeroManager.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHeroSpawner();
    }

    protected virtual void LoadHeroSpawner()
    {
        if (this.heros.Count > 0) return;
        foreach(Transform hero in transform)
        {
            HeroSpawner heroSpawn = hero.GetComponent<HeroSpawner>();
            this.heros.Add(heroSpawn);
        }

        Debug.Log(transform.name + ": LoadHeroSpawner", gameObject);
    }
}
