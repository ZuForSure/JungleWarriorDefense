using UnityEngine;

public class ButtonStartGame : BaseButton
{
    protected override void OnClick()
    {
        Time.timeScale = 1.0f;

        this.sceneLoading.SetActive(true);
        StartCoroutine(this.sliderLoading.LoadingScene("Select Level"));
    }
}
