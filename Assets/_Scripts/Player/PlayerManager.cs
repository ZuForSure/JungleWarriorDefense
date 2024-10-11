using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MyMonoBehaviour
{
    protected static PlayerManager instance;
    public static PlayerManager Instance => instance;

    [SerializeField] protected HeroSpawner heroSpawner;
    [SerializeField] protected HeroController currentHero;
    public HeroController CurrentHero => currentHero;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHeroComponent();
    }

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 PlayerManager");
        PlayerManager.instance = this;

        //this.LoadPlayer();
    }

    protected override void Start()
    {
        base.Start();
        this.LoadPlayer();
    }

    protected virtual void LoadHeroComponent()
    {
        //Not done
        if (this.heroSpawner != null) return;
        this.heroSpawner = GameObject.Find("Tanker Spawner").GetComponent<HeroSpawner>();
        Debug.Log(transform.name + ": LoadHeroComponent", gameObject);
    }

    protected virtual void LoadPlayer()
    {
        GameObject obj = this.heroSpawner.GetHero();
        obj.SetActive(true);
        this.SetPlayerCtrl(obj);
    }

    public virtual void SetPlayerCtrl(GameObject obj)
    {
        this.currentHero = obj.GetComponent<HeroController>();
    }
}
