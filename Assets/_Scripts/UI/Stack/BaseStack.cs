using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStack : MyMonoBehaviour
{
    [Header("Base Stack")]
    [SerializeField] protected List<Transform> items;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPrefabs();
    }

    protected virtual void LoadPrefabs()
    {
        if (this.items.Count > 0) return;
        foreach (Transform child in transform)
        {
            this.items.Add(child);
        }

        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }
}
