using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "SO/Enemy")]
public class EnemySO : ScriptableObject
{
    public EnemyName enemyName;
    public EnemyType enemyType;
    public int hp;
    public int gold;
    public float speed;
    public int exp;    
}
