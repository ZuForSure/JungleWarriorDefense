using System.Collections.Generic;
using UnityEngine;

public class HeroManager : MyMonoBehaviour
{
    protected static HeroManager instance;
    public static HeroManager Instance => instance;

    [SerializeField] protected List<HeroSpawner> heroClasses;
    [SerializeField] protected List<Transform> heros;
    public List<HeroSpawner> HerosClasses => heroClasses;
    public List<Transform> Heros => heros;

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
        if (this.heroClasses.Count > 0) return;
        foreach(Transform hero in transform)
        {
            HeroSpawner heroSpawn = hero.GetComponent<HeroSpawner>();
            this.heroClasses.Add(heroSpawn);
        }

        Debug.Log(transform.name + ": LoadHeroSpawner", gameObject);
    }

    public virtual HeroSpawner GetRandomHeroClass()
    {
        int rand = Random.Range(0, this.heroClasses.Count);
        HeroSpawner randomHero = this.heroClasses[rand];
        this.heroClasses.Remove(this.heroClasses[rand]);
        return randomHero;
    }
}
