using UnityEngine;

public class UpgradeTurret : PlayerInteract
{
    [Header("Upgrade Turret")]
    [SerializeField] protected TurretController turretCtrl;
    [SerializeField] protected int gold2Upgrade = 100;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTurretController();
    }

    public override void OnPlayerInteract()
    {
        if (this.IsTurretMaxLevel()) return;
        if (!this.IsEnoughGold(this.gold2Upgrade)) return;
        this.UpGradeTurret();
    }

    protected virtual bool IsTurretMaxLevel()
    {
        if (this.turretCtrl.TurretSO.level < 3) return false;
        return true;
    }

    protected virtual void UpGradeTurret()
    {
        this.SpawnTurretLevelUp();
        this.DespawnOldTurret();
        this.SpawnSound();
    }

    protected virtual void SpawnTurretLevelUp()
    {
        Transform levelUpTurret = this.GetTurretLevelUp();
        if (levelUpTurret == null) return;

        Transform newTurret = TurretSpawner.Instance.SpawnPrefab(levelUpTurret.name, transform.parent.position, transform.parent.rotation);
        newTurret.gameObject.SetActive(true);

        this.SpawnFX();
    }

    protected virtual void DespawnOldTurret()
    {
        TurretSpawner.Instance.DespawnToPool(transform.parent);
    }

    protected virtual void SpawnSound()
    {
        AudioManager.Instance.PlaySFX("buy new things");
    }

    protected virtual Transform GetTurretLevelUp()
    {
        //BAD IDEA: MAYBE NEED TO FIX
        foreach (Transform turret in TurretSpawner.Instance.PrefabsList)
        {
            TurretController tCtrl = turret.GetComponent<TurretController>();
            if (tCtrl == null) return null;

            if (tCtrl.TurretSO.turretClass != this.turretCtrl.TurretSO.turretClass) continue;
            if (tCtrl.TurretSO.level <= this.turretCtrl.TurretSO.level) continue;
        
            if(tCtrl.TurretSO.level == this.turretCtrl.TurretSO.level + 1) return turret;
        }

        return null;
    }

    protected virtual void SpawnFX()
    {
        FXSpawner.Instance.SpawnTurretAppearFX(transform.position, transform.rotation);
    }

    protected virtual void LoadTurretController()
    {
        if (this.turretCtrl != null) return;
        this.turretCtrl = transform.GetComponentInParent<TurretController>();
        Debug.Log(transform.name + ": LoadTurretController", gameObject);
    }
}
