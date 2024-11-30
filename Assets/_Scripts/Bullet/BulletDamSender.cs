using UnityEngine;

public class BulletDamSender : DamageSender
{
    [Header("Bullet Dam Sender")]
    [SerializeField] protected BulletController bulletCtrl;
    public float bulletDamage;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.damage = this.bulletDamage;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletController();
    }

    protected virtual void LoadBulletController()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.GetComponentInParent<BulletController>();
        Debug.Log(transform.name + ": LoadBulletController", gameObject);
    }

    protected override void SendDamage(DamageReceiver damageReceiver)
    {
        base.SendDamage(damageReceiver);
        this.DespawnBullet();
        this.SpawnFX();
        this.SpawnSound();
    }

    protected virtual void DespawnBullet()
    {
        if (this.bulletCtrl.BulletDespawn == null) return;
        this.bulletCtrl.BulletDespawn.DespawnObj();
    }

    protected virtual void SpawnFX()
    {
        Vector3 spawnPos = transform.position;
        Quaternion spawnRot = transform.rotation;
        Transform newFX = FXSpawner.Instance.SpawnPrefab(transform.parent.name + " FX", spawnPos, spawnRot);
        if (newFX == null) return;
        newFX.gameObject.SetActive(true);
    }

    protected virtual void SpawnSound()
    {
        AudioManager.Instance.PlaySFX(transform.parent.name);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.DespawnBullet();
            this.SpawnFX();
            this.SpawnSound();
            return;
        }

        if (collision.transform.parent == this.bulletCtrl.Shooter) return;

        this.SendDamageToObject(collision.transform);
    }
}
