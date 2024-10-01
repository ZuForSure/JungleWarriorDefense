using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public virtual void ChangeLayer(int layer)
    {
        gameObject.layer = layer;
    }
}
