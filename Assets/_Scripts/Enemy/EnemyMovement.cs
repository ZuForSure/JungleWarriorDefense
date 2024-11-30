using System.Collections;
using UnityEngine;

public class EnemyMovement : EnemyAbstract
{
    [Header("Enemy Movement")]
    public Transform target;
    public float baseSpeed;
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
        this.baseSpeed = this.enemyCtrl.EnemySO.speed;
        this.moveSpeed = this.enemyCtrl.EnemySO.speed;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetSpeed();
    }

    protected override void Update()
    {
        base.Update();
        this.UpdateMoveSpeed();
        this.Moving();
    }

    protected virtual void LoadTarget()
    {
        if (this.target != null) return;
        this.target = GameObject.Find("Target Points").transform;
        Debug.Log(transform.name + "LoadTarget", gameObject);
    }

    protected virtual void UpdateMoveSpeed()
    {
        if (this.moveSpeed >= this.baseSpeed) return;
        StartCoroutine(this.ResetSlowSpeed());
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
        if (transform.parent.position.x == this.target.position.x) this.moveDirection.x = 0;

        return this.moveDirection;
    }

    protected IEnumerator ResetSlowSpeed()
    {
        yield return new WaitForSeconds(1f);
        this.ResetSpeed();
    }

    public virtual void UpdateSpeed(float newSpeed)
    {
        this.moveSpeed = newSpeed;
    }

    public virtual void ResetSpeed()
    {
        this.moveSpeed = this.baseSpeed;
    }
}
