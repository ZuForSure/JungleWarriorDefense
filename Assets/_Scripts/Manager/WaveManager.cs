using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MyMonoBehaviour
{
    protected static WaveManager instance;
    public static WaveManager Instance => instance;

    public bool isStartWave = false;
    public float totalTimePerWave;
    public float waveTimer = 0f;
    public int enemyCount = 0;
    [SerializeField] protected bool isWaveDone = true;
    [SerializeField] protected float timeBetweenWaves = 10f;
    [SerializeField] protected float timeBetweenEnemies = 5f;
    [SerializeField] protected int maxEnemies = 5; 
    [SerializeField] protected int waveCount = 0; 
    [SerializeField] protected int finalWave = 3; 
    public int WaveCount => waveCount;
    public int FinalWave => finalWave;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 WaveManager");
        WaveManager.instance = this;
    }

    protected override void Update()
    {
        base.Update();
        if (!this.CheckIsStartWave()) return;

        this.ChangeTimeBetweenE();
        this.Spawning();
    }

    protected virtual bool CheckIsStartWave()
    {
        if(GameManager.Instance.IsGameOver) this.isStartWave = false;
        return this.isStartWave;
    }

    protected virtual void ChangeTimeBetweenE()
    {
        if (this.waveCount != this.finalWave) return;
        this.timeBetweenEnemies = 2.5f;
    }

    protected virtual void Spawning()
    {
        this.waveTimer += Time.deltaTime;
        if (!this.isWaveDone) return;

        StartCoroutine(this.WaveSpawner());
    }

    protected IEnumerator WaveSpawner()
    {
        this.isWaveDone = false;
        this.waveCount++;
        this.totalTimePerWave = (this.timeBetweenEnemies * (float)this.maxEnemies) + this.timeBetweenWaves;

        if (this.waveCount > this.finalWave) 
        { 
            this.isStartWave = false;
            yield break;
        }

        for (int i = 0; i < maxEnemies; i++)
        {
            EnemySpawner.Instance.SpawnEnemyAtRandomPoint();
            this.enemyCount++;
            yield return new WaitForSeconds(this.timeBetweenEnemies);
        }
        
        this.maxEnemies += 5;
        yield return new WaitForSeconds(this.timeBetweenWaves);

        this.isWaveDone = true;
    }
}
