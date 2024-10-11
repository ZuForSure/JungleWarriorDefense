using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildAble : PlayerInteract
{
    [SerializeField] protected int gold2Build = 10;
    [SerializeField] protected bool canBuild;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerManager.Instance.HeroLayer) return;
        this.CheckCanBuild(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerManager.Instance.HeroLayer) return;
        this.CheckCanBuild(false);
    }

    protected virtual void CheckCanBuild(bool status)
    {
        if (this.canBuild == status) return;

        this.canBuild = status;
        InputManager inputManager = InputManager.Instance;
        if (status) inputManager.playerInteract = this;
        else inputManager.playerInteract = null;

    }

    public override void OnPlayerInteract()
    {
        if (!this.IsEnoughGold()) return;
        this.SpawnTurret();
    }

    protected virtual bool IsEnoughGold()
    {
        if (!ScoreManager.Instance.DeductGold(this.gold2Build))
        {
            Debug.Log("NOT ENOUGH GOLD");
            return false;
        }

        return true;
    }

    protected virtual void SpawnTurret()
    {
        Vector3 spawnPos = transform.position;
        Quaternion spawnRot = transform.rotation;
        Transform newTurret = TurretSpawner.Instance.SpawnPrefab(TurretSpawner.turret, spawnPos, spawnRot);
        if (newTurret == null) return;
        newTurret.gameObject.SetActive(true);

        transform.parent.gameObject.SetActive(false);
    }
}
