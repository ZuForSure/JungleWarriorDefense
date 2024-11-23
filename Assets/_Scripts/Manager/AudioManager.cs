using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MyMonoBehaviour
{
    protected static AudioManager instance;
    public static AudioManager Instance => instance;

    public List<AudioSource> audioSoures;
    public List<AudioClip> audioClips;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAudioSources();
    }

    protected override void Awake()
    {
        base.Awake();
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            AudioManager.instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    protected override void Start()
    {
        base.Start();
        this.PlayAudioBG(this.audioClips[0]);
    }

    protected virtual void LoadAudioSources()
    {
        if (this.audioSoures.Count > 0) return;

        foreach(Transform child in this.transform)
        {
            AudioSource source = child.GetComponent<AudioSource>();
            this.audioSoures.Add(source);
        }
        Debug.Log(transform.name + ": LoadAudioSources", gameObject);
    }

    public virtual void PlayBackgroundLevel(string levelName)
    {
        foreach (AudioClip clip in this.audioClips)
        {
            if (clip.name != levelName) continue;

            this.PlayAudioBG(clip);
            break;
        }
    }

    public virtual void PlaySFX(string soundName)
    {
        foreach (AudioClip clip in this.audioClips)
        {
            if (clip.name != soundName) continue;

            this.PlayAudioSFX(clip);
            break;
        }
    }

    public virtual void PlayAudioSFX(AudioClip audio)
    {
        foreach (AudioSource auSource in this.audioSoures) 
        {
            if(auSource.name != "SFX Sound") continue;
            auSource.PlayOneShot(audio);
            break;
        }
    }

    public virtual void PlayAudioBG(AudioClip audio)
    {
        foreach (AudioSource auSource in this.audioSoures)
        {
            if (auSource.name != "BG Sound") continue;
            auSource.clip = audio;
            auSource.Play();
            break;
        }
    }
}
