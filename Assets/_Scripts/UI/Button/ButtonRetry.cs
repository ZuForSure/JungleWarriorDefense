using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonRetry : BaseButton
{
    protected override void OnClick()
    {
        this.sceneLoading.SetActive(true);
        StartCoroutine(this.sliderLoading.LoadingScene(SceneManager.GetActiveScene().name));
    }
}
