using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHome : BaseButton
{
    //[Header("Button Home")]
    protected override void OnClick()
    {
        this.sceneLoading.SetActive(true);
        StartCoroutine(this.sliderLoading.LoadingScene("Start Game"));
    }
}
