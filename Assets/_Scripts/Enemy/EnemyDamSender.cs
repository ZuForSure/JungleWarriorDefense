using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamSender : DamageSender
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.SendDamageToObject(collision.transform);
    }
}
