using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : BaseButton
{
    protected override void OnClick()
    {
        Time.timeScale = 1f;
        this.sceneLoading.SetActive(true);
        StartCoroutine(this.sliderLoading.LoadingScene("Select Level"));
    }
}
