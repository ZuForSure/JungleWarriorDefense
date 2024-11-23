using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MyMonoBehaviour
{
    protected static GameManager instance;
    public static GameManager Instance => instance;

    [SerializeField] protected LevelSO nextLevel;
    [SerializeField] protected Image gameOverBG;
    [SerializeField] protected Image gameVictoryBG;
    [SerializeField] protected bool isGameOver = false;
    [SerializeField] protected bool isVictory = false;
    public bool IsVictory => isVictory;
    public bool IsGameOver => isGameOver;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGameOverImg();
    }

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 GameManager");
        GameManager.instance = this;
    }

    protected virtual void LoadGameOverImg()
    {
        if(this.gameOverBG != null) return;
        this.gameOverBG = GameObject.Find("Game Over UI").GetComponentInChildren<Image>();
        this.gameVictoryBG = GameObject.Find("Victory UI").GetComponentInChildren<Image>();
        Debug.Log(transform.name + ": LoadGameOverImg", gameOverBG);
        this.gameOverBG.gameObject.SetActive(false);
        this.gameVictoryBG.gameObject.SetActive(false);
    }

    public virtual void GameOver()
    {
        this.isGameOver = true;
        StartCoroutine(GameOverDelay());
    }

    public virtual void VictoryGame()
    {
        this.isVictory = true;
        StartCoroutine(VictoryGameDelay());

        if (this.nextLevel == null) return;
        this.nextLevel.isUnlocked = true;
    }

    private IEnumerator VictoryGameDelay()
    {
        yield return new WaitForSeconds(2);
        this.gameVictoryBG.gameObject.SetActive(true);
    }

    private IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(2);
        FXSpawner.Instance.SpawnLoseFX(Vector3.zero, Quaternion.identity);
        this.SpawnSound();

        yield return new WaitForSeconds(1);
        this.gameOverBG.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    protected virtual void SpawnSound()
    {
        AudioManager.Instance.PlaySFX("Turret Despawn");
    }
}
