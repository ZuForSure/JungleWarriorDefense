using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MyMonoBehaviour
{
    [Header("Player Interact")]
    [SerializeField] protected bool canInteract;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerManager.Instance.HeroLayer) return;
        this.CheckCanBuild(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerManager.Instance.HeroLayer) return;
        this.CheckCanBuild(false);
    }

    protected virtual void CheckCanBuild(bool status)
    {
        if (this.canInteract == status) return;

        this.canInteract = status;
        InputManager inputManager = InputManager.Instance;
        if (status) inputManager.playerInteract = this;
        else inputManager.playerInteract = null;
    }

    public virtual void OnPlayerInteract() 
    {
        //For override
        Debug.Log("Interact");
    }
}
