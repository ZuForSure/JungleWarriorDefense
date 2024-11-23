using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamageSender : DamageSender
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerManager.Instance.EnemyLayer) return;
        this.SendDamageToObject(collision.transform);
    }
}
