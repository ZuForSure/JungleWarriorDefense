using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextWave : BaseText
{
    protected override void FixedUpdate()
    {
        this.UpdateWave();
    }

    protected virtual void UpdateWave()
    {
        int wave = WaveManager.Instance.WaveCount;
        if(wave == 0 || wave > 3) this.text.SetText(" ");
        else this.text.SetText("WAVE: " + wave);
    }
}
