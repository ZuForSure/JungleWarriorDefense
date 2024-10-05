using UnityEngine;

public class EnemyMovement : EnemyAbstract
{
    [Header("Enemy Movement")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected Vector3 moveDirection;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTarget();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = this.enemyCtrl.EnemySO.speed;
    }

    protected override void Update()
    {
        base.Update();
        this.Moving();
    }

    protected virtual void LoadTarget()
    {
        if (this.target != null) return;
        this.target = GameObject.Find("Target Points").transform;
        Debug.Log(transform.name + "LoadTarget", gameObject);
    }

    protected virtual void Moving()
    {
        if (this.target == null) return;

        Vector3 direction = this.GetDirection() * Time.deltaTime * this.moveSpeed;
        this.enemyCtrl.E_rb.MovePosition(transform.parent.position + direction);
    }

    protected virtual Vector3 GetDirection()
    {
        if (transform.parent.position.x > this.target.position.x) this.moveDirection.x = -1;
        if (transform.parent.position.x < this.target.position.x) this.moveDirection.x = 1;
        
        return this.moveDirection;
    }
}
