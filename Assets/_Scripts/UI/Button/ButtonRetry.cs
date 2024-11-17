using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonRetry : BaseButton
{
    protected override void OnClick()
    {
        Time.timeScale = 1f;
        this.sceneLoading.SetActive(true);
        StartCoroutine(this.sliderLoading.LoadingScene(SceneManager.GetActiveScene().name));
    }
}
