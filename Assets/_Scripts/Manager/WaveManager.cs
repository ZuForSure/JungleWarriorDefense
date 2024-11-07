using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MyMonoBehaviour
{
    protected static WaveManager instance;
    public static WaveManager Instance => instance;

    [SerializeField] protected bool isStartWave = false;
    [SerializeField] protected bool isWaveDone = true;
    [SerializeField] protected float waveTimer = 0f;
    [SerializeField] protected float timeBetweenWaves = 10f;
    [SerializeField] protected float timeBetweenEnemies = 2f;
    [SerializeField] protected int maxEnemies = 5; 
    [SerializeField] protected int waveCount = 0; 
    [SerializeField] protected int enemyCount = 0; 
    public bool IsStartWave => isStartWave;
    public float WaveTimer => waveTimer;

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

        this.Spawning();
    }

    protected virtual bool CheckIsStartWave()
    {
        return this.isStartWave;
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

        if (this.waveCount > 3) 
        { 
            GameManager.Instance.VictoryGame();
            this.isStartWave = false;
            yield break;
        }

        for (int i = 0; i < maxEnemies; i++)
        {
            EnemySpawner.Instance.SpawnEnemyAtRandomPoint();
            this.enemyCount++;
            yield return new WaitForSeconds(this.timeBetweenEnemies);
        }

        this.enemyCount = 0;
        this.maxEnemies += 5;
        yield return new WaitForSeconds(this.timeBetweenWaves);

        this.isWaveDone = true;
    }
}
