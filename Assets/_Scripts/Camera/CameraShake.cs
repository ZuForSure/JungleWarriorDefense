using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MyMonoBehaviour
{
    protected static CameraShake instance;
    public static CameraShake Instance => instance;

    public bool canShake = false;
    [SerializeField] protected CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] protected float shakeIntensity = 4f;
    [SerializeField] protected float shakeTime = 1f;
    [SerializeField] protected float timer;
    protected CinemachineBasicMultiChannelPerlin _cpmcp;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 CameraShake");
        CameraShake.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCinemachineCam();
    }

    protected override void Start()
    {
        base.Start();
        this.StopShake();
    }

    protected override void Update()
    {
        base.Update();
        this.ShakingCam();
    }

    protected virtual void LoadCinemachineCam()
    {
        if (this.cinemachineVirtualCamera != null) return;
        this.cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        Debug.Log(transform.name + ": LoadCinemachineCam", gameObject);
    }

    protected virtual void ShakingCam()
    {
        if (!this.canShake) this.StopShake();
        else this.ShakeCam();

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0) this.StopShake();
        }
    }

    protected virtual void ShakeCam()
    {
        CinemachineBasicMultiChannelPerlin _cbmcp = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = this.shakeIntensity;
        timer = this.shakeTime;
    }

    protected virtual void StopShake()
    {
        CinemachineBasicMultiChannelPerlin _cbmcp = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        
        _cbmcp.m_AmplitudeGain = 0;
        timer = 0;
    }
}
