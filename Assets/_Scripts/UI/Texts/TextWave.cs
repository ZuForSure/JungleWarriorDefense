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
        if (wave == 0 || wave > WaveManager.Instance.FinalWave) this.text.SetText(" ");
        else if (wave == WaveManager.Instance.FinalWave)
        {
            this.text.SetText("FINAL");
            this.text.color = Color.red;
        }
        else this.text.SetText("WAVE: " + wave);
    }
}
