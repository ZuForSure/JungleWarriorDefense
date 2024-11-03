using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackDespawn : DespawnByTime
{
    public override void DespawnObj()
    {
        BulletSpawner.Instance.DespawnToPool(transform.parent);
    }
}
