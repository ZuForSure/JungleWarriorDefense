using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDis : Despawn
{
    [Header("Despawn By Distance")]
    [SerializeField] protected Camera mainCam;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected float maxDis = 20f;

    protected override void LoadComponents()
    {
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCam != null) return;
        this.mainCam = GameObject.FindAnyObjectByType<Camera>();
        Debug.Log(transform.name + ": LoadCamera", gameObject);
    }

    protected override bool CanDespawn()
    {
        this.distance = Vector2.Distance(this.mainCam.transform.position, transform.position);
        return this.distance >= this.maxDis;
    }
}
