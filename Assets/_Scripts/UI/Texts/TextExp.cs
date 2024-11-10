using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextExp : BaseText
{
    protected override void FixedUpdate()
    {
        this.UpdateExpText();
    }

    protected virtual void UpdateExpText()
    {
        int exp = ScoreManager.Instance.GetExp();
        this.text.SetText(exp.ToString());
    }
}
