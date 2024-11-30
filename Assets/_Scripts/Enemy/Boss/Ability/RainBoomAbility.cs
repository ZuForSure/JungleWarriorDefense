using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainBoomAbility : BossAbilityAbstract
{
    [Header("Rain Boom Ability")]
    [SerializeField] protected List<Transform> spawnBoomPoints;
    [SerializeField] protected float timeBtwSpawn = 15f;
    [SerializeField] protected float timeBtwBoom = 1f;
    [SerializeField] protected float damage = 3f;
    [SerializeField] protected int numOfBoom = 10;
    [SerializeField] protected bool isSpawnDone = true;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnBoomPoints();
    }

    protected override void Update()
    {
        base.Update();
        if (!this.isSpawnDone) return;
        
        this.SpawnRainBoom();
    }

    protected virtual void LoadSpawnBoomPoints()
    {
        if (this.spawnBoomPoints.Count > 0) return;
        Transform pointsList = GameObject.Find("Spawn Boom Points").transform;
        foreach (Transform point in pointsList) 
        {
            this.spawnBoomPoints.Add(point);
        }

        Debug.Log(transform.name + ": LoadSpawnBoomPoints", gameObject);
    }

    protected virtual void SpawnRainBoom()
    {
        if (!this.CheckPlayerPos()) return;
        StartCoroutine(this.SpawingDelay());
    }

    protected virtual bool CheckPlayerPos()
    {
        if (this.bossAbilityCtrl.ShootAbility.player == null) return false;
        bool isPlayerHigerThanBoss = this.bossAbilityCtrl.ShootAbility.player.position.y > this.transform.parent.position.y + 3;
        return isPlayerHigerThanBoss;
    }

    protected IEnumerator SpawingDelay()
    {
        this.isSpawnDone = false;

        StartCoroutine(this.BoomDelay());
        yield return new WaitForSeconds(this.timeBtwSpawn);

        this.isSpawnDone = true;
    }

    protected IEnumerator BoomDelay()
    {
        for (int i = 0; i < this.numOfBoom; i++)
        {
            Vector3 spawnPos = this.GetRandomPoint().position;
            Transform boom = BulletSpawner.Instance.SpawnPrefab(BulletSpawner.boomRain, spawnPos, Quaternion.identity);
            if (boom == null) yield return null;

            BulletController bulletCtrl = boom.GetComponent<BulletController>();
            bulletCtrl.bulletDamSender.bulletDamage = this.damage;
            bulletCtrl.SetShooter(transform.parent);
            boom.gameObject.SetActive(true);

            yield return new WaitForSeconds(this.timeBtwBoom);
        }
    }

    protected virtual Transform GetRandomPoint()
    {
        int rand = Random.Range(0, this.spawnBoomPoints.Count);
        return this.spawnBoomPoints[rand];
    }
}
