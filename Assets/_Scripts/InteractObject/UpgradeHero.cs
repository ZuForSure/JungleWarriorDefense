using UnityEngine;

public class UpgradeHero : PlayerInteract
{
    [Header("Upgrade Hero")]
    [SerializeField] protected HeroController heroCtrl;
    [SerializeField] protected int exp2Upgrade = 200;
    public int Exp2Upgrade => exp2Upgrade;

    protected override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
        this.heroCtrl = collision.GetComponentInParent<HeroController>();
        if (this.heroCtrl == null) return;
    }

    public override void OnPlayerInteract()
    {
        if (this.IsMaxLevel()) return;
        if (!this.IsEnoughExp(this.exp2Upgrade)) return;
        this.UpGrade();
    }

    protected virtual bool IsMaxLevel()
    {
        if (this.heroCtrl.HeroSO.level < 3) return false;
        return true;
    }

    protected virtual void UpGrade()
    {
        this.SpawnLevelUpHero();
        this.DespawnOldHero();
        this.SpawnSound();
    }

    protected virtual void SpawnLevelUpHero()
    {
        HeroSpawner currentHeroClass = this.heroCtrl.transform.parent.parent.GetComponent<HeroSpawner>();
        if (currentHeroClass == null) return;

        GameObject newHero = currentHeroClass.GetHero(this.heroCtrl.HeroSO.level + 1);
        newHero.SetActive(true);

        this.SetPlayerIndex(newHero);
    }

    protected virtual void DespawnOldHero()
    {
        HeroManager.Instance.Heros.Remove(this.heroCtrl.transform);
        this.heroCtrl.gameObject.SetActive(false);
        this.heroCtrl = null;
    }

    protected virtual void SetPlayerIndex(GameObject hero)
    {
        int index = HeroManager.Instance.Heros.IndexOf(hero.transform);
        InputManager.Instance.playerIndex = index;
    }

    protected virtual void SpawnSound()
    {
        AudioManager.Instance.PlaySFX("buy new things");
    }
}
