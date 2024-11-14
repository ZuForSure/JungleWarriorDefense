using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MyMonoBehaviour
{
    protected static GameManager instance;
    public static GameManager Instance => instance;

    [SerializeField] protected Image gameOverImage;
    [SerializeField] protected Image gameVictoryImage;
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
        if(this.gameOverImage != null) return;
        this.gameOverImage = GameObject.Find("Game Over UI").GetComponentInChildren<Image>();
        this.gameVictoryImage = GameObject.Find("Victory UI").GetComponentInChildren<Image>();
        Debug.Log(transform.name + ": LoadGameOverImg", gameOverImage);
        this.gameOverImage.gameObject.SetActive(false);
        this.gameVictoryImage.gameObject.SetActive(false);
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
    }

    private IEnumerator VictoryGameDelay()
    {
        yield return new WaitForSeconds(2);
        this.gameVictoryImage.gameObject.SetActive(true);
    }

    private IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(2);
        this.gameOverImage.gameObject.SetActive(true);
    }
}
