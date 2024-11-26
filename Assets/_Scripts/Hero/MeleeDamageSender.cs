using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamageSender : DamageSender
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.SendDamageToObject(collision.transform);
    }
}
