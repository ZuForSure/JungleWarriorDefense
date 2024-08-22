using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : DespawnByDis
{
    public override void DespawnObj()
    {
        BulletSpawner.Instance.DespawnToPool(transform.parent);
    }
}
