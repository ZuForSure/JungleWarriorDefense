using UnityEngine;

public class TurretShooting : TurretAbstract
{
    [Header("Turret Shooting")]
    [SerializeField] protected Transform bulletSpawnPoint;
    [SerializeField] protected bool canShoot = false;
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float delay = 1f;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.delay = this.turretCtrl.TurretSO.turretAttackSpeed;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoint();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Shooting();
    }

    protected virtual void LoadSpawnPoint()
    {
        if (this.bulletSpawnPoint != null) return;
        this.bulletSpawnPoint = transform.Find("Bullet Spawn Point");
        Debug.Log(transform.name + ": LoadSpawnPoint", gameObject);
    }

    protected virtual void Shooting()
    {
        if (!this.CheckCanShoot()) return;

        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delay) return;
        this.timer = 0f;

        Vector3 spawnPos = this.bulletSpawnPoint.transform.position;
        Transform newBullet = BulletSpawner.Instance.SpawnPrefab(this.GetBulletName(), spawnPos, Quaternion.identity);
        if (newBullet == null) return;

        this.SetBulletDamage(newBullet);
        newBullet.gameObject.SetActive(true);
        this.SpawnSound();
    }

    protected virtual bool CheckCanShoot()
    {
        this.canShoot = this.turretCtrl.TurretFindEne.IsFindEnemy;
        return this.canShoot;
    }

    protected virtual void SpawnSound()
    {
        string soundName = transform.parent.name.Remove(transform.parent.name.Length - 2);
        AudioManager.Instance.PlaySFX(soundName);
    }

    protected virtual string GetBulletName()
    {
        string turretName = transform.parent.name;
        string bulletName = turretName[..^2] + " Bullet";
        return bulletName;
    }

    protected virtual void SetBulletDamage(Transform bullet)
    {
        BulletController bulletCtrl = bullet.GetComponent<BulletController>();
        if (bulletCtrl == null) return;

        bulletCtrl.bulletDamSender.bulletDamage = this.turretCtrl.TurretSO.turretDamage;
    }
}
