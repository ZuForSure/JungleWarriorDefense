using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckUnlockLevel : MyMonoBehaviour
{
    public List<LevelSO> levels;
    [SerializeField] protected List<Image> statusImgs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStatusImgs();
    }

    protected virtual void LoadStatusImgs()
    {
        if (this.statusImgs.Count > 0) return;

        Transform stackLevel = GameObject.Find("Stack Levels").transform;
        foreach (Transform child in stackLevel)
        {
            Image statusImg = child.GetChild(1).GetComponent<Image>();
            this.statusImgs.Add(statusImg);
        }

        Debug.Log(transform.name + ": LoadStatusImgs", gameObject);
    }

    protected override void Start()
    {
        base.Start();
        this.UpdateUnlockLevel();
    }

    protected virtual void UpdateUnlockLevel()
    {
        for(int i = 0; i < this.levels.Count; i++)
        {
            if (!this.levels[i].isUnlocked) continue;
            this.statusImgs[i].gameObject.SetActive(false);
        }
    }
}
