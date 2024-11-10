using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroAvtController : MyMonoBehaviour
{
    public Image image;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadImage();
    }

    protected virtual void LoadImage()
    {
        if (this.image != null) return;
        this.image = transform.Find("Icon").GetComponentInChildren<Image>();
        Debug.Log(transform.name + ": LoadImage", gameObject);
    }
}
