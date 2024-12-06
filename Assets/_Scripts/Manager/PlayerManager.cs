using UnityEngine;

public class PlayerManager : MyMonoBehaviour
{
    protected static PlayerManager instance;
    public static PlayerManager Instance => instance;

    [SerializeField] protected HeroSpawner heroSpawner;
    [SerializeField] protected HeroController currentHero;
    [SerializeField] protected Transform effectCurrentHero;
    public HeroController CurrentHero => currentHero;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 PlayerManager");
        PlayerManager.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEffect();
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

    protected virtual void LoadEffect()
    {
        if (this.effectCurrentHero != null) return;
        this.effectCurrentHero = GameObject.Find("Current Hero Effect").transform;
        Debug.Log(transform.name + ": LoadEffect", gameObject);
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
        this.SetEffectCurrentHero();
    }

    protected virtual void SetEffectCurrentHero()
    {
        Vector3 pos = this.currentHero.transform.position + new Vector3(0, -0.7f, 0);

        this.effectCurrentHero.gameObject.SetActive(true);
        this.effectCurrentHero.SetPositionAndRotation(pos, Quaternion.identity);
        this.effectCurrentHero.parent = this.currentHero.transform;
    }
}
