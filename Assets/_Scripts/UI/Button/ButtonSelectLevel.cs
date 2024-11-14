using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSelectLevel : BaseButton
{
    [Header("Btn Select Level")]
    [SerializeField] protected bool isLocked = false;

    protected override void OnClick()
    {
        string level = transform.name[^1].ToString();
        string sceneName = "Level " + level;

        this.sceneLoading.SetActive(true);
        StartCoroutine(this.sliderLoading.LoadingScene(sceneName));
    }
}
