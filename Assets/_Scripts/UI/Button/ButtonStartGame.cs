using UnityEngine;

public class ButtonStartGame : BaseButton
{
    //[Header("Button Start Game")]

    protected override void OnClick()
    {
        this.sceneLoading.SetActive(true);
        StartCoroutine(this.sliderLoading.LoadingScene("Select Level"));
    }
}
