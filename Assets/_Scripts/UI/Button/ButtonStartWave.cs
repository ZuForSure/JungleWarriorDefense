using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStartWave : BaseButton
{
    protected override void OnClick()
    {
        WaveManager.Instance.isStartWave = true;
        transform.gameObject.SetActive(false);
    }
}
