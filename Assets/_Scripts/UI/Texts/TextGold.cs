using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextGold : BaseText
{
    protected override void FixedUpdate()
    {
        this.UpdateGoldText();
    }

    protected virtual void UpdateGoldText()
    {
        int gold = ScoreManager.Instance.GetGold();
        this.text.SetText(gold.ToString());
    }
}
