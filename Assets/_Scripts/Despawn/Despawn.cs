public abstract class Despawn : MyMonoBehaviour
{
    protected override void FixedUpdate()
    {
        this.Despawning();
    }

    protected virtual void Despawning()
    {
        if (!this.CanDespawn()) return;
        this.DespawnObj();
    }

    public virtual void DespawnObj()
    {
        //for override
    }

    protected abstract bool CanDespawn();
}
