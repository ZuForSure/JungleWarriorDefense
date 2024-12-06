using UnityEngine;

public class StackHP : BaseStack
{
    [Header("Stack HP")]
    [SerializeField] protected HouseDamReceiver house;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHouseDamReceiver();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.UpdateHpStack();
    }

    protected virtual void LoadHouseDamReceiver()
    {
        if (this.house != null) return;
        this.house = GameObject.Find("House").GetComponentInChildren<HouseDamReceiver>();
        Debug.Log(transform.name + ": LoadHouseDamReceiver", gameObject);
    }

    protected virtual void UpdateHpStack()
    {
        //BAD IDEA: JUST DEDUCT HP IS WORK, ADD HP WON'T WORK
        if (this.items.Count == (int)this.house.HP) return;

        this.items[0].gameObject.SetActive(false);
        this.items.Remove(items[0]);
    }
}
