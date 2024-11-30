using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamageSender : DamageSender
{
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Boss") || collision.gameObject.CompareTag("Player"))
        {
            this.SendDamageToObject(collision.transform);
            this.SpawnFX(collision);
        }
    }

    protected virtual void SpawnFX(Collider2D collision)
    {
        Vector3 spawnPos = collision.transform.position;
        Quaternion spawnRot = collision.transform.rotation;
        Transform meleeFX = FXSpawner.Instance.SpawnPrefab(FXSpawner.meleeFX, spawnPos, spawnRot);
        if (meleeFX == null) return;
        meleeFX.gameObject.SetActive(true);
    }
}
