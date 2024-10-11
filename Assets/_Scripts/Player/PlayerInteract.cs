using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MyMonoBehaviour
{
    public virtual void OnPlayerInteract() 
    {
        Debug.Log("Interact");
    }
}
