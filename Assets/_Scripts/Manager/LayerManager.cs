using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LayerManager : MyMonoBehaviour
{
    private readonly int heroLayer = 8, ceilingLayer = 7, enemyLayer = 6, turretLayer = 9, boundLayer = 11;

    protected override void Awake()
    {
        base.Awake();
        Physics2D.IgnoreLayerCollision(this.heroLayer, this.ceilingLayer, true);
        Physics2D.IgnoreLayerCollision(this.heroLayer, this.enemyLayer, true);
        Physics2D.IgnoreLayerCollision(this.heroLayer, this.heroLayer, true);
        Physics2D.IgnoreLayerCollision(this.heroLayer, this.turretLayer, true);
        Physics2D.IgnoreLayerCollision(this.enemyLayer, this.boundLayer, true);
    }
}

