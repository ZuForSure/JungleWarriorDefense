using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SliderLoading : BaseSlider
{
    [Header("Slider Loading")]
    [SerializeField] protected bool isLoaded = false;

    protected override void OnChange(float newValue)
    {
        if (this.progress < 0.9f) return;

        this.isLoaded = true;
    }

    public IEnumerator LoadingScene(string sceneName)
    {
        this.slider.value = 0;
        this.progress = 0;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;

        while(!asyncOperation.isDone)
        {
            this.progress = Mathf.MoveTowards(this.progress, asyncOperation.progress, Time.deltaTime);
            this.slider.value = this.progress;
            if(this.isLoaded) 
            {
                this.slider.value = 1;
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
