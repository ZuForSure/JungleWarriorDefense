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

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 PlayerManager");
        PlayerManager.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        this.GetHeroClass();
        this.LoadPlayer();
    }

    protected override void Update()
    {
        base.Update();
        this.ChosePlayer();
    }

    protected virtual void GetHeroClass()
    {
        this.heroSpawner = HeroManager.Instance.GetRandomHeroClass();
        if (this.heroSpawner == null) return;
    }

    protected virtual void LoadPlayer()
    {
        GameObject obj = this.heroSpawner.GetHero(1);
        obj.SetActive(true);
        this.SetPlayerCtrl(obj);
    }

    protected virtual void ChosePlayer()
    {
        int playerIndex = InputManager.Instance.playerIndex;
        if (playerIndex == 0) return;

        if (playerIndex > HeroManager.Instance.Heros.Count) return;

        GameObject hero = HeroManager.Instance.Heros[playerIndex - 1].gameObject;
        this.SetPlayerCtrl(hero);
    }

    public virtual void SetPlayerCtrl(GameObject obj)
    {
        this.currentHero = obj.GetComponent<HeroController>();
    }
}
