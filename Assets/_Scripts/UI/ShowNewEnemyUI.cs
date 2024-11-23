using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNewEnemyUI : MyMonoBehaviour
{
    protected override void Update()
    {
        base.Update();
        this.UpdateUI();
    }

    protected virtual void UpdateUI()
    {
        if (!WaveManager.Instance.isStartWave) return;
        transform.gameObject.SetActive(false);
    }
}
