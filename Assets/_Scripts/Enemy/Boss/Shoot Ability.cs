using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAbility : MyMonoBehaviour
{
    [SerializeField] protected float lineOfsite;



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, this.lineOfsite);
    }
}
