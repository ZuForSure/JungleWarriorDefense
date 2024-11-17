using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderWaveTimer : BaseSlider
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.SetSliderValueToTimePerWave();
    }

    protected virtual void SetSliderValueToTimePerWave()
    {
        if (WaveManager.Instance.waveTimer == 0) return;
        if (WaveManager.Instance.WaveCount >= WaveManager.Instance.FinalWave)
        {
            transform.gameObject.SetActive(false);
        }

        float waveTimePerCent = Time.fixedDeltaTime / WaveManager.Instance.totalTimePerWave;
        this.progress = Mathf.MoveTowards(this.progress, 1, waveTimePerCent);
        this.slider.value = this.progress;
    }

    protected override void OnChange(float newValue)
    {
        if(this.slider.value < 1) return;
        this.progress = 0;
    }
}
