using UnityEngine;

public class PlayerInteract : MyMonoBehaviour
{
    [Header("Player Interact")]
    [SerializeField] protected bool canInteract;
    private Transform f_Key;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerManager.Instance.HeroLayer) return;
        HeroController heroCtrl = collision.gameObject.GetComponentInParent<HeroController>();
        if (heroCtrl != PlayerManager.Instance.CurrentHero) return;
        
        this.SpawnUI_F();
    }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerManager.Instance.HeroLayer) return;
        this.CheckCanInteract(true);
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerManager.Instance.HeroLayer) return;
        this.CheckCanInteract(false);
        this.DespawnUI_F();
    }

    protected virtual void SpawnUI_F()
    {
        Vector3 spawnPos = transform.parent.position + new Vector3(0.5f, 0.5f, 0);
        Quaternion spawnRot = transform.rotation;
        this.f_Key = SubObjSpawner.Instance.SpawnPrefab(SubObjSpawner.fKey, spawnPos, spawnRot);
        if (this.f_Key == null) return;
        this.f_Key.gameObject.SetActive(true);
    }

    protected virtual void DespawnUI_F()
    {
        SubObjSpawner.Instance.DespawnToPool(this.f_Key);
    }

    protected virtual void CheckCanInteract(bool status)
    {
        if (this.canInteract == status) return;

        this.canInteract = status;
        InputManager inputManager = InputManager.Instance;
        if (status) inputManager.playerInteract = this;
        else inputManager.playerInteract = null;
    }

    protected virtual bool IsEnoughExp(int exp)
    {
        if (!ScoreManager.Instance.DeductExp(exp)) return false;
        return true;
    }

    protected virtual bool IsEnoughGold(int gold)
    {
        if (!ScoreManager.Instance.DeductGold(gold)) return false;
        return true;
    }

    public virtual void OnPlayerInteract() 
    {
        //For override
        Debug.Log("Interact");
    }
}
