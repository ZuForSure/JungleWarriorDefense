using UnityEngine;

public class BuildTurret : PlayerInteract
{
    [Header("Build")]
    [SerializeField] protected int gold2Build = 15;
    public int Gold2Buy => gold2Build;

    public override void OnPlayerInteract()
    {
        if (!this.IsEnoughGold(this.gold2Build)) return;
        this.SpawnTurret();
    }

    protected virtual void SpawnTurret()
    {
        Vector3 spawnPos = transform.position;
        Quaternion spawnRot = transform.rotation;
        Transform newTurret = TurretSpawner.Instance.SpawnPrefab(TurretSpawner.Instance.GetRandomTurretName(), spawnPos, spawnRot);
        if (newTurret == null) return;
        newTurret.gameObject.SetActive(true);

        this.DespawnTurretPoint();
        this.SpawnFX();
        this.SpawnSound();
    }

    protected virtual void DespawnTurretPoint()
    {
        PointTurretSpawner.Instance.DespawnToPool(transform.parent);
    }

    protected virtual void SpawnFX()
    {
        FXSpawner.Instance.SpawnTurretAppearFX(transform.position, transform.rotation);
    }

    protected virtual void SpawnSound()
    {
        AudioManager.Instance.PlaySFX("buy new things");
    }
}
