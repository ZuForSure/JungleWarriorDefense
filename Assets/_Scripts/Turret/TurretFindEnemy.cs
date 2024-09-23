using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFindEnemy : MyMonoBehaviour
{
    public bool isDrawRaycast = false;
    [SerializeField] protected Vector3 raycastDirection = Vector3.right;
    [SerializeField] protected bool isFindEnemy = false;
    public bool IsFindEnemy => isFindEnemy;

    protected override void Update()
    {
        base.Update();
        this.EnemyFinding();
    }
    
    protected virtual void EnemyFinding()
    {
        Vector3 pos = transform.parent.position;
        Physics.Raycast(pos, this.raycastDirection, out RaycastHit hit);
        this.DebugRaycast(pos, this.raycastDirection, hit);

        if (hit.collider == null) 
        {
            this.isFindEnemy = false;
            return;
        }

        DamageReceiver damageReceiver = hit.collider.GetComponent<DamageReceiver>();
        if(damageReceiver == null)
        {
            this.isFindEnemy = false;
            return;
        }
        this.isFindEnemy = true;
    }

    protected virtual void DebugRaycast(Vector3 start, Vector3 direction, RaycastHit hit)
    {
        if (!this.isDrawRaycast) return;

        if(hit.transform == null)
        {
            Debug.DrawRay(start, direction, Color.red);
            Debug.Log(transform.name + ": Hit nothing");
        }
        else
        {
            Debug.DrawLine(start, hit.point, Color.green);
            Debug.Log(transform.name + ": Hit " + hit.transform.name);
        }
    }
}
