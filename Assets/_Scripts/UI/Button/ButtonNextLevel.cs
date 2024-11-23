using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNextLevel : BaseButton
{
    protected override void OnClick()
    {
        Time.timeScale = 1.0f;

        char levelChar = SceneManager.GetActiveScene().name.ToString()[^1];
        int nextLevel = (int)char.GetNumericValue(levelChar) + 1;

        if (nextLevel > 5) return;
        string nextLevelScene = "Level " + nextLevel;

        this.sceneLoading.SetActive(true);
        StartCoroutine(this.sliderLoading.LoadingScene(nextLevelScene));

        AudioManager.Instance.PlayBackgroundLevel(nextLevelScene);
    }
}
