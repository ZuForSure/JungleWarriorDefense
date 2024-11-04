using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LayerManager : MyMonoBehaviour
{
    protected static LayerManager instance;
    public static LayerManager Instance => instance;

    private readonly int heroLayer = 8, ceilingLayer = 7, 
        enemyLayer = 6, turretLayer = 9, boundLayer = 11,
        interactLayer = 12, bulletLayer = 10;
    public int HeroLayer => heroLayer;
    public int InteractLayer => interactLayer;
    public int TurretLayer => turretLayer;
    public int BoundLayer => boundLayer;
    public int BulletLayer => bulletLayer;
    public int CeilingLayer => ceilingLayer;
    public int EnemyLayer => enemyLayer;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 LayerManager");
        LayerManager.instance = this;

        Physics2D.IgnoreLayerCollision(this.heroLayer, this.ceilingLayer, true);
        Physics2D.IgnoreLayerCollision(this.heroLayer, this.enemyLayer, true);
        Physics2D.IgnoreLayerCollision(this.heroLayer, this.heroLayer, true);
        Physics2D.IgnoreLayerCollision(this.heroLayer, this.turretLayer, true);
        Physics2D.IgnoreLayerCollision(this.enemyLayer, this.boundLayer, true);
        Physics2D.IgnoreLayerCollision(this.turretLayer, this.bulletLayer, true);
        Physics2D.IgnoreLayerCollision(this.enemyLayer, this.enemyLayer, true);
    }
}

