using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WaveAbstract : MyMonoBehaviour
{
    [Header("Wave Abstract")]
    [SerializeField] protected WaveController waveController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWaveCtrl();
    }

    protected virtual void LoadWaveCtrl()
    {
        if (this.waveController != null) return;
        this.waveController = transform.GetComponentInParent<WaveController>();
        Debug.Log(transform.name + ": LoadWaveCtrl", gameObject);
    }
}
