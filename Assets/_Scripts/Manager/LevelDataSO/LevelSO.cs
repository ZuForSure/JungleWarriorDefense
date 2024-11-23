using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "SO/Level")]

public class LevelSO : ScriptableObject
{
    public bool isUnlocked = false;
    public float timeBetweenWaves = 10f;
    public float timeBetweenEnemies = 5f;
    public int maxEnemies = 5;
    public int newQuantityE = 5;
    public int finalWave = 3;
}
