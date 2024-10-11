using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TurretBuild : PlayerInteract
{
    [SerializeField] protected Collider2D colli2D;
    [SerializeField] protected bool canBuild;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadColli2D();
    }

    protected virtual void LoadColli2D()
    {
        if (this.colli2D != null) return;
        this.colli2D = transform.GetComponent<Collider2D>();
        Debug.Log(transform.name + ": LoadColli2D", gameObject);
    }

    public override void OnPlayerInteract()
    {

    }
}