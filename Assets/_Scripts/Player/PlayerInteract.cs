using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MyMonoBehaviour
{
    [Header("Player Interact")]
    [SerializeField] protected bool canInteract;

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerManager.Instance.HeroLayer) return;
        this.CheckCanInteract(true);
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerManager.Instance.HeroLayer) return;
        this.CheckCanInteract(false);
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
        if (!ScoreManager.Instance.DeductExp(exp))
        {
            Debug.Log("NOT ENOUGH EXP");
            return false;
        }

        return true;
    }

    public virtual void OnPlayerInteract() 
    {
        //For override
        Debug.Log("Interact");
    }
}
