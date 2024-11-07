using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MyMonoBehaviour
{
    protected static GameManager instance;
    public static GameManager Instance => instance;

    [SerializeField] protected bool isGameOver = false;
    [SerializeField] protected bool isVictory = false;
    public bool IsVictory => isVictory;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 GameManager");
        GameManager.instance = this;
    }

    public virtual void GameOver()
    {
        this.isGameOver = true;
        StartCoroutine(GameOverDelay());
    }

    public virtual void VictoryGame()
    {
        StartCoroutine(VictoryGameDelay());
    }

    private IEnumerator VictoryGameDelay()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("VICTORY");
    }

    private IEnumerator GameOverDelay()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(2);
        yield return waitForSeconds;

        Debug.Log("LOSE");
        Application.Quit();
    }
}
