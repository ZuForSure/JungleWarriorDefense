using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MyMonoBehaviour
{
    [Header("Spawner")]
    [SerializeField] protected List<Transform> prefabList;
    [SerializeField] protected List<Transform> poolList;
    [SerializeField] protected Transform holder;

    protected override void LoadComponents()
    {
        this.LoadPrefabs();
        this.LoadHolder();
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabList.Count > 0) return;
        Transform prefab = transform.Find("Prefabs");
        foreach (Transform child in prefab)
        {
            this.prefabList.Add(child);
        }
        this.HidePrefab();

        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }

    protected virtual void HidePrefab()
    {
        foreach (Transform prefab in this.prefabList)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + ": LoadHolder", gameObject);
    }

    public virtual Transform SpawnPrefab(string prefabName, Vector3 spawnPos, Quaternion spawnRot)
    {
        Transform newPrefab = this.GetObjByName(prefabName);
        if(newPrefab == null)
        {
            Debug.LogWarning("Prefab not found: ", newPrefab);
            return null;
        }

        return SpawnPrefab(newPrefab, spawnPos, spawnRot);
    }

    protected virtual Transform SpawnPrefab(Transform prefab, Vector3 spawnPos, Quaternion spawnRot)
    {
        Transform newPrefab = this.GetObjFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, spawnRot);
        newPrefab.parent = this.holder;
        return newPrefab;
    }

    protected virtual Transform GetObjByName(string prefabName)
    {
        foreach (Transform child in this.prefabList)
        {
            if (child.name == prefabName) return child;
        }

        return null;
    }

    protected virtual Transform GetObjFromPool(Transform obj)
    {
        foreach (Transform poolObj in this.poolList)
        {
            if(poolObj.name == obj.name)
            {
                this.poolList.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(obj);
        newPrefab.name = obj.name;
        return newPrefab;
    }

    public virtual void DespawnToPool(Transform obj)
    {
        this.poolList.Add(obj);
        obj.gameObject.SetActive(false);
    }
}
