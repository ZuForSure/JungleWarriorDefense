using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSelectLevel : BaseButton
{
    [Header("Btn Select Level")]
    [SerializeField] protected CheckUnlockLevel checkUnlock;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCheckUnlockLevel();
    }

    protected virtual void LoadCheckUnlockLevel()
    {
        if (this.checkUnlock != null) return;
        this.checkUnlock = GameObject.Find("Check Status Level").GetComponent<CheckUnlockLevel>();  
        Debug.Log(transform.name + ": LoadCheckUnlockLevel", gameObject);
    }

    protected override void OnClick()
    {
        string level = transform.name[^1].ToString(); //Get the last char of button's name then convert to string
        string sceneName = "Level " + level;

        int indexLevel = int.Parse(level) - 1;  //Convert string to int then minus it, same as the index list
        if (!this.checkUnlock.levels[indexLevel].isUnlocked) return;

        this.sceneLoading.SetActive(true);
        StartCoroutine(this.sliderLoading.LoadingScene(sceneName));

        AudioManager.Instance.PlayBackgroundLevel(sceneName);
    }

    //protected virtual void PlayBackgroundLevel(string sceneName)
    //{
    //    foreach(AudioClip clip in AudioManager.Instance.audioClips)
    //    {
    //        if(clip.name != sceneName) continue;

    //        AudioManager.Instance.PlayAudioBG(clip);
    //        break;
    //    }
    //}
}
