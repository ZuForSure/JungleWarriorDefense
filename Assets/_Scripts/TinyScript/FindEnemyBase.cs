using UnityEngine;

public abstract class FindEnemyBase : MyMonoBehaviour
{
    [Header("Find Enemy Base")]
    public bool isDrawRaycast = false;
    private int heroLayer, turretLayer, bulletLayer, boundLayer, interactLayer;
    private int bitMaskNotHitted;
    [SerializeField] protected float shootingRange = 1f;
    [SerializeField] protected Vector3 raycastDirection = Vector3.right;
    [SerializeField] protected bool isFindEnemy = false;
    public bool IsFindEnemy => isFindEnemy;

    protected override void Update()
    {
        base.Update();
        this.EnemyFinding();
    }

    protected virtual void EnemyFinding()
    {
        this.IgnoreLayer();
        Vector3 pos = transform.position;
        RaycastHit2D hitEnemy = Physics2D.Raycast(pos, this.raycastDirection, this.shootingRange, this.bitMaskNotHitted);

        if (hitEnemy.collider == null)
        {
            this.isFindEnemy = false;
            return;
        }
        this.isFindEnemy = true;

        if (!this.isDrawRaycast) return;
        Debug.DrawLine(pos, new Vector3(pos.x + this.shootingRange, pos.y, 0f), Color.green);
    }

    protected virtual void IgnoreLayer()
    {
        this.GetLayerFromLayerManager();
        this.bitMaskNotHitted = ~((1 << this.heroLayer) | 
            (1 << this.turretLayer) | 
            (1 << this.bulletLayer) | 
            (1 << this.boundLayer) | 
            (1 << this.interactLayer));
    }

    protected virtual void GetLayerFromLayerManager()
    {
        this.heroLayer = LayerManager.Instance.HeroLayer;
        this.interactLayer = LayerManager.Instance.InteractLayer;
        this.turretLayer = LayerManager.Instance.TurretLayer;
        this.bulletLayer = LayerManager.Instance.BulletLayer;
        this.boundLayer = LayerManager.Instance.BoundLayer;
    }
}
