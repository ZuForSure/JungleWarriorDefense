using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class BaseText : MyMonoBehaviour
{
    [Header("Base Text")]
    [SerializeField] protected TextMeshProUGUI text;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextMeshPro();
    }

    protected virtual void LoadTextMeshPro()
    {
        if (this.text != null) return;
        this.text = GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadTextMeshPro", gameObject);
    }
}
