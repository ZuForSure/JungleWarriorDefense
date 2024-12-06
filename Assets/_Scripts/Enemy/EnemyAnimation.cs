using UnityEngine;

public class EnemyAnimation : EnemyAbstract
{
    [Header("Enemy Animation")]
    [SerializeField] protected Animator animator;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    public virtual void AttackAnimation()
    {
        this.animator.SetTrigger("attack");
        this.Backing();
    }

    protected virtual void Backing()
    {
        Vector3 posX = transform.parent.position;
        posX.x += 0.2f;
        transform.parent.position = posX;
    }
}
