using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StackAvtHero : BaseStack
{
    [Header("Stack Avatar Hero")]
    [SerializeField] protected int countActiveItem = 0;
    [SerializeField] protected List<HeroAvtController> avtCtrls;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAvatarController();
        this.HideItem();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.UpdateAvtHero();
    }

    protected virtual void LoadAvatarController()
    {
        if (this.avtCtrls.Count > 0) return;
        foreach(Transform item in this.items)
        {
            this.avtCtrls.Add(item.GetComponent<HeroAvtController>());
        }
        Debug.Log(transform.name + ": LoadAvatarController", gameObject);
    }

    protected virtual void HideItem()
    {
        foreach (Transform item in this.items)
        {
            item.gameObject.SetActive(false);
        }
    }

    protected virtual void UpdateAvtHero()
    {
        for (int i = 0; i < HeroManager.Instance.Heros.Count; i++)
        {
            HeroController heroCtrl = HeroManager.Instance.Heros[i].GetComponent<HeroController>();
            if (this.avtCtrls[i].image.sprite == heroCtrl.HeroSO.avatar) continue;
            
            this.avtCtrls[i].image.sprite = heroCtrl.HeroSO.avatar;
            this.items[i].gameObject.SetActive(true);
        }
    }
}
