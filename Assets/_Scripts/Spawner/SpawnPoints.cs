using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MyMonoBehaviour
{
    [SerializeField] protected List<Transform> points;
    public List<Transform> Poitns => points;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoints();
    }

    protected virtual void LoadSpawnPoints()
    {
        if (this.points.Count > 0) return;
        foreach(Transform point in transform)
        {
            this.points.Add(point);
        }

        Debug.Log(transform.name + ": LoadSpawnPoints", gameObject);
    }

    public virtual Transform GetRandomPoint()
    {
        int rand = Random.Range(0, this.points.Count);
        return this.points[rand];
    }
}
